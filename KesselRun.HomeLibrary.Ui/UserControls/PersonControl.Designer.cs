namespace KesselRun.HomeLibrary.Ui.UserControls
{
    partial class PersonControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPager = new KesselRun.HomeLibrary.Ui.CustomControls.DataGridViewPager();
            this.dgvPeople = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 225);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Doh";
            // 
            // dgvPager
            // 
            this.dgvPager.Location = new System.Drawing.Point(4, 158);
            this.dgvPager.Margin = new System.Windows.Forms.Padding(6);
            this.dgvPager.Name = "dgvPager";
            this.dgvPager.PageCount = 0;
            this.dgvPager.PageIndex = 1;
            this.dgvPager.PagerIncrement = 2;
            this.dgvPager.PageSize = 10;
            this.dgvPager.Size = new System.Drawing.Size(400, 33);
            this.dgvPager.SortByColumn = "LastName";
            this.dgvPager.SortOrder = System.ComponentModel.ListSortDirection.Ascending;
            this.dgvPager.TabIndex = 3;
            this.dgvPager.PageSizeChangeSubmitted += new System.EventHandler<KesselRun.HomeLibrary.Ui.CustomControls.EventArgs.PagedEventArgs>(this.dgvPager_PageSizeChanged);
            this.dgvPager.PreviousPageSubmitted += new System.EventHandler<KesselRun.HomeLibrary.Ui.CustomControls.EventArgs.PagedEventArgs>(this.dgvPager_PageChanged);
            // 
            // dgvPeople
            // 
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeople.Location = new System.Drawing.Point(4, 4);
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.Size = new System.Drawing.Size(1040, 150);
            this.dgvPeople.TabIndex = 1;
            // 
            // PersonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvPeople);
            this.Controls.Add(this.dgvPager);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PersonControl";
            this.Size = new System.Drawing.Size(1050, 248);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPeople;
        private CustomControls.DataGridViewPager dgvPager;
    }
}
