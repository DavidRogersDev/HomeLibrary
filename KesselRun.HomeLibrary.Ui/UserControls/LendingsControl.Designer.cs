namespace KesselRun.HomeLibrary.Ui.UserControls
{
    partial class LendingsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvLendings = new System.Windows.Forms.DataGridView();
            this.dgvlcTitle = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dgvlcBorrower = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dgvlcEmail = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dgvicReturn = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvtcDateLent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtcDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtcDateDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvlcAuthor = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLendings)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLendings
            // 
            this.dgvLendings.AllowUserToAddRows = false;
            this.dgvLendings.AllowUserToOrderColumns = true;
            this.dgvLendings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLendings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvlcTitle,
            this.dgvlcBorrower,
            this.dgvlcEmail,
            this.dgvicReturn,
            this.dgvtcDateLent,
            this.dgvtcDuration,
            this.dgvtcDateDue,
            this.dgvlcAuthor});
            this.dgvLendings.Location = new System.Drawing.Point(0, 0);
            this.dgvLendings.Name = "dgvLendings";
            this.dgvLendings.Size = new System.Drawing.Size(1040, 150);
            this.dgvLendings.TabIndex = 1;
            // 
            // dgvlcTitle
            // 
            this.dgvlcTitle.DataPropertyName = "Title";
            this.dgvlcTitle.HeaderText = "Title";
            this.dgvlcTitle.Name = "dgvlcTitle";
            this.dgvlcTitle.ToolTipText = "Title";
            // 
            // dgvlcBorrower
            // 
            this.dgvlcBorrower.DataPropertyName = "Borrower";
            this.dgvlcBorrower.HeaderText = "Borrower";
            this.dgvlcBorrower.Name = "dgvlcBorrower";
            this.dgvlcBorrower.ToolTipText = "Borrower";
            // 
            // dgvlcEmail
            // 
            this.dgvlcEmail.DataPropertyName = "Email";
            this.dgvlcEmail.HeaderText = "Email";
            this.dgvlcEmail.Name = "dgvlcEmail";
            this.dgvlcEmail.ToolTipText = "Email";
            // 
            // dgvicReturn
            // 
            this.dgvicReturn.DataPropertyName = "ReturnDate";
            this.dgvicReturn.HeaderText = "Return";
            this.dgvicReturn.Name = "dgvicReturn";
            this.dgvicReturn.ToolTipText = "Return Book";
            // 
            // dgvtcDateLent
            // 
            this.dgvtcDateLent.DataPropertyName = "DateLent";
            this.dgvtcDateLent.HeaderText = "Date Lent";
            this.dgvtcDateLent.Name = "dgvtcDateLent";
            this.dgvtcDateLent.ToolTipText = "Book Lent On";
            // 
            // dgvtcDuration
            // 
            this.dgvtcDuration.DataPropertyName = "Duration";
            this.dgvtcDuration.FillWeight = 50F;
            this.dgvtcDuration.HeaderText = "Duration";
            this.dgvtcDuration.Name = "dgvtcDuration";
            this.dgvtcDuration.ToolTipText = "Loan Duration";
            // 
            // dgvtcDateDue
            // 
            this.dgvtcDateDue.DataPropertyName = "DueDate";
            this.dgvtcDateDue.HeaderText = "Date Due";
            this.dgvtcDateDue.Name = "dgvtcDateDue";
            this.dgvtcDateDue.ToolTipText = "Due Date for the Book";
            // 
            // dgvlcAuthor
            // 
            this.dgvlcAuthor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvlcAuthor.DataPropertyName = "Authors";
            this.dgvlcAuthor.HeaderText = "Author/s";
            this.dgvlcAuthor.Name = "dgvlcAuthor";
            this.dgvlcAuthor.ToolTipText = "Authors";
            // 
            // LendingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvLendings);
            this.Name = "LendingsControl";
            this.Size = new System.Drawing.Size(1050, 202);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLendings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLendings;
        private System.Windows.Forms.DataGridViewLinkColumn dgvlcTitle;
        private System.Windows.Forms.DataGridViewLinkColumn dgvlcBorrower;
        private System.Windows.Forms.DataGridViewLinkColumn dgvlcEmail;
        private System.Windows.Forms.DataGridViewImageColumn dgvicReturn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtcDateLent;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtcDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtcDateDue;
        private System.Windows.Forms.DataGridViewLinkColumn dgvlcAuthor;

    }
}
