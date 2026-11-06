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
    public partial class ExecutorEditForm : Form
    {
        private readonly IExecutorRepository _repository;
        private readonly Executor _executorToEdit;

        public ExecutorEditForm(IExecutorRepository repository, Executor executor = null)
        {
            InitializeComponent();
            _repository = repository;
            _executorToEdit = executor;

            if (_executorToEdit != null)
            {
                txtFullName.Text = _executorToEdit.FullName;
                txtPosition.Text = _executorToEdit.Position;
                this.Text = "Редактирование исполнителя";
            }
            else
            {
                this.Text = "Добавление исполнителя";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_executorToEdit == null)
                {
                    var newExecutor = Executor.Create(txtFullName.Text, txtPosition.Text);
                    _repository.Add(newExecutor);
                }
                else
                {
                    _executorToEdit.Update(txtFullName.Text, txtPosition.Text);
                    _repository.Update(_executorToEdit);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
