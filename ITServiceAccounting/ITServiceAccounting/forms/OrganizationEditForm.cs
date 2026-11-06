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
    public partial class OrganizationEditForm : Form
    {
        private readonly IOrganizationRepository _repository;
        private readonly Organization _organizationToEdit;

        // В конструктор передаем репозиторий и, если это редактирование, саму организацию. Если organization == null, значит мы создаем новую запись.
        public OrganizationEditForm(IOrganizationRepository repository, Organization organization = null)
        {
            InitializeComponent();
            _repository = repository;
            _organizationToEdit = organization;

            if (_organizationToEdit != null)
            {
                // Заполняем поля старыми данными, если это редактирование
                txtName.Text = _organizationToEdit.Name;
                txtInn.Text = _organizationToEdit.Inn;
                txtContact.Text = _organizationToEdit.ContactPerson;
                this.Text = "Редактирование организации";
            }
            else
            {
                this.Text = "Добавление организации";
            }
        }

        // Обработчик кнопки Сохранить
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_organizationToEdit == null)
                {
                    // Создаем новую организацию. Если поля пустые, сработает проверка из метода Create
                    var newOrg = Organization.Create(txtName.Text, txtInn.Text, txtContact.Text);
                    _repository.Add(newOrg);
                }
                else
                {
                    // Обновляем существующую
                    _organizationToEdit.Update(txtName.Text, txtInn.Text, txtContact.Text);
                    _repository.Update(_organizationToEdit);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Показываем ошибку, если пользователь ввел пустые данные
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
