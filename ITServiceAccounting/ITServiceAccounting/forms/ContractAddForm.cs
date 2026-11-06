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
                var amount = decimal.Parse(txtTotalAmount.Text);

                if (client == null || executor == null)
                {
                    MessageBox.Show("Пожалуйста, выберите клиента и исполнителя.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Создаем новый договор
                var contract = Contract.Create(amount, dtpStartDate.Value, dtpEndDate.Value, client, executor, Enums.ContractStatus.Signed);
                _contractRepo.Add(contract);

                // Обработка связи многие-ко-многим
                foreach (DataGridViewRow row in dgvServices.Rows)
                {
                    // Если галочка стоит
                    bool isSelected = Convert.ToBoolean(row.Cells["IsSelected"].Value);
                    if (isSelected)
                    {
                        var service = (Service)row.DataBoundItem;
                        // Создаем объект-связку
                        var link = ContractService.Create(contract, service);
                    }
                }

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
