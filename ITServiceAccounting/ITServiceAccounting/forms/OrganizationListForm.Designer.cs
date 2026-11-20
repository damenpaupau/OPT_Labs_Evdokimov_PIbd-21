namespace ITServiceAccounting
{
    partial class OrganizationListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvOrganizations = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOrganizations).BeginInit();
            SuspendLayout();
            // 
            // dgvOrganizations
            // 
            dgvOrganizations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrganizations.Location = new Point(12, 12);
            dgvOrganizations.Name = "dgvOrganizations";
            dgvOrganizations.Size = new Size(776, 339);
            dgvOrganizations.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 357);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(96, 23);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(12, 386);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(96, 23);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Редактировать";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(12, 415);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(96, 23);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // OrganizationListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dgvOrganizations);
            Name = "OrganizationListForm";
            Text = "OrganizationListForm";
            ((System.ComponentModel.ISupportInitialize)dgvOrganizations).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvOrganizations;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
    }
}