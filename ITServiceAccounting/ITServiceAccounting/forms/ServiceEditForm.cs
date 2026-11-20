using ITServiceAccounting.Enums;
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
    public partial class ServiceEditForm : Form
    {
        // Объявляем переменные на уровне класса, чтобы они были доступны во всех методах
        private readonly IServiceRepository _repository;
        private readonly Service _serviceToEdit;

        public ServiceEditForm(IServiceRepository repository, Service service = null)
        {
            InitializeComponent();
            _repository = repository;
            _serviceToEdit = service;

            // Привязываем Enum к ComboBox
            cmbCategory.DataSource = Enum.GetValues(typeof(ServiceCategory));

            if (_serviceToEdit != null)
            {
                txtName.Text = _serviceToEdit.Name;
                txtBaseCost.Text = _serviceToEdit.BaseCost.ToString();
                cmbCategory.SelectedItem = _serviceToEdit.Category;

                this.Text = "Редактирование услуги";
            }
            else
            {
                this.Text = "Добавление услуги";
            }
        }

        // Обработчик кнопки Сохранить
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var category = (ServiceCategory)cmbCategory.SelectedItem;
                var cost = decimal.Parse(txtBaseCost.Text);

                if (_serviceToEdit == null)
                {
                    var newService = Service.Create(txtName.Text, cost, category);
                    _repository.Add(newService);
                }
                else
                {
                    _serviceToEdit.Update(txtName.Text, cost, category);
                    _repository.Update(_serviceToEdit);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик кнопки Отмена
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
