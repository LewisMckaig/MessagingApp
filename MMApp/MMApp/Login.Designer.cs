namespace MMApp
{
    partial class Login
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
            this.uTxtBox = new System.Windows.Forms.TextBox();
            this.pTxtBox = new System.Windows.Forms.TextBox();
            this.uLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loginBtn = new System.Windows.Forms.Button();
            this.createBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toTxtBox = new System.Windows.Forms.TextBox();
            this.talkBtn = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.Label();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uTxtBox
            // 
            this.uTxtBox.Location = new System.Drawing.Point(107, 11);
            this.uTxtBox.Margin = new System.Windows.Forms.Padding(2);
            this.uTxtBox.Name = "uTxtBox";
            this.uTxtBox.Size = new System.Drawing.Size(301, 20);
            this.uTxtBox.TabIndex = 0;
            // 
            // pTxtBox
            // 
            this.pTxtBox.Location = new System.Drawing.Point(107, 46);
            this.pTxtBox.Margin = new System.Windows.Forms.Padding(2);
            this.pTxtBox.Name = "pTxtBox";
            this.pTxtBox.PasswordChar = '*';
            this.pTxtBox.Size = new System.Drawing.Size(301, 20);
            this.pTxtBox.TabIndex = 1;
            // 
            // uLabel
            // 
            this.uLabel.AutoSize = true;
            this.uLabel.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uLabel.Location = new System.Drawing.Point(11, 9);
            this.uLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uLabel.Name = "uLabel";
            this.uLabel.Size = new System.Drawing.Size(74, 19);
            this.uLabel.TabIndex = 2;
            this.uLabel.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(107, 70);
            this.loginBtn.Margin = new System.Windows.Forms.Padding(2);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(92, 26);
            this.loginBtn.TabIndex = 4;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(212, 70);
            this.createBtn.Margin = new System.Windows.Forms.Padding(2);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(92, 26);
            this.createBtn.TabIndex = 5;
            this.createBtn.Text = "Create User";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "User:";
            // 
            // toTxtBox
            // 
            this.toTxtBox.Location = new System.Drawing.Point(108, 105);
            this.toTxtBox.Margin = new System.Windows.Forms.Padding(2);
            this.toTxtBox.Name = "toTxtBox";
            this.toTxtBox.Size = new System.Drawing.Size(301, 20);
            this.toTxtBox.TabIndex = 8;
            // 
            // talkBtn
            // 
            this.talkBtn.Enabled = false;
            this.talkBtn.Location = new System.Drawing.Point(311, 129);
            this.talkBtn.Margin = new System.Windows.Forms.Padding(2);
            this.talkBtn.Name = "talkBtn";
            this.talkBtn.Size = new System.Drawing.Size(92, 26);
            this.talkBtn.TabIndex = 9;
            this.talkBtn.Text = "Talk";
            this.talkBtn.UseVisualStyleBackColor = true;
            this.talkBtn.Click += new System.EventHandler(this.talkBtn_Click);
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.Location = new System.Drawing.Point(16, 178);
            this.status.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 19);
            this.status.TabIndex = 10;
            // 
            // logoutBtn
            // 
            this.logoutBtn.Enabled = false;
            this.logoutBtn.Location = new System.Drawing.Point(317, 70);
            this.logoutBtn.Margin = new System.Windows.Forms.Padding(2);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(92, 26);
            this.logoutBtn.TabIndex = 11;
            this.logoutBtn.Text = "logout";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 220);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.status);
            this.Controls.Add(this.talkBtn);
            this.Controls.Add(this.toTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uLabel);
            this.Controls.Add(this.pTxtBox);
            this.Controls.Add(this.uTxtBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Login";
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uTxtBox;
        private System.Windows.Forms.TextBox pTxtBox;
        private System.Windows.Forms.Label uLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox toTxtBox;
        private System.Windows.Forms.Button talkBtn;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Button logoutBtn;
    }
}