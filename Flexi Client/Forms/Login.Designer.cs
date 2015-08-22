namespace Flexi_Client
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
            this.FlexiLBL = new System.Windows.Forms.Label();
            this.LoginBTN = new System.Windows.Forms.Button();
            this.UsernameTXT = new System.Windows.Forms.TextBox();
            this.PasswordTXT = new System.Windows.Forms.TextBox();
            this.UsernameLBL = new System.Windows.Forms.Label();
            this.PasswordLBL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FlexiLBL
            // 
            this.FlexiLBL.AutoSize = true;
            this.FlexiLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlexiLBL.Location = new System.Drawing.Point(123, 9);
            this.FlexiLBL.Name = "FlexiLBL";
            this.FlexiLBL.Size = new System.Drawing.Size(390, 135);
            this.FlexiLBL.TabIndex = 0;
            this.FlexiLBL.Text = "FLEXI";
            // 
            // LoginBTN
            // 
            this.LoginBTN.Location = new System.Drawing.Point(146, 228);
            this.LoginBTN.Name = "LoginBTN";
            this.LoginBTN.Size = new System.Drawing.Size(333, 36);
            this.LoginBTN.TabIndex = 1;
            this.LoginBTN.Text = "Login";
            this.LoginBTN.UseVisualStyleBackColor = true;
            this.LoginBTN.Click += new System.EventHandler(this.LoginBTN_Click);
            // 
            // UsernameTXT
            // 
            this.UsernameTXT.Location = new System.Drawing.Point(226, 147);
            this.UsernameTXT.Name = "UsernameTXT";
            this.UsernameTXT.Size = new System.Drawing.Size(239, 22);
            this.UsernameTXT.TabIndex = 2;
            // 
            // PasswordTXT
            // 
            this.PasswordTXT.Location = new System.Drawing.Point(226, 184);
            this.PasswordTXT.Name = "PasswordTXT";
            this.PasswordTXT.PasswordChar = '*';
            this.PasswordTXT.Size = new System.Drawing.Size(239, 22);
            this.PasswordTXT.TabIndex = 3;
            // 
            // UsernameLBL
            // 
            this.UsernameLBL.AutoSize = true;
            this.UsernameLBL.Location = new System.Drawing.Point(143, 147);
            this.UsernameLBL.Name = "UsernameLBL";
            this.UsernameLBL.Size = new System.Drawing.Size(73, 17);
            this.UsernameLBL.TabIndex = 4;
            this.UsernameLBL.Text = "Username";
            // 
            // PasswordLBL
            // 
            this.PasswordLBL.AutoSize = true;
            this.PasswordLBL.Location = new System.Drawing.Point(143, 184);
            this.PasswordLBL.Name = "PasswordLBL";
            this.PasswordLBL.Size = new System.Drawing.Size(69, 17);
            this.PasswordLBL.TabIndex = 5;
            this.PasswordLBL.Text = "Password";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 288);
            this.Controls.Add(this.PasswordLBL);
            this.Controls.Add(this.UsernameLBL);
            this.Controls.Add(this.PasswordTXT);
            this.Controls.Add(this.UsernameTXT);
            this.Controls.Add(this.LoginBTN);
            this.Controls.Add(this.FlexiLBL);
            this.Name = "Login";
            this.Text = "Flexi";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FlexiLBL;
        private System.Windows.Forms.Button LoginBTN;
        private System.Windows.Forms.TextBox UsernameTXT;
        private System.Windows.Forms.TextBox PasswordTXT;
        private System.Windows.Forms.Label UsernameLBL;
        private System.Windows.Forms.Label PasswordLBL;
    }
}

