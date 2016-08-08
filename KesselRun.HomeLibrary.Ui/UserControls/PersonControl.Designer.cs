namespace KesselRun.HomeLibrary.Ui.UserControls
{
    partial class PersonControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.dgvtcId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtcEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtcFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtcSobriquet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtcIsAuthor = new System.Windows.Forms.DataGridViewImageColumn();
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
            this.dgvPager.NextPageSubmitted += new System.EventHandler<KesselRun.HomeLibrary.Ui.CustomControls.EventArgs.PagedEventArgs>(this.dgvPager_PageChanged);
            this.dgvPager.PageSizeChangeSubmitted += new System.EventHandler<KesselRun.HomeLibrary.Ui.CustomControls.EventArgs.PagedEventArgs>(this.dgvPager_PageSizeChanged);
            this.dgvPager.PreviousPageSubmitted += new System.EventHandler<KesselRun.HomeLibrary.Ui.CustomControls.EventArgs.PagedEventArgs>(this.dgvPager_PageChanged);
            // 
            // dgvPeople
            // 
            this.dgvPeople.AllowUserToAddRows = false;
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeople.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvtcId,
            this.dgvtcEmail,
            this.dgvtcFullName,
            this.dgvtcSobriquet,
            this.dgvtcIsAuthor});
            this.dgvPeople.Location = new System.Drawing.Point(4, 4);
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.Size = new System.Drawing.Size(1040, 150);
            this.dgvPeople.TabIndex = 1;
            this.dgvPeople.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPeople_CellFormatting);
            // 
            // dgvtcId
            // 
            this.dgvtcId.HeaderText = "Id";
            this.dgvtcId.Name = "dgvtcId";
            this.dgvtcId.Visible = false;
            // 
            // dgvtcEmail
            // 
            this.dgvtcEmail.DataPropertyName = "Email";
            this.dgvtcEmail.HeaderText = "Email";
            this.dgvtcEmail.Name = "dgvtcEmail";
            // 
            // dgvtcFullName
            // 
            this.dgvtcFullName.DataPropertyName = "FullName";
            this.dgvtcFullName.HeaderText = "FullName";
            this.dgvtcFullName.Name = "dgvtcFullName";
            // 
            // dgvtcSobriquet
            // 
            this.dgvtcSobriquet.DataPropertyName = "Sobriquet";
            this.dgvtcSobriquet.HeaderText = "Sobriquet";
            this.dgvtcSobriquet.Name = "dgvtcSobriquet";
            this.dgvtcSobriquet.Width = 200;
            // 
            // dgvtcIsAuthor
            // 
            this.dgvtcIsAuthor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvtcIsAuthor.DataPropertyName = "IsAuthor";
            this.dgvtcIsAuthor.HeaderText = "IsAuthor";
            this.dgvtcIsAuthor.Name = "dgvtcIsAuthor";
            this.dgvtcIsAuthor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvtcIsAuthor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtcId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtcEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtcFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtcSobriquet;
        private System.Windows.Forms.DataGridViewImageColumn dgvtcIsAuthor;
    }
}
