using ITServiceAccounting.Models;
using Microsoft.EntityFrameworkCore;

namespace ITServiceAccounting
{
    public class DataContext : DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Executor> Executors { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractService> ContractServices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ITServiceAccountingDb;Username=postgres;Password=2619773461");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Настройка связи 1:N (Организация -> Договоры)
            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Client)
                .WithMany(o => o.Contracts)
                .HasForeignKey(c => c.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Настройка связи 1:N (Исполнитель -> Договоры)
            modelBuilder.Entity<Contract>()
                .HasOne(c => c.ResponsibleExecutor)
                .WithMany(e => e.Contracts)
                .HasForeignKey(c => c.ExecutorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Настройка связи N:M через промежуточную сущность ContractService
            modelBuilder.Entity<ContractService>()
                .HasOne(cs => cs.Contract)
                .WithMany(c => c.ContractServices)
                .HasForeignKey(cs => cs.ContractId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ContractService>()
                .HasOne(cs => cs.Service)
                .WithMany(s => s.ContractServices)
                .HasForeignKey(cs => cs.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}