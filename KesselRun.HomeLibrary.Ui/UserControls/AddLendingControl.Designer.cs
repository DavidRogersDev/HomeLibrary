namespace KesselRun.HomeLibrary.Ui.UserControls
{
    partial class AddLendingControl
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
            this.lblBook = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblDateDue = new System.Windows.Forms.Label();
            this.lblDateLent = new System.Windows.Forms.Label();
            this.lblBorrower = new System.Windows.Forms.Label();
            this.cboBorrower = new System.Windows.Forms.ComboBox();
            this.cboBook = new System.Windows.Forms.ComboBox();
            this.dtpDateLent = new System.Windows.Forms.DateTimePicker();
            this.dtpDateDue = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBook
            // 
            this.lblBook.AutoSize = true;
            this.lblBook.Location = new System.Drawing.Point(43, 12);
            this.lblBook.Name = "lblBook";
            this.lblBook.Size = new System.Drawing.Size(35, 13);
            this.lblBook.TabIndex = 0;
            this.lblBook.Text = "Book:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(209, 156);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblDateDue
            // 
            this.lblDateDue.AutoSize = true;
            this.lblDateDue.Location = new System.Drawing.Point(22, 93);
            this.lblDateDue.Name = "lblDateDue";
            this.lblDateDue.Size = new System.Drawing.Size(56, 13);
            this.lblDateDue.TabIndex = 3;
            this.lblDateDue.Text = "Due Date:";
            // 
            // lblDateLent
            // 
            this.lblDateLent.AutoSize = true;
            this.lblDateLent.Location = new System.Drawing.Point(21, 66);
            this.lblDateLent.Name = "lblDateLent";
            this.lblDateLent.Size = new System.Drawing.Size(57, 13);
            this.lblDateLent.TabIndex = 4;
            this.lblDateLent.Text = "Date Lent:";
            // 
            // lblBorrower
            // 
            this.lblBorrower.AutoSize = true;
            this.lblBorrower.Location = new System.Drawing.Point(26, 39);
            this.lblBorrower.Name = "lblBorrower";
            this.lblBorrower.Size = new System.Drawing.Size(52, 13);
            this.lblBorrower.TabIndex = 5;
            this.lblBorrower.Text = "Borrower:";
            // 
            // cboBorrower
            // 
            this.cboBorrower.FormattingEnabled = true;
            this.cboBorrower.Location = new System.Drawing.Point(84, 35);
            this.cboBorrower.Name = "cboBorrower";
            this.cboBorrower.Size = new System.Drawing.Size(121, 21);
            this.cboBorrower.TabIndex = 6;
            // 
            // cboBook
            // 
            this.cboBook.FormattingEnabled = true;
            this.cboBook.Location = new System.Drawing.Point(84, 8);
            this.cboBook.Name = "cboBook";
            this.cboBook.Size = new System.Drawing.Size(121, 21);
            this.cboBook.TabIndex = 7;
            // 
            // dtpDateLent
            // 
            this.dtpDateLent.Location = new System.Drawing.Point(84, 62);
            this.dtpDateLent.Name = "dtpDateLent";
            this.dtpDateLent.Size = new System.Drawing.Size(200, 20);
            this.dtpDateLent.TabIndex = 8;
            // 
            // dtpDateDue
            // 
            this.dtpDateDue.Location = new System.Drawing.Point(84, 89);
            this.dtpDateDue.Name = "dtpDateDue";
            this.dtpDateDue.Size = new System.Drawing.Size(200, 20);
            this.dtpDateDue.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(209, 127);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add Lending";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // AddLendingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dtpDateDue);
            this.Controls.Add(this.dtpDateLent);
            this.Controls.Add(this.cboBook);
            this.Controls.Add(this.cboBorrower);
            this.Controls.Add(this.lblBorrower);
            this.Controls.Add(this.lblDateLent);
            this.Controls.Add(this.lblDateDue);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblBook);
            this.Name = "AddLendingControl";
            this.Size = new System.Drawing.Size(311, 203);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBook;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblDateDue;
        private System.Windows.Forms.Label lblDateLent;
        private System.Windows.Forms.Label lblBorrower;
        private System.Windows.Forms.ComboBox cboBorrower;
        private System.Windows.Forms.ComboBox cboBook;
        private System.Windows.Forms.DateTimePicker dtpDateLent;
        private System.Windows.Forms.DateTimePicker dtpDateDue;
        private System.Windows.Forms.Button btnAdd;
    }
}
