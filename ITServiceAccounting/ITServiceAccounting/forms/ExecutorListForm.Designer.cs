namespace ITServiceAccounting
{
    partial class ExecutorListForm
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
			dgvExecutors = new DataGridView();
			btnAdd = new Button();
			btnEdit = new Button();
			btnDelete = new Button();
			((System.ComponentModel.ISupportInitialize)dgvExecutors).BeginInit();
			SuspendLayout();
			// 
			// dgvExecutors
			// 
			dgvExecutors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvExecutors.Location = new Point(12, 12);
			dgvExecutors.Name = "dgvExecutors";
			dgvExecutors.Size = new Size(776, 337);
			dgvExecutors.TabIndex = 0;
			// 
			// btnAdd
			// 
			btnAdd.Location = new Point(12, 355);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(97, 23);
			btnAdd.TabIndex = 1;
			btnAdd.Text = "Добавить";
			btnAdd.UseVisualStyleBackColor = true;
			btnAdd.Click += btnAdd_Click;
			// 
			// btnEdit
			// 
			btnEdit.Location = new Point(12, 384);
			btnEdit.Name = "btnEdit";
			btnEdit.Size = new Size(97, 23);
			btnEdit.TabIndex = 2;
			btnEdit.Text = "Редактировать";
			btnEdit.UseVisualStyleBackColor = true;
			btnEdit.Click += btnEdit_Click;
			// 
			// btnDelete
			// 
			btnDelete.Location = new Point(12, 415);
			btnDelete.Name = "btnDelete";
			btnDelete.Size = new Size(97, 23);
			btnDelete.TabIndex = 3;
			btnDelete.Text = "Удалить";
			btnDelete.UseVisualStyleBackColor = true;
			btnDelete.Click += btnDelete_Click;
			// 
			// ExecutorListForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(btnDelete);
			Controls.Add(btnEdit);
			Controls.Add(btnAdd);
			Controls.Add(dgvExecutors);
			Name = "ExecutorListForm";
			Text = "ExecutorListForm";
			((System.ComponentModel.ISupportInitialize)dgvExecutors).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private DataGridView dgvExecutors;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
    }
}