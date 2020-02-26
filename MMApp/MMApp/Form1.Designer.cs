namespace MMApp
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.messageList = new System.Windows.Forms.TextBox();
            this.txtEntry = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.important = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // messageList
            // 
            this.messageList.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.messageList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageList.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageList.Location = new System.Drawing.Point(11, 8);
            this.messageList.Margin = new System.Windows.Forms.Padding(2);
            this.messageList.Multiline = true;
            this.messageList.Name = "messageList";
            this.messageList.ReadOnly = true;
            this.messageList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageList.Size = new System.Drawing.Size(696, 279);
            this.messageList.TabIndex = 1;
            // 
            // txtEntry
            // 
            this.txtEntry.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEntry.Location = new System.Drawing.Point(11, 291);
            this.txtEntry.Margin = new System.Windows.Forms.Padding(2);
            this.txtEntry.Multiline = true;
            this.txtEntry.Name = "txtEntry";
            this.txtEntry.Size = new System.Drawing.Size(696, 110);
            this.txtEntry.TabIndex = 2;
            // 
            // sendBtn
            // 
            this.sendBtn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.sendBtn.Location = new System.Drawing.Point(648, 405);
            this.sendBtn.Margin = new System.Windows.Forms.Padding(2);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(59, 24);
            this.sendBtn.TabIndex = 3;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = false;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // important
            // 
            this.important.AutoSize = true;
            this.important.Location = new System.Drawing.Point(573, 410);
            this.important.Name = "important";
            this.important.Size = new System.Drawing.Size(70, 17);
            this.important.TabIndex = 4;
            this.important.Text = "Important";
            this.important.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 436);
            this.Controls.Add(this.important);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.txtEntry);
            this.Controls.Add(this.messageList);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox messageList;
        private System.Windows.Forms.TextBox txtEntry;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.CheckBox important;
    }
}

