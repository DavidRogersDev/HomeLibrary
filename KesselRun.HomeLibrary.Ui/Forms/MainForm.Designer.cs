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
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainContentPanel
            // 
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 499);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MainContentPanel);
            this.Name = "MainForm";
            this.Text = "Home Library";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainContentPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPeople;
        private System.Windows.Forms.Button btnBooks;
        private System.Windows.Forms.Button btnLendings;
    }
}

