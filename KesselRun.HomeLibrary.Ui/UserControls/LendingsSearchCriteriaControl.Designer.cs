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
            this.btnExecuteSearch = new System.Windows.Forms.Button();
            this.radByBorrower = new System.Windows.Forms.RadioButton();
            this.radByTitle = new System.Windows.Forms.RadioButton();
            this.txtSearchFilter = new System.Windows.Forms.TextBox();
            this.grpSearchGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSearchGroup
            // 
            this.grpSearchGroup.Controls.Add(this.btnExecuteSearch);
            this.grpSearchGroup.Controls.Add(this.radByBorrower);
            this.grpSearchGroup.Controls.Add(this.radByTitle);
            this.grpSearchGroup.Controls.Add(this.txtSearchFilter);
            this.grpSearchGroup.Location = new System.Drawing.Point(4, 4);
            this.grpSearchGroup.Name = "grpSearchGroup";
            this.grpSearchGroup.Size = new System.Drawing.Size(493, 84);
            this.grpSearchGroup.TabIndex = 0;
            this.grpSearchGroup.TabStop = false;
            this.grpSearchGroup.Text = "Search";
            // 
            // btnExecuteSearch
            // 
            this.btnExecuteSearch.Location = new System.Drawing.Point(353, 53);
            this.btnExecuteSearch.Name = "btnExecuteSearch";
            this.btnExecuteSearch.Size = new System.Drawing.Size(75, 23);
            this.btnExecuteSearch.TabIndex = 3;
            this.btnExecuteSearch.Text = "&Search";
            this.btnExecuteSearch.UseVisualStyleBackColor = true;
            this.btnExecuteSearch.Click += new System.EventHandler(this.btnExecuteSearch_Click);
            // 
            // radByBorrower
            // 
            this.radByBorrower.AutoSize = true;
            this.radByBorrower.Location = new System.Drawing.Point(232, 43);
            this.radByBorrower.Name = "radByBorrower";
            this.radByBorrower.Size = new System.Drawing.Size(82, 17);
            this.radByBorrower.TabIndex = 2;
            this.radByBorrower.Text = "By Borrower";
            this.radByBorrower.UseVisualStyleBackColor = true;
            // 
            // radByTitle
            // 
            this.radByTitle.AutoSize = true;
            this.radByTitle.Checked = true;
            this.radByTitle.Location = new System.Drawing.Point(232, 20);
            this.radByTitle.Name = "radByTitle";
            this.radByTitle.Size = new System.Drawing.Size(60, 17);
            this.radByTitle.TabIndex = 1;
            this.radByTitle.TabStop = true;
            this.radByTitle.Text = "By Title";
            this.radByTitle.UseVisualStyleBackColor = true;
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
        private System.Windows.Forms.RadioButton radByBorrower;
        private System.Windows.Forms.RadioButton radByTitle;
        private System.Windows.Forms.Button btnExecuteSearch;
    }
}
