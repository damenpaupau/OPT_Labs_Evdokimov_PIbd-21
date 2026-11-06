namespace ITServiceAccounting
{
    partial class ContractListForm
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
			dgvContracts = new DataGridView();
			btnAdd = new Button();
			btnDelete = new Button();
			((System.ComponentModel.ISupportInitialize)dgvContracts).BeginInit();
			SuspendLayout();
			// 
			// dgvContracts
			// 
			dgvContracts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvContracts.Location = new Point(12, 12);
			dgvContracts.Name = "dgvContracts";
			dgvContracts.Size = new Size(776, 368);
			dgvContracts.TabIndex = 0;
			// 
			// btnAdd
			// 
			btnAdd.Location = new Point(12, 386);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(75, 23);
			btnAdd.TabIndex = 1;
			btnAdd.Text = "Добавить";
			btnAdd.UseVisualStyleBackColor = true;
			btnAdd.Click += btnAdd_Click;
			// 
			// btnDelete
			// 
			btnDelete.Location = new Point(12, 415);
			btnDelete.Name = "btnDelete";
			btnDelete.Size = new Size(75, 23);
			btnDelete.TabIndex = 2;
			btnDelete.Text = "Удалить";
			btnDelete.UseVisualStyleBackColor = true;
			btnDelete.Click += btnDelete_Click;
			// 
			// ContractListForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(btnDelete);
			Controls.Add(btnAdd);
			Controls.Add(dgvContracts);
			Name = "ContractListForm";
			Text = "ContractListForm";
			((System.ComponentModel.ISupportInitialize)dgvContracts).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private DataGridView dgvContracts;
        private Button btnAdd;
        private Button btnDelete;
    }
}