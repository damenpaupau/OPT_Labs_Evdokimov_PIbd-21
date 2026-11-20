using ITServiceAccounting.interfaces;
using ITServiceAccounting.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITServiceAccounting.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly DataContext _context;
        private readonly ILogger _logger;

        public ContractRepository(DataContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add(Contract contract)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                if (contract.Client != null)
                {
                    contract.OrganizationId = contract.Client.Id;
                    contract.Client = null;
                }

                if (contract.ResponsibleExecutor != null)
                {
                    contract.ExecutorId = contract.ResponsibleExecutor.Id;
                    contract.ResponsibleExecutor = null;
                }

                _logger.Information(
                    "Начало сохранения договора: Id={Id}, ClientId={ClientId}, ExecutorId={ExecutorId}, TotalAmount={TotalAmount}, ServicesCount={ServicesCount}",
                    contract.Id,
                    contract.OrganizationId,
                    contract.ExecutorId,
                    contract.TotalAmount,
                    contract.ContractServices?.Count ?? 0);

                var linkedServices = contract.ContractServices?.ToList() ?? new List<ContractService>();
                contract.ContractServices?.Clear();

                _context.Contracts.Add(contract);
                _context.SaveChanges();

                foreach (var item in linkedServices)
                {
                    var serviceId = item.Service?.Id ?? item.ServiceId;
                    var serviceEntity = _context.Services.First(s => s.Id == serviceId);
                    var link = ContractService.Create(contract, serviceEntity);

                    _context.ContractServices.Add(link);
                }

                _context.SaveChanges();
                transaction.Commit();

                _logger.Information("Договор и связанные услуги успешно сохранены в транзакции: Id={Id}", contract.Id);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                _logger.Error(ex, "Транзакция отменена из-за ошибки при сохранении договора: Id={Id}", contract?.Id);
                throw;
            }
        }

        public List<Contract> GetAll()
        {
            _logger.Information("Получение списка всех договоров со связанными данными");
            return _context.Contracts
                .Include(c => c.Client)
                .Include(c => c.ResponsibleExecutor)
                .Include(c => c.ContractServices)
                    .ThenInclude(cs => cs.Service)
                .OrderByDescending(c => c.StartDate)
                .ToList();
        }

        public Contract GetById(Guid id)
        {
            _logger.Information("Поиск договора по Id={Id}", id);
            return _context.Contracts
                .Include(c => c.Client)
                .Include(c => c.ResponsibleExecutor)
                .Include(c => c.ContractServices)
                    .ThenInclude(cs => cs.Service)
                .FirstOrDefault(c => c.Id == id);
        }

        public void Delete(Guid id)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _logger.Information("Удаление договора: Id={Id}", id);
                var contract = _context.Contracts
                    .Include(c => c.ContractServices)
                    .FirstOrDefault(c => c.Id == id);

                if (contract != null)
                {
                    if (contract.ContractServices.Any())
                    {
                        _context.ContractServices.RemoveRange(contract.ContractServices);
                    }

                    _context.Contracts.Remove(contract);
                    _context.SaveChanges();
                    transaction.Commit();

                    _logger.Information("Договор успешно удалён: Id={Id}", id);
                }
                else
                {
                    _logger.Warning("Договор для удаления не найден: Id={Id}", id);
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                _logger.Error(ex, "Ошибка при удалении договора: Id={Id}", id);
                throw;
            }
        }
    }
}