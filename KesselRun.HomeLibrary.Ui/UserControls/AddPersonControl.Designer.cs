namespace KesselRun.HomeLibrary.Ui.UserControls
{
    partial class AddPersonControl
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
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.chkIsAuthor = new System.Windows.Forms.CheckBox();
            this.lblSobriquet = new System.Windows.Forms.Label();
            this.txtSobriquet = new System.Windows.Forms.TextBox();
            this.btnAddPersonButton = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(21, 21);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(60, 13);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(91, 17);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtFirstName.TabIndex = 5;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(91, 54);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 20);
            this.txtLastName.TabIndex = 6;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(20, 58);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 7;
            this.lblLastName.Text = "Last Name:";
            // 
            // txtEmail
            // 
            this.txtEmail.AcceptsReturn = true;
            this.txtEmail.Location = new System.Drawing.Point(91, 91);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 8;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(46, 95);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "Email:";
            // 
            // chkIsAuthor
            // 
            this.chkIsAuthor.AutoSize = true;
            this.chkIsAuthor.Location = new System.Drawing.Point(91, 128);
            this.chkIsAuthor.Name = "chkIsAuthor";
            this.chkIsAuthor.Size = new System.Drawing.Size(68, 17);
            this.chkIsAuthor.TabIndex = 10;
            this.chkIsAuthor.Text = "Is Author";
            this.chkIsAuthor.UseVisualStyleBackColor = true;
            // 
            // lblSobriquet
            // 
            this.lblSobriquet.AutoSize = true;
            this.lblSobriquet.Location = new System.Drawing.Point(26, 166);
            this.lblSobriquet.Name = "lblSobriquet";
            this.lblSobriquet.Size = new System.Drawing.Size(55, 13);
            this.lblSobriquet.TabIndex = 11;
            this.lblSobriquet.Text = "Sobriquet:";
            // 
            // txtSobriquet
            // 
            this.txtSobriquet.AcceptsReturn = true;
            this.txtSobriquet.Location = new System.Drawing.Point(91, 162);
            this.txtSobriquet.Name = "txtSobriquet";
            this.txtSobriquet.Size = new System.Drawing.Size(100, 20);
            this.txtSobriquet.TabIndex = 12;
            // 
            // btnAddPersonButton
            // 
            this.btnAddPersonButton.Location = new System.Drawing.Point(104, 199);
            this.btnAddPersonButton.Name = "btnAddPersonButton";
            this.btnAddPersonButton.Size = new System.Drawing.Size(75, 23);
            this.btnAddPersonButton.TabIndex = 13;
            this.btnAddPersonButton.Text = "&Add Person";
            this.btnAddPersonButton.UseVisualStyleBackColor = true;
            this.btnAddPersonButton.Click += new System.EventHandler(this.btnAddPersonButton_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(104, 224);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // AddPersonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddPersonButton);
            this.Controls.Add(this.txtSobriquet);
            this.Controls.Add(this.lblSobriquet);
            this.Controls.Add(this.chkIsAuthor);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Location = new System.Drawing.Point(200, 0);
            this.Name = "AddPersonControl";
            this.Size = new System.Drawing.Size(224, 262);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.CheckBox chkIsAuthor;
        private System.Windows.Forms.Label lblSobriquet;
        private System.Windows.Forms.TextBox txtSobriquet;
        private System.Windows.Forms.Button btnAddPersonButton;
        private System.Windows.Forms.Button btnClose;
    }
}
