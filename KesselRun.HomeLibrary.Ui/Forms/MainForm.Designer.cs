namespace KesselRun.HomeLibrary.Ui.Forms
{
    partial class MainForm
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
            this.MainContentPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLendings = new System.Windows.Forms.Button();
            this.btnBooks = new System.Windows.Forms.Button();
            this.btnPeople = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgvlcTitle = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dgvlcAuthor = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dgvlcBorrower = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dgvlcEmail = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dgvicReturn = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvtcDateLent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtcDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtcDateDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainContentPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainContentPanel
            // 
            this.MainContentPanel.Controls.Add(this.dataGridView1);
            this.MainContentPanel.Location = new System.Drawing.Point(101, 13);
            this.MainContentPanel.Name = "MainContentPanel";
            this.MainContentPanel.Size = new System.Drawing.Size(859, 372);
            this.MainContentPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPeople);
            this.panel1.Controls.Add(this.btnBooks);
            this.panel1.Controls.Add(this.btnLendings);
            this.panel1.Location = new System.Drawing.Point(4, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(91, 100);
            this.panel1.TabIndex = 1;
            // 
            // btnLendings
            // 
            this.btnLendings.Location = new System.Drawing.Point(8, 10);
            this.btnLendings.Name = "btnLendings";
            this.btnLendings.Size = new System.Drawing.Size(75, 23);
            this.btnLendings.TabIndex = 0;
            this.btnLendings.Text = "Lendings";
            this.btnLendings.UseVisualStyleBackColor = true;
            // 
            // btnBooks
            // 
            this.btnBooks.Location = new System.Drawing.Point(8, 36);
            this.btnBooks.Name = "btnBooks";
            this.btnBooks.Size = new System.Drawing.Size(75, 23);
            this.btnBooks.TabIndex = 1;
            this.btnBooks.Text = "Books";
            this.btnBooks.UseVisualStyleBackColor = true;
            // 
            // btnPeople
            // 
            this.btnPeople.Location = new System.Drawing.Point(8, 65);
            this.btnPeople.Name = "btnPeople";
            this.btnPeople.Size = new System.Drawing.Size(75, 23);
            this.btnPeople.TabIndex = 2;
            this.btnPeople.Text = "People";
            this.btnPeople.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvlcTitle,
            this.dgvlcAuthor,
            this.dgvlcBorrower,
            this.dgvlcEmail,
            this.dgvicReturn,
            this.dgvtcDateLent,
            this.dgvtcDuration,
            this.dgvtcDateDue});
            this.dataGridView1.Location = new System.Drawing.Point(3, 101);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(853, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // dgvlcTitle
            // 
            this.dgvlcTitle.DataPropertyName = "Title";
            this.dgvlcTitle.HeaderText = "Title";
            this.dgvlcTitle.Name = "dgvlcTitle";
            // 
            // dgvlcAuthor
            // 
            this.dgvlcAuthor.DataPropertyName = "Author";
            this.dgvlcAuthor.HeaderText = "Author";
            this.dgvlcAuthor.Name = "dgvlcAuthor";
            // 
            // dgvlcBorrower
            // 
            this.dgvlcBorrower.DataPropertyName = "Borrower";
            this.dgvlcBorrower.HeaderText = "Borrower";
            this.dgvlcBorrower.Name = "dgvlcBorrower";
            // 
            // dgvlcEmail
            // 
            this.dgvlcEmail.DataPropertyName = "Email";
            this.dgvlcEmail.HeaderText = "Email";
            this.dgvlcEmail.Name = "dgvlcEmail";
            // 
            // dgvicReturn
            // 
            this.dgvicReturn.HeaderText = "Return";
            this.dgvicReturn.Name = "dgvicReturn";
            // 
            // dgvtcDateLent
            // 
            this.dgvtcDateLent.DataPropertyName = "DateLent";
            this.dgvtcDateLent.HeaderText = "Date Lent";
            this.dgvtcDateLent.Name = "dgvtcDateLent";
            // 
            // dgvtcDuration
            // 
            this.dgvtcDuration.DataPropertyName = "Duration";
            this.dgvtcDuration.FillWeight = 50F;
            this.dgvtcDuration.HeaderText = "Duration";
            this.dgvtcDuration.Name = "dgvtcDuration";
            // 
            // dgvtcDateDue
            // 
            this.dgvtcDateDue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvtcDateDue.DataPropertyName = "DateDue";
            this.dgvtcDateDue.HeaderText = "Date Due";
            this.dgvtcDateDue.Name = "dgvtcDateDue";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 499);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MainContentPanel);
            this.Name = "MainForm";
            this.Text = "Home Library";
            this.MainContentPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainContentPanel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewLinkColumn dgvlcTitle;
        private System.Windows.Forms.DataGridViewLinkColumn dgvlcAuthor;
        private System.Windows.Forms.DataGridViewLinkColumn dgvlcBorrower;
        private System.Windows.Forms.DataGridViewLinkColumn dgvlcEmail;
        private System.Windows.Forms.DataGridViewImageColumn dgvicReturn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtcDateLent;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtcDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtcDateDue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPeople;
        private System.Windows.Forms.Button btnBooks;
        private System.Windows.Forms.Button btnLendings;
    }
}

