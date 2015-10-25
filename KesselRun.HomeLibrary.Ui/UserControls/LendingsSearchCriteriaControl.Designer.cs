namespace KesselRun.HomeLibrary.Ui.UserControls
{
    partial class LendingsSearchCriteriaControl
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
            this.grpSearchGroup = new System.Windows.Forms.GroupBox();
            this.cboBorrowers = new System.Windows.Forms.ComboBox();
            this.chkByAuthor = new System.Windows.Forms.CheckBox();
            this.chkByEmail = new System.Windows.Forms.CheckBox();
            this.chkByTitle = new System.Windows.Forms.CheckBox();
            this.btnExecuteSearch = new System.Windows.Forms.Button();
            this.txtSearchFilter = new System.Windows.Forms.TextBox();
            this.grpSearchGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSearchGroup
            // 
            this.grpSearchGroup.Controls.Add(this.cboBorrowers);
            this.grpSearchGroup.Controls.Add(this.chkByAuthor);
            this.grpSearchGroup.Controls.Add(this.chkByEmail);
            this.grpSearchGroup.Controls.Add(this.chkByTitle);
            this.grpSearchGroup.Controls.Add(this.btnExecuteSearch);
            this.grpSearchGroup.Controls.Add(this.txtSearchFilter);
            this.grpSearchGroup.Location = new System.Drawing.Point(4, 4);
            this.grpSearchGroup.Name = "grpSearchGroup";
            this.grpSearchGroup.Size = new System.Drawing.Size(493, 93);
            this.grpSearchGroup.TabIndex = 0;
            this.grpSearchGroup.TabStop = false;
            this.grpSearchGroup.Text = "Search";
            // 
            // cboBorrowers
            // 
            this.cboBorrowers.FormattingEnabled = true;
            this.cboBorrowers.Location = new System.Drawing.Point(238, 19);
            this.cboBorrowers.Name = "cboBorrowers";
            this.cboBorrowers.Size = new System.Drawing.Size(206, 21);
            this.cboBorrowers.TabIndex = 8;
            // 
            // chkByAuthor
            // 
            this.chkByAuthor.AutoSize = true;
            this.chkByAuthor.Location = new System.Drawing.Point(372, 44);
            this.chkByAuthor.Name = "chkByAuthor";
            this.chkByAuthor.Size = new System.Drawing.Size(72, 17);
            this.chkByAuthor.TabIndex = 7;
            this.chkByAuthor.Tag = "Author";
            this.chkByAuthor.Text = "By Author";
            this.chkByAuthor.UseVisualStyleBackColor = true;
            // 
            // chkByEmail
            // 
            this.chkByEmail.AutoSize = true;
            this.chkByEmail.Location = new System.Drawing.Point(238, 65);
            this.chkByEmail.Name = "chkByEmail";
            this.chkByEmail.Size = new System.Drawing.Size(66, 17);
            this.chkByEmail.TabIndex = 6;
            this.chkByEmail.Tag = "Borrower.Email";
            this.chkByEmail.Text = "By Email";
            this.chkByEmail.UseVisualStyleBackColor = true;
            // 
            // chkByTitle
            // 
            this.chkByTitle.AutoSize = true;
            this.chkByTitle.Location = new System.Drawing.Point(238, 44);
            this.chkByTitle.Name = "chkByTitle";
            this.chkByTitle.Size = new System.Drawing.Size(61, 17);
            this.chkByTitle.TabIndex = 5;
            this.chkByTitle.Tag = "Book.Title";
            this.chkByTitle.Text = "By Title";
            this.chkByTitle.UseVisualStyleBackColor = true;
            // 
            // btnExecuteSearch
            // 
            this.btnExecuteSearch.Location = new System.Drawing.Point(372, 65);
            this.btnExecuteSearch.Name = "btnExecuteSearch";
            this.btnExecuteSearch.Size = new System.Drawing.Size(75, 23);
            this.btnExecuteSearch.TabIndex = 3;
            this.btnExecuteSearch.Text = "&Search";
            this.btnExecuteSearch.UseVisualStyleBackColor = true;
            this.btnExecuteSearch.Click += new System.EventHandler(this.btnExecuteSearch_Click);
            // 
            // txtSearchFilter
            // 
            this.txtSearchFilter.Location = new System.Drawing.Point(6, 19);
            this.txtSearchFilter.Name = "txtSearchFilter";
            this.txtSearchFilter.Size = new System.Drawing.Size(210, 20);
            this.txtSearchFilter.TabIndex = 0;
            // 
            // LendingsSearchCriteriaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpSearchGroup);
            this.Name = "LendingsSearchCriteriaControl";
            this.Size = new System.Drawing.Size(500, 100);
            this.grpSearchGroup.ResumeLayout(false);
            this.grpSearchGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSearchGroup;
        private System.Windows.Forms.TextBox txtSearchFilter;
        private System.Windows.Forms.Button btnExecuteSearch;
        private System.Windows.Forms.CheckBox chkByAuthor;
        private System.Windows.Forms.CheckBox chkByEmail;
        private System.Windows.Forms.CheckBox chkByTitle;
        private System.Windows.Forms.ComboBox cboBorrowers;
    }
}
