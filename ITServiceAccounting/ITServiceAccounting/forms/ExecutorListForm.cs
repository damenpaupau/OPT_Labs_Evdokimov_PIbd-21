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
    public partial class ExecutorListForm : Form
    {
        private readonly IExecutorRepository _repository;

        public ExecutorListForm(IExecutorRepository repository)
        {
            InitializeComponent();
            _repository = repository;

            this.Load += ExecutorListForm_Load;
        }

        private void ExecutorListForm_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            dgvExecutors.DataSource = null;
            dgvExecutors.DataSource = _repository.GetAll();

            if (dgvExecutors.Columns["Id"] != null)
            {
                dgvExecutors.Columns["Id"].Visible = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var editForm = new ExecutorEditForm(_repository);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                UpdateGrid();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvExecutors.CurrentRow == null) return;

            var selectedExecutor = (Executor)dgvExecutors.CurrentRow.DataBoundItem;

            var editForm = new ExecutorEditForm(_repository, selectedExecutor);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                UpdateGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvExecutors.CurrentRow == null) return;

            var selectedExecutor = (Executor)dgvExecutors.CurrentRow.DataBoundItem;

            var result = MessageBox.Show($"Удалить исполнителя {selectedExecutor.FullName}?",
                                         "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _repository.Delete(selectedExecutor.Id);
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
                            "Невозможно удалить исполнителя, так как он указан в одном или нескольких договорах.",
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
}
