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
	public partial class ServiceListForm : Form
	{
		private readonly IServiceRepository _repository;

		public ServiceListForm(IServiceRepository repository)
		{
			InitializeComponent();
			_repository = repository;

			this.Load += ServiceListForm_Load;
		}

		private void ServiceListForm_Load(object sender, EventArgs e)
		{
			UpdateGrid();
		}

		private void UpdateGrid()
		{
			dgvServices.DataSource = null;
			dgvServices.DataSource = _repository.GetAll();

			if (dgvServices.Columns["Id"] != null)
			{
				dgvServices.Columns["Id"].Visible = false;
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			var editForm = new ServiceEditForm(_repository);
			if (editForm.ShowDialog() == DialogResult.OK)
			{
				UpdateGrid();
			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (dgvServices.CurrentRow == null) return;

			var selectedService = (Service)dgvServices.CurrentRow.DataBoundItem;

			var editForm = new ServiceEditForm(_repository, selectedService);
			if (editForm.ShowDialog() == DialogResult.OK)
			{
				UpdateGrid();
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (dgvServices.CurrentRow == null) return;

			var selectedService = (Service)dgvServices.CurrentRow.DataBoundItem;

			var result = MessageBox.Show($"Удалить услугу {selectedService.Name}?",
						  "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				_repository.Delete(selectedService.Id);
				UpdateGrid();
			}
		}
	}
}
