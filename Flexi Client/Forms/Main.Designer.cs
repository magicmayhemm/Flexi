namespace Flexi_Client
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.ToolSTRIP = new System.Windows.Forms.MenuStrip();
            this.OptionsStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearBTN = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsBTN = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpBTN = new System.Windows.Forms.ToolStripMenuItem();
            this.ChatAreaRTB = new System.Windows.Forms.RichTextBox();
            this.MessageTXT = new System.Windows.Forms.TextBox();
            this.SendMessageBTN = new System.Windows.Forms.Button();
            this.UsersConnected = new System.Windows.Forms.ListBox();
            this.ToolSTRIP.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolSTRIP
            // 
            this.ToolSTRIP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionsStrip,
            this.AboutStrip});
            this.ToolSTRIP.Location = new System.Drawing.Point(0, 0);
            this.ToolSTRIP.Name = "ToolSTRIP";
            this.ToolSTRIP.Size = new System.Drawing.Size(716, 28);
            this.ToolSTRIP.TabIndex = 0;
            this.ToolSTRIP.Text = "menuStrip1";
            // 
            // OptionsStrip
            // 
            this.OptionsStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearBTN,
            this.SettingsBTN});
            this.OptionsStrip.Name = "OptionsStrip";
            this.OptionsStrip.Size = new System.Drawing.Size(73, 24);
            this.OptionsStrip.Text = "Options";
            // 
            // ClearBTN
            // 
            this.ClearBTN.Name = "ClearBTN";
            this.ClearBTN.Size = new System.Drawing.Size(146, 24);
            this.ClearBTN.Text = "Clear Chat";
            // 
            // SettingsBTN
            // 
            this.SettingsBTN.Name = "SettingsBTN";
            this.SettingsBTN.Size = new System.Drawing.Size(146, 24);
            this.SettingsBTN.Text = "Settings";
            // 
            // AboutStrip
            // 
            this.AboutStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpBTN});
            this.AboutStrip.Name = "AboutStrip";
            this.AboutStrip.Size = new System.Drawing.Size(62, 24);
            this.AboutStrip.Text = "About";
            // 
            // HelpBTN
            // 
            this.HelpBTN.Name = "HelpBTN";
            this.HelpBTN.Size = new System.Drawing.Size(110, 24);
            this.HelpBTN.Text = "Help";
            // 
            // ChatAreaRTB
            // 
            this.ChatAreaRTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatAreaRTB.Location = new System.Drawing.Point(0, 30);
            this.ChatAreaRTB.Name = "ChatAreaRTB";
            this.ChatAreaRTB.ReadOnly = true;
            this.ChatAreaRTB.Size = new System.Drawing.Size(554, 275);
            this.ChatAreaRTB.TabIndex = 1;
            this.ChatAreaRTB.Text = "### FLEXI CHAT SERVER ###";
            // 
            // MessageTXT
            // 
            this.MessageTXT.Location = new System.Drawing.Point(12, 320);
            this.MessageTXT.Name = "MessageTXT";
            this.MessageTXT.Size = new System.Drawing.Size(542, 22);
            this.MessageTXT.TabIndex = 2;

            this.MessageTXT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageTXT_KeyPress);
            // 
            // SendMessageBTN
            // 
            this.SendMessageBTN.Location = new System.Drawing.Point(560, 316);
            this.SendMessageBTN.Name = "SendMessageBTN";
            this.SendMessageBTN.Size = new System.Drawing.Size(144, 30);
            this.SendMessageBTN.TabIndex = 3;
            this.SendMessageBTN.Text = "Send";
            this.SendMessageBTN.UseVisualStyleBackColor = true;
            this.SendMessageBTN.Click += new System.EventHandler(this.SendMessageBTN_Click);
            // 
            // UsersConnected
            // 
            this.UsersConnected.FormattingEnabled = true;
            this.UsersConnected.ItemHeight = 16;
            this.UsersConnected.Items.AddRange(new object[] {
            "USERS IN ROOM",
            "__________________"});
            this.UsersConnected.Location = new System.Drawing.Point(560, 31);
            this.UsersConnected.Name = "UsersConnected";
            this.UsersConnected.Size = new System.Drawing.Size(144, 276);
            this.UsersConnected.TabIndex = 4;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 354);
            this.Controls.Add(this.UsersConnected);
            this.Controls.Add(this.SendMessageBTN);
            this.Controls.Add(this.MessageTXT);
            this.Controls.Add(this.ChatAreaRTB);
            this.Controls.Add(this.ToolSTRIP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.ToolSTRIP;
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SendMessageBTN_Click);
            this.ToolSTRIP.ResumeLayout(false);
            this.ToolSTRIP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip ToolSTRIP;
        private System.Windows.Forms.ToolStripMenuItem OptionsStrip;
        private System.Windows.Forms.ToolStripMenuItem ClearBTN;
        private System.Windows.Forms.ToolStripMenuItem SettingsBTN;
        private System.Windows.Forms.ToolStripMenuItem AboutStrip;
        private System.Windows.Forms.ToolStripMenuItem HelpBTN;
        private System.Windows.Forms.RichTextBox ChatAreaRTB;
        private System.Windows.Forms.TextBox MessageTXT;
        private System.Windows.Forms.Button SendMessageBTN;
        private System.Windows.Forms.ListBox UsersConnected;
    }
}