namespace KesselRun.HomeLibrary.Ui.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MainContentPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPeople = new System.Windows.Forms.Button();
            this.btnBooks = new System.Windows.Forms.Button();
            this.btnLendings = new System.Windows.Forms.Button();
            this.lstMainViewLog = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlTopArea = new System.Windows.Forms.Panel();
            this.lendingsSearchCriteriaControl1 = new KesselRun.HomeLibrary.Ui.UserControls.LendingsSearchCriteriaControl();
            this.logDisplayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.pnlTopArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logDisplayBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MainContentPanel
            // 
            this.MainContentPanel.BackColor = System.Drawing.SystemColors.Menu;
            this.MainContentPanel.Location = new System.Drawing.Point(12, 229);
            this.MainContentPanel.Margin = new System.Windows.Forms.Padding(6);
            this.MainContentPanel.Name = "MainContentPanel";
            this.MainContentPanel.Size = new System.Drawing.Size(2140, 576);
            this.MainContentPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPeople);
            this.panel1.Controls.Add(this.btnBooks);
            this.panel1.Controls.Add(this.btnLendings);
            this.panel1.Location = new System.Drawing.Point(8, 25);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 192);
            this.panel1.TabIndex = 1;
            // 
            // btnPeople
            // 
            this.btnPeople.Location = new System.Drawing.Point(16, 125);
            this.btnPeople.Margin = new System.Windows.Forms.Padding(6);
            this.btnPeople.Name = "btnPeople";
            this.btnPeople.Size = new System.Drawing.Size(236, 44);
            this.btnPeople.TabIndex = 2;
            this.btnPeople.Text = "People";
            this.btnPeople.UseVisualStyleBackColor = true;
            this.btnPeople.Click += new System.EventHandler(this.btnPeople_Click);
            // 
            // btnBooks
            // 
            this.btnBooks.Location = new System.Drawing.Point(16, 69);
            this.btnBooks.Margin = new System.Windows.Forms.Padding(6);
            this.btnBooks.Name = "btnBooks";
            this.btnBooks.Size = new System.Drawing.Size(236, 44);
            this.btnBooks.TabIndex = 1;
            this.btnBooks.Text = "Books";
            this.btnBooks.UseVisualStyleBackColor = true;
            this.btnBooks.Click += new System.EventHandler(this.btnBooks_Click);
            // 
            // btnLendings
            // 
            this.btnLendings.Location = new System.Drawing.Point(16, 19);
            this.btnLendings.Margin = new System.Windows.Forms.Padding(6);
            this.btnLendings.Name = "btnLendings";
            this.btnLendings.Size = new System.Drawing.Size(236, 44);
            this.btnLendings.TabIndex = 0;
            this.btnLendings.Text = "LendingsViewModel";
            this.btnLendings.UseVisualStyleBackColor = true;
            this.btnLendings.Click += new System.EventHandler(this.btnLendings_Click);
            // 
            // lstMainViewLog
            // 
            this.lstMainViewLog.FormattingEnabled = true;
            this.lstMainViewLog.ItemHeight = 25;
            this.lstMainViewLog.Location = new System.Drawing.Point(12, 824);
            this.lstMainViewLog.Margin = new System.Windows.Forms.Padding(6);
            this.lstMainViewLog.Name = "lstMainViewLog";
            this.lstMainViewLog.Size = new System.Drawing.Size(2134, 179);
            this.lstMainViewLog.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(2002, 1018);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 44);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "&Close App";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlTopArea
            // 
            this.pnlTopArea.Controls.Add(this.lendingsSearchCriteriaControl1);
            this.pnlTopArea.Location = new System.Drawing.Point(288, 25);
            this.pnlTopArea.Margin = new System.Windows.Forms.Padding(6);
            this.pnlTopArea.Name = "pnlTopArea";
            this.pnlTopArea.Size = new System.Drawing.Size(1862, 192);
            this.pnlTopArea.TabIndex = 5;
            // 
            // lendingsSearchCriteriaControl1
            // 
            this.lendingsSearchCriteriaControl1.Location = new System.Drawing.Point(838, 10);
            this.lendingsSearchCriteriaControl1.Margin = new System.Windows.Forms.Padding(12);
            this.lendingsSearchCriteriaControl1.Name = "lendingsSearchCriteriaControl1";
            this.lendingsSearchCriteriaControl1.SearchLendingsViewModel = null;
            this.lendingsSearchCriteriaControl1.Size = new System.Drawing.Size(1000, 173);
            this.lendingsSearchCriteriaControl1.TabIndex = 0;
            // 
            // logDisplayBindingSource
            // 
            this.logDisplayBindingSource.DataSource = typeof(KesselRun.HomeLibrary.UiModel.ViewModels.MainViewModel);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2174, 1079);
            this.Controls.Add(this.pnlTopArea);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lstMainViewLog);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MainContentPanel);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainForm";
            this.Text = "Home Library";
            this.panel1.ResumeLayout(false);
            this.pnlTopArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logDisplayBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainContentPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPeople;
        private System.Windows.Forms.Button btnBooks;
        private System.Windows.Forms.Button btnLendings;
        private System.Windows.Forms.ListBox lstMainViewLog;
        private System.Windows.Forms.BindingSource logDisplayBindingSource;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlTopArea;
        private UserControls.LendingsSearchCriteriaControl lendingsSearchCriteriaControl1;
    }
}

