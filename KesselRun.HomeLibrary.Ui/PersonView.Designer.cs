namespace KesselRun.HomeLibrary.Ui
{
    partial class PersonView
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
            this.dgvPersons = new System.Windows.Forms.DataGridView();
            this.dgvcFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcIsAuthor = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvcSobriquet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvcEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvcPersonId = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvcIsAuthorNonVisible = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersons)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPersons
            // 
            this.dgvPersons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcFirstName,
            this.dgvcLastName,
            this.dgvcEmail,
            this.dgvcIsAuthor,
            this.dgvcSobriquet,
            this.dgvcDelete,
            this.dgvcEdit,
            this.dgvcPersonId,
            this.dgvcIsAuthorNonVisible});
            this.dgvPersons.Location = new System.Drawing.Point(12, 59);
            this.dgvPersons.Name = "dgvPersons";
            this.dgvPersons.Size = new System.Drawing.Size(833, 150);
            this.dgvPersons.TabIndex = 0;
            this.dgvPersons.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPersons_CellFormatting);
            // 
            // dgvcFirstName
            // 
            this.dgvcFirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvcFirstName.DataPropertyName = "FirstName";
            this.dgvcFirstName.HeaderText = "First Name";
            this.dgvcFirstName.Name = "dgvcFirstName";
            this.dgvcFirstName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgvcFirstName.ToolTipText = "First Name";
            // 
            // dgvcLastName
            // 
            this.dgvcLastName.DataPropertyName = "LastName";
            this.dgvcLastName.HeaderText = "Last Name";
            this.dgvcLastName.Name = "dgvcLastName";
            this.dgvcLastName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dgvcLastName.ToolTipText = "Last Name";
            // 
            // dgvcEmail
            // 
            this.dgvcEmail.DataPropertyName = "Email";
            this.dgvcEmail.HeaderText = "Email";
            this.dgvcEmail.Name = "dgvcEmail";
            this.dgvcEmail.ToolTipText = "Email address";
            // 
            // dgvcIsAuthor
            // 
            this.dgvcIsAuthor.DataPropertyName = "IsAuthor";
            this.dgvcIsAuthor.HeaderText = "Is Author";
            this.dgvcIsAuthor.Name = "dgvcIsAuthor";
            this.dgvcIsAuthor.ToolTipText = "Is an author";
            // 
            // dgvcSobriquet
            // 
            this.dgvcSobriquet.DataPropertyName = "Sobriquet";
            this.dgvcSobriquet.HeaderText = "Sobriquet";
            this.dgvcSobriquet.Name = "dgvcSobriquet";
            this.dgvcSobriquet.ToolTipText = "Nickname";
            // 
            // dgvcDelete
            // 
            this.dgvcDelete.HeaderText = "Delete";
            this.dgvcDelete.Name = "dgvcDelete";
            this.dgvcDelete.ReadOnly = true;
            this.dgvcDelete.ToolTipText = "Erase person";
            // 
            // dgvcEdit
            // 
            this.dgvcEdit.HeaderText = "Edit";
            this.dgvcEdit.Name = "dgvcEdit";
            this.dgvcEdit.ReadOnly = true;
            this.dgvcEdit.ToolTipText = "Edit a person\'s details";
            this.dgvcEdit.Width = 190;
            // 
            // dgvcPersonId
            // 
            this.dgvcPersonId.DataPropertyName = "Id";
            this.dgvcPersonId.HeaderText = "PersonId";
            this.dgvcPersonId.Name = "dgvcPersonId";
            this.dgvcPersonId.ReadOnly = true;
            this.dgvcPersonId.Visible = false;
            // 
            // dgvcIsAuthorNonVisible
            // 
            this.dgvcIsAuthorNonVisible.HeaderText = "Author Non Visible";
            this.dgvcIsAuthorNonVisible.Name = "dgvcIsAuthorNonVisible";
            this.dgvcIsAuthorNonVisible.ReadOnly = true;
            this.dgvcIsAuthorNonVisible.Visible = false;
            // 
            // PersonView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.Controls.Add(this.dgvPersons);
            this.Name = "PersonView";
            this.Text = "Person View";
            this.Load += new System.EventHandler(this.PersonView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersons)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPersons;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcEmail;
        private System.Windows.Forms.DataGridViewImageColumn dgvcIsAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcSobriquet;
        private System.Windows.Forms.DataGridViewImageColumn dgvcDelete;
        private System.Windows.Forms.DataGridViewImageColumn dgvcEdit;
        private System.Windows.Forms.DataGridViewImageColumn dgvcPersonId;
        private System.Windows.Forms.DataGridViewImageColumn dgvcIsAuthorNonVisible;
    }
}

