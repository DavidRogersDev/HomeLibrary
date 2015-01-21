namespace KesselRun.HomeLibrary.Ui.CustomControls
{
    partial class DataGridViewPager
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
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.txtPageNumber = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboPageSize = new System.Windows.Forms.ComboBox();
            this.lblOf = new System.Windows.Forms.Label();
            this.lblTotalNumberPages = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Location = new System.Drawing.Point(4, 4);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(107, 23);
            this.btnPreviousPage.TabIndex = 0;
            this.btnPreviousPage.Text = "Previous Page";
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            this.btnPreviousPage.Click += new System.EventHandler(this.pageChange_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(269, 4);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(107, 23);
            this.btnNextPage.TabIndex = 1;
            this.btnNextPage.Text = "Next Page";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.pageChange_Click);
            // 
            // txtPageNumber
            // 
            this.txtPageNumber.Location = new System.Drawing.Point(3, 3);
            this.txtPageNumber.Name = "txtPageNumber";
            this.txtPageNumber.Size = new System.Drawing.Size(36, 20);
            this.txtPageNumber.TabIndex = 2;
            this.txtPageNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPageNumber_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.lblTotalNumberPages);
            this.panel1.Controls.Add(this.cboPageSize);
            this.panel1.Controls.Add(this.lblOf);
            this.panel1.Controls.Add(this.txtPageNumber);
            this.panel1.Location = new System.Drawing.Point(114, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(148, 26);
            this.panel1.TabIndex = 3;
            // 
            // cboPageSize
            // 
            this.cboPageSize.FormattingEnabled = true;
            this.cboPageSize.Location = new System.Drawing.Point(98, 2);
            this.cboPageSize.Name = "cboPageSize";
            this.cboPageSize.Size = new System.Drawing.Size(44, 21);
            this.cboPageSize.TabIndex = 4;
            this.cboPageSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboPageSize_KeyPress);
            // 
            // lblOf
            // 
            this.lblOf.AutoSize = true;
            this.lblOf.Location = new System.Drawing.Point(43, 7);
            this.lblOf.Name = "lblOf";
            this.lblOf.Size = new System.Drawing.Size(16, 13);
            this.lblOf.TabIndex = 3;
            this.lblOf.Text = "of";
            // 
            // lblTotalNumberPages
            // 
            this.lblTotalNumberPages.AutoSize = true;
            this.lblTotalNumberPages.Location = new System.Drawing.Point(66, 7);
            this.lblTotalNumberPages.Name = "lblTotalNumberPages";
            this.lblTotalNumberPages.Size = new System.Drawing.Size(27, 13);
            this.lblTotalNumberPages.TabIndex = 5;
            this.lblTotalNumberPages.Text = "total";
            // 
            // DataGridViewPager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnPreviousPage);
            this.Name = "DataGridViewPager";
            this.Size = new System.Drawing.Size(380, 33);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPageNumber_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.TextBox txtPageNumber;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboPageSize;
        private System.Windows.Forms.Label lblOf;
        private System.Windows.Forms.Label lblTotalNumberPages;
    }
}
