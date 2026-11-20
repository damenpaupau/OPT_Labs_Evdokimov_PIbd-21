namespace ITServiceAccounting
{
    partial class ServiceListForm
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
			dgvServices = new DataGridView();
			btnAdd = new Button();
			btnEdit = new Button();
			btnDelete = new Button();
			((System.ComponentModel.ISupportInitialize)dgvServices).BeginInit();
			SuspendLayout();
			// 
			// dgvServices
			// 
			dgvServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvServices.Location = new Point(12, 12);
			dgvServices.Name = "dgvServices";
			dgvServices.Size = new Size(776, 339);
			dgvServices.TabIndex = 0;
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
			// ServiceListForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(btnDelete);
			Controls.Add(btnEdit);
			Controls.Add(btnAdd);
			Controls.Add(dgvServices);
			Name = "ServiceListForm";
			Text = "ServiceListForm";
			((System.ComponentModel.ISupportInitialize)dgvServices).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private DataGridView dgvServices;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
    }
}