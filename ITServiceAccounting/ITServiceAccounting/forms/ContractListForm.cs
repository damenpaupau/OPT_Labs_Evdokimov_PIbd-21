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
	public partial class ContractListForm : Form
	{
		private readonly IContractRepository _contractRepo;
		private readonly IOrganizationRepository _orgRepo;
		private readonly IExecutorRepository _execRepo;
		private readonly IServiceRepository _serviceRepo;

		public ContractListForm(
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

			this.Load += ContractListForm_Load;
		}

		private void ContractListForm_Load(object sender, EventArgs e)
		{
			UpdateGrid();
		}

		private void UpdateGrid()
		{
			dgvContracts.DataSource = null;
			dgvContracts.DataSource = _contractRepo.GetAll();

			if (dgvContracts.Columns["Id"] != null)
			{
				dgvContracts.Columns["Id"].Visible = false;
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			var addForm = new ContractAddForm(_contractRepo, _orgRepo, _execRepo, _serviceRepo);
			if (addForm.ShowDialog() == DialogResult.OK)
			{
				UpdateGrid();
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (dgvContracts.CurrentRow == null) return;

			var selectedContract = (Contract)dgvContracts.CurrentRow.DataBoundItem;

			var result = MessageBox.Show("Удалить выбранный договор?",
						  "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				_contractRepo.Delete(selectedContract.Id);
				UpdateGrid();
			}
		}
	}
}
