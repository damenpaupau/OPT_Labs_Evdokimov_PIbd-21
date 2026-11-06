namespace ITServiceAccounting
{
    partial class ContractAddForm
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
			txtTotalAmount = new TextBox();
			dtpStartDate = new DateTimePicker();
			dtpEndDate = new DateTimePicker();
			cmbClient = new ComboBox();
			cmbExecutor = new ComboBox();
			dgvServices = new DataGridView();
			btnSave = new Button();
			btnCancel = new Button();
			((System.ComponentModel.ISupportInitialize)dgvServices).BeginInit();
			SuspendLayout();
			// 
			// txtTotalAmount
			// 
			txtTotalAmount.Location = new Point(12, 12);
			txtTotalAmount.Name = "txtTotalAmount";
			txtTotalAmount.Size = new Size(100, 23);
			txtTotalAmount.TabIndex = 0;
			txtTotalAmount.Text = "Сумма";
			// 
			// dtpStartDate
			// 
			dtpStartDate.Location = new Point(12, 41);
			dtpStartDate.Name = "dtpStartDate";
			dtpStartDate.Size = new Size(200, 23);
			dtpStartDate.TabIndex = 1;
			// 
			// dtpEndDate
			// 
			dtpEndDate.Location = new Point(218, 41);
			dtpEndDate.Name = "dtpEndDate";
			dtpEndDate.Size = new Size(200, 23);
			dtpEndDate.TabIndex = 2;
			// 
			// cmbClient
			// 
			cmbClient.FormattingEnabled = true;
			cmbClient.Location = new Point(12, 70);
			cmbClient.Name = "cmbClient";
			cmbClient.Size = new Size(121, 23);
			cmbClient.TabIndex = 3;
			cmbClient.Text = "Клиент";
			// 
			// cmbExecutor
			// 
			cmbExecutor.FormattingEnabled = true;
			cmbExecutor.Location = new Point(12, 99);
			cmbExecutor.Name = "cmbExecutor";
			cmbExecutor.Size = new Size(121, 23);
			cmbExecutor.TabIndex = 4;
			cmbExecutor.Text = "Исполнитель";
			// 
			// dgvServices
			// 
			dgvServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvServices.Location = new Point(12, 128);
			dgvServices.Name = "dgvServices";
			dgvServices.Size = new Size(776, 150);
			dgvServices.TabIndex = 5;
			// 
			// btnSave
			// 
			btnSave.Location = new Point(12, 284);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(75, 23);
			btnSave.TabIndex = 6;
			btnSave.Text = "Сохранить";
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += btnSave_Click;
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(93, 284);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 7;
			btnCancel.Text = "Отмена";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// ContractAddForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(btnCancel);
			Controls.Add(btnSave);
			Controls.Add(dgvServices);
			Controls.Add(cmbExecutor);
			Controls.Add(cmbClient);
			Controls.Add(dtpEndDate);
			Controls.Add(dtpStartDate);
			Controls.Add(txtTotalAmount);
			Name = "ContractAddForm";
			Text = "ContractAddForm";
			((System.ComponentModel.ISupportInitialize)dgvServices).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox txtTotalAmount;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private ComboBox cmbClient;
        private ComboBox cmbExecutor;
        private DataGridView dgvServices;
        private Button btnSave;
        private Button btnCancel;
    }
}