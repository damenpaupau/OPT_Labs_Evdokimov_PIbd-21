using ITServiceAccounting.interfaces;
using ITServiceAccounting.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ITServiceAccounting
{
    public partial class ContractAddForm : Form
    {
        private readonly IContractRepository _contractRepo;
        private readonly IOrganizationRepository _orgRepo;
        private readonly IExecutorRepository _execRepo;
        private readonly IServiceRepository _serviceRepo;

        public ContractAddForm(
            IContractRepository contractRepo,
            IOrganizationRepository orgRepo,
            IExecutorRepository execRepo,
            IServiceRepository serviceRepo)
        {
            InitializeComponent();
            _contractRepo = contractRepo;
            _orgRepo = orgRepo;
            _execRepo = execRepo;
            _serviceRepo = serviceRepo;

            this.Load += ContractAddForm_Load;
        }

        private void ContractAddForm_Load(object sender, EventArgs e)
        {
            // Загружаем клиентов и исполнителей в выпадающие списки
            cmbClient.DataSource = _orgRepo.GetAll();
            cmbClient.DisplayMember = "Name"; 

            cmbExecutor.DataSource = _execRepo.GetAll();
            cmbExecutor.DisplayMember = "FullName";

            // Загружаем все доступные услуги в таблицу
            dgvServices.DataSource = _serviceRepo.GetAll();

            if (dgvServices.Columns["ContractServices"] != null)
            {
                dgvServices.Columns["ContractServices"].Visible = false;
            }

            // Добавляем чекбокс в DataGridView для выбора нескольких услуг
            var checkColumn = new DataGridViewCheckBoxColumn
            {
                Name = "IsSelected",
                HeaderText = "Выбрать",
                Width = 70
            };
            dgvServices.Columns.Insert(0, checkColumn);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var client = (Organization)cmbClient.SelectedItem;
                var executor = (Executor)cmbExecutor.SelectedItem;

                if (!decimal.TryParse(txtTotalAmount.Text, out var amount))
                {
                    MessageBox.Show("Введите корректную сумму договора.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (client == null || executor == null)
                {
                    MessageBox.Show("Пожалуйста, выберите клиента и исполнителя.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Создаем объект договора
                var contract = Contract.Create(
                    amount,
                    dtpStartDate.Value.Date,
                    dtpEndDate.Value.Date,
                    client,
                    executor,
                    Enums.ContractStatus.Signed);

                // Сначала привязываем все отмеченные услуги к договору
                foreach (DataGridViewRow row in dgvServices.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["IsSelected"].Value);
                    if (isSelected)
                    {
                        var service = (Service)row.DataBoundItem;
                        var link = ContractService.Create(contract, service);
                        contract.ContractServices.Add(link);
                    }
                }

                // Сохраняем договор вместе со связанными услугами в одной транзакции
                _contractRepo.Add(contract);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
