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

namespace ITServiceAccounting
{
    public partial class OrganizationListForm : Form
    {
        private readonly IOrganizationRepository _repository;

        // Внедряем репозиторий через конструктор
        public OrganizationListForm(IOrganizationRepository repository)
        {
            InitializeComponent();
            _repository = repository;

            // Настраиваем запуск загрузки данных при открытии формы
            this.Load += OrganizationListForm_Load;
        }

        private void OrganizationListForm_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        // Метод для обновления таблицы
        private void UpdateGrid()
        {
            // Получаем все данные из заглушки и привязываем к таблице
            dgvOrganizations.DataSource = null;
            dgvOrganizations.DataSource = _repository.GetAll();

            if (dgvOrganizations.Columns["Id"] != null)
            {
                dgvOrganizations.Columns["Id"].Visible = false;
            }
        }

        // Кнопка Добавить
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var editForm = new OrganizationEditForm(_repository);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // Обновляем таблицу, если сохранение прошло успешно
                UpdateGrid();
            }
        }

        // Кнопка Редактировать
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Проверяем, что в таблице выделена строка
            if (dgvOrganizations.CurrentRow == null) return;

            // Получаем организацию из выделенной строки
            var selectedOrg = (Organization)dgvOrganizations.CurrentRow.DataBoundItem;

            var editForm = new OrganizationEditForm(_repository, selectedOrg);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                UpdateGrid();
            }
        }

        // Кнопка Удалить
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvOrganizations.CurrentRow == null) return;

            var selectedOrg = (Organization)dgvOrganizations.CurrentRow.DataBoundItem;

            var result = MessageBox.Show($"Удалить организацию {selectedOrg.Name}?",
                                         "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _repository.Delete(selectedOrg.Id);
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
                            "Невозможно удалить организацию, так как на неё уже оформлены договоры.",
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
