using KesselRun.HomeLibrary.Ui.CustomControls.EventArgs;

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
            this.dgvtcId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvlcTitle = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dgvlcBorrower = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dgvlcEmail = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dgvicReturn = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvtcDateLent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtcDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtcDateDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvlcAuthor = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnAddLending = new System.Windows.Forms.Button();
            this.dgvPager = new KesselRun.HomeLibrary.Ui.CustomControls.DataGridViewPager();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLendings)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLendings
            // 
            this.dgvLendings.AllowUserToAddRows = false;
            this.dgvLendings.AllowUserToOrderColumns = true;
            this.dgvLendings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLendings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvtcId,
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
            this.dgvLendings.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLendings_CellClick);
            this.dgvLendings.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvLendingsCellFormatting);
            // 
            // dgvtcId
            // 
            this.dgvtcId.DataPropertyName = "Id";
            this.dgvtcId.HeaderText = "Id";
            this.dgvtcId.Name = "dgvtcId";
            this.dgvtcId.Visible = false;
            // 
            // dgvlcTitle
            // 
            this.dgvlcTitle.DataPropertyName = "Title";
            this.dgvlcTitle.HeaderText = "Title";
            this.dgvlcTitle.Name = "dgvlcTitle";
            this.dgvlcTitle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgvlcTitle.ToolTipText = "Title";
            // 
            // dgvlcBorrower
            // 
            this.dgvlcBorrower.DataPropertyName = "Borrower";
            this.dgvlcBorrower.HeaderText = "Borrower";
            this.dgvlcBorrower.Name = "dgvlcBorrower";
            this.dgvlcBorrower.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgvlcBorrower.ToolTipText = "Borrower";
            // 
            // dgvlcEmail
            // 
            this.dgvlcEmail.DataPropertyName = "Email";
            this.dgvlcEmail.HeaderText = "Email";
            this.dgvlcEmail.Name = "dgvlcEmail";
            this.dgvlcEmail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
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
            this.dgvtcDateLent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgvtcDateLent.ToolTipText = "Book Lent On";
            // 
            // dgvtcDuration
            // 
            this.dgvtcDuration.DataPropertyName = "Duration";
            this.dgvtcDuration.FillWeight = 50F;
            this.dgvtcDuration.HeaderText = "Duration";
            this.dgvtcDuration.Name = "dgvtcDuration";
            this.dgvtcDuration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgvtcDuration.ToolTipText = "Loan Duration";
            // 
            // dgvtcDateDue
            // 
            this.dgvtcDateDue.DataPropertyName = "DueDate";
            this.dgvtcDateDue.HeaderText = "Date Due";
            this.dgvtcDateDue.Name = "dgvtcDateDue";
            this.dgvtcDateDue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
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
            // btnAddLending
            // 
            this.btnAddLending.Location = new System.Drawing.Point(20, 209);
            this.btnAddLending.Name = "btnAddLending";
            this.btnAddLending.Size = new System.Drawing.Size(75, 23);
            this.btnAddLending.TabIndex = 2;
            this.btnAddLending.Text = "Add Lending";
            this.btnAddLending.UseVisualStyleBackColor = true;
            this.btnAddLending.Click += new System.EventHandler(this.btnAddLending_Click);
            // 
            // dgvPager
            // 
            this.dgvPager.Location = new System.Drawing.Point(4, 157);
            this.dgvPager.Name = "dgvPager";
            this.dgvPager.PageCount = 0;
            this.dgvPager.PageIndex = 1;
            this.dgvPager.PageSize = 2;
            this.dgvPager.PagerIncrement = 2;
            this.dgvPager.Size = new System.Drawing.Size(339, 33);
            this.dgvPager.SortByColumn = "Email";
            this.dgvPager.SortOrder = System.ComponentModel.ListSortDirection.Ascending;
            this.dgvPager.TabIndex = 3;
            this.dgvPager.NextPageSubmitted += new System.EventHandler<KesselRun.HomeLibrary.Ui.CustomControls.EventArgs.PagedEventArgs>(this.dgvPager_PageChanged);
            this.dgvPager.PreviousPageSubmitted += new System.EventHandler<KesselRun.HomeLibrary.Ui.CustomControls.EventArgs.PagedEventArgs>(this.dgvPager_PageChanged);
            // 
            // LendingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvPager);
            this.Controls.Add(this.btnAddLending);
            this.Controls.Add(this.dgvLendings);
            this.Name = "LendingsControl";
            this.Size = new System.Drawing.Size(1050, 248);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLendings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLendings;
        private System.Windows.Forms.Button btnAddLending;
        private CustomControls.DataGridViewPager dgvPager;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtcId;
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
