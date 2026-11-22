using ITServiceAccounting.interfaces;
using ITServiceAccounting.Models;
using ITServiceAccounting.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

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

			try
			{
				_repository.Delete(selectedService.Id);
				UpdateGrid();
			}
			catch (Exception ex)
			{
				string details = ex.InnerException?.Message ?? ex.Message;

				if (details.Contains("23503") ||
					details.Contains("23001") ||
					details.Contains("foreign key", StringComparison.OrdinalIgnoreCase) ||
					details.Contains("внешнего ключа", StringComparison.OrdinalIgnoreCase))
				{
					MessageBox.Show(
						"Невозможно удалить услугу, так как она уже используется в одном или нескольких договорах.",
						"Ошибка удаления",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
				}
				else
				{
					MessageBox.Show(
						$"Ошибка при удалении:\n{details}",
						"Ошибка",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
			}
		}
	}
 }
