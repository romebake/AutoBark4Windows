namespace AutoBark
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.hotkeyCheckBox = new System.Windows.Forms.CheckBox();
            this.urlLabel = new System.Windows.Forms.Label();
            this.AutoBarkNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HotkeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NotifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bootCheckBox = new System.Windows.Forms.CheckBox();
            this.autoCopyCheckBox = new System.Windows.Forms.CheckBox();
            this.hotkeyLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.contentTextBox = new System.Windows.Forms.TextBox();
            this.contentLabel = new System.Windows.Forms.Label();
            this.clipContentCheckBox = new System.Windows.Forms.CheckBox();
            this.defaultTitleCheckBox = new System.Windows.Forms.CheckBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.hotkeyComboBox = new System.Windows.Forms.ComboBox();
            this.notifyCheckBox = new System.Windows.Forms.CheckBox();
            this.urlText = new CueTextBox();
            this.NotifyIconMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // hotkeyCheckBox
            // 
            this.hotkeyCheckBox.AutoSize = true;
            this.hotkeyCheckBox.Location = new System.Drawing.Point(332, 25);
            this.hotkeyCheckBox.Name = "hotkeyCheckBox";
            this.hotkeyCheckBox.Size = new System.Drawing.Size(72, 16);
            this.hotkeyCheckBox.TabIndex = 0;
            this.hotkeyCheckBox.Text = "启用热键";
            this.hotkeyCheckBox.UseVisualStyleBackColor = true;
            this.hotkeyCheckBox.CheckedChanged += new System.EventHandler(this.hotkeyCheckBox_CheckedChanged);
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(23, 68);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(53, 12);
            this.urlLabel.TabIndex = 1;
            this.urlLabel.Text = "推送链接";
            // 
            // AutoBarkNotifyIcon
            // 
            this.AutoBarkNotifyIcon.ContextMenuStrip = this.NotifyIconMenu;
            this.AutoBarkNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("AutoBarkNotifyIcon.Icon")));
            this.AutoBarkNotifyIcon.Text = "AutoBark";
            this.AutoBarkNotifyIcon.Visible = true;
            this.AutoBarkNotifyIcon.BalloonTipClicked += new System.EventHandler(this.AutoBarkNotifyIcon_BalloonTipClicked);
            this.AutoBarkNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AutoBarkNotifyIcon_MouseClick);
            this.AutoBarkNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AutoBarkNotifyIcon_MouseDoubleClick);
            // 
            // NotifyIconMenu
            // 
            this.NotifyIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowToolStripMenuItem,
            this.HotkeyToolStripMenuItem,
            this.BootToolStripMenuItem,
            this.NotifyToolStripMenuItem,
            this.SendToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.NotifyIconMenu.Name = "NotifyIconMenu";
            this.NotifyIconMenu.Size = new System.Drawing.Size(149, 136);
            // 
            // ShowToolStripMenuItem
            // 
            this.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem";
            this.ShowToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.ShowToolStripMenuItem.Text = "显示窗口";
            this.ShowToolStripMenuItem.Click += new System.EventHandler(this.AutoBarkNotifyIcon_BalloonTipClicked);
            // 
            // HotkeyToolStripMenuItem
            // 
            this.HotkeyToolStripMenuItem.Name = "HotkeyToolStripMenuItem";
            this.HotkeyToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.HotkeyToolStripMenuItem.Text = "启用热键";
            this.HotkeyToolStripMenuItem.Click += new System.EventHandler(this.HotkeyToolStripMenuItem_Click);
            // 
            // BootToolStripMenuItem
            // 
            this.BootToolStripMenuItem.Name = "BootToolStripMenuItem";
            this.BootToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.BootToolStripMenuItem.Text = "开机启动";
            this.BootToolStripMenuItem.Click += new System.EventHandler(this.BootToolStripMenuItem_Click);
            // 
            // NotifyToolStripMenuItem
            // 
            this.NotifyToolStripMenuItem.Name = "NotifyToolStripMenuItem";
            this.NotifyToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.NotifyToolStripMenuItem.Text = "推送成功通知";
            this.NotifyToolStripMenuItem.Click += new System.EventHandler(this.NotifyToolStripMenuItem_Click);
            // 
            // SendToolStripMenuItem
            // 
            this.SendToolStripMenuItem.Name = "SendToolStripMenuItem";
            this.SendToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.SendToolStripMenuItem.Text = "手动推送";
            this.SendToolStripMenuItem.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.ExitToolStripMenuItem.Text = "退出";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // bootCheckBox
            // 
            this.bootCheckBox.AutoSize = true;
            this.bootCheckBox.Location = new System.Drawing.Point(444, 25);
            this.bootCheckBox.Name = "bootCheckBox";
            this.bootCheckBox.Size = new System.Drawing.Size(72, 16);
            this.bootCheckBox.TabIndex = 3;
            this.bootCheckBox.Text = "开机启动";
            this.bootCheckBox.UseVisualStyleBackColor = true;
            this.bootCheckBox.CheckedChanged += new System.EventHandler(this.bootCheckBox_CheckedChanged);
            // 
            // autoCopyCheckBox
            // 
            this.autoCopyCheckBox.AutoSize = true;
            this.autoCopyCheckBox.Location = new System.Drawing.Point(444, 195);
            this.autoCopyCheckBox.Name = "autoCopyCheckBox";
            this.autoCopyCheckBox.Size = new System.Drawing.Size(96, 16);
            this.autoCopyCheckBox.TabIndex = 4;
            this.autoCopyCheckBox.Text = "自动复制推送";
            this.autoCopyCheckBox.UseVisualStyleBackColor = true;
            this.autoCopyCheckBox.CheckedChanged += new System.EventHandler(this.autoCopyCheckBox_CheckedChanged);
            // 
            // hotkeyLabel
            // 
            this.hotkeyLabel.AutoSize = true;
            this.hotkeyLabel.Location = new System.Drawing.Point(23, 25);
            this.hotkeyLabel.Name = "hotkeyLabel";
            this.hotkeyLabel.Size = new System.Drawing.Size(53, 12);
            this.hotkeyLabel.TabIndex = 5;
            this.hotkeyLabel.Text = "推送热键";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(23, 110);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(53, 12);
            this.titleLabel.TabIndex = 7;
            this.titleLabel.Text = "推送标题";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(82, 107);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(332, 21);
            this.titleTextBox.TabIndex = 8;
            this.titleTextBox.TextChanged += new System.EventHandler(this.titleTextBox_TextChanged);
            // 
            // contentTextBox
            // 
            this.contentTextBox.Location = new System.Drawing.Point(82, 149);
            this.contentTextBox.Name = "contentTextBox";
            this.contentTextBox.Size = new System.Drawing.Size(332, 21);
            this.contentTextBox.TabIndex = 9;
            this.contentTextBox.TextChanged += new System.EventHandler(this.contentTextBox_TextChanged);
            // 
            // contentLabel
            // 
            this.contentLabel.AutoSize = true;
            this.contentLabel.Location = new System.Drawing.Point(23, 153);
            this.contentLabel.Name = "contentLabel";
            this.contentLabel.Size = new System.Drawing.Size(53, 12);
            this.contentLabel.TabIndex = 10;
            this.contentLabel.Text = "推送内容";
            // 
            // clipContentCheckBox
            // 
            this.clipContentCheckBox.AutoSize = true;
            this.clipContentCheckBox.Location = new System.Drawing.Point(444, 153);
            this.clipContentCheckBox.Name = "clipContentCheckBox";
            this.clipContentCheckBox.Size = new System.Drawing.Size(84, 16);
            this.clipContentCheckBox.TabIndex = 11;
            this.clipContentCheckBox.Text = "剪切板内容";
            this.clipContentCheckBox.UseVisualStyleBackColor = true;
            this.clipContentCheckBox.CheckedChanged += new System.EventHandler(this.clipContentCheckBox_CheckedChanged);
            // 
            // defaultTitleCheckBox
            // 
            this.defaultTitleCheckBox.AutoSize = true;
            this.defaultTitleCheckBox.Location = new System.Drawing.Point(444, 110);
            this.defaultTitleCheckBox.Name = "defaultTitleCheckBox";
            this.defaultTitleCheckBox.Size = new System.Drawing.Size(72, 16);
            this.defaultTitleCheckBox.TabIndex = 12;
            this.defaultTitleCheckBox.Text = "默认标题";
            this.defaultTitleCheckBox.UseVisualStyleBackColor = true;
            this.defaultTitleCheckBox.CheckedChanged += new System.EventHandler(this.defaultTitleCheckBox_CheckedChanged);
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(82, 191);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(332, 23);
            this.sendButton.TabIndex = 13;
            this.sendButton.Text = "手动推送";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // hotkeyComboBox
            // 
            this.hotkeyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hotkeyComboBox.FormattingEnabled = true;
            this.hotkeyComboBox.Location = new System.Drawing.Point(82, 21);
            this.hotkeyComboBox.Name = "hotkeyComboBox";
            this.hotkeyComboBox.Size = new System.Drawing.Size(216, 20);
            this.hotkeyComboBox.TabIndex = 14;
            this.hotkeyComboBox.SelectedIndexChanged += new System.EventHandler(this.hotkeyComboBox_SelectedIndexChanged);
            // 
            // notifyCheckBox
            // 
            this.notifyCheckBox.AutoSize = true;
            this.notifyCheckBox.Location = new System.Drawing.Point(444, 68);
            this.notifyCheckBox.Name = "notifyCheckBox";
            this.notifyCheckBox.Size = new System.Drawing.Size(96, 16);
            this.notifyCheckBox.TabIndex = 15;
            this.notifyCheckBox.Text = "推送成功通知";
            this.notifyCheckBox.UseVisualStyleBackColor = true;
            this.notifyCheckBox.CheckedChanged += new System.EventHandler(this.notifyCheckBox_CheckedChanged);
            // 
            // urlText
            // 
            this.urlText.Cue = "https://api.day.app/yourkey/";
            this.urlText.Location = new System.Drawing.Point(82, 64);
            this.urlText.Name = "urlText";
            this.urlText.Size = new System.Drawing.Size(332, 21);
            this.urlText.TabIndex = 16;
            this.urlText.TextChanged += new System.EventHandler(this.urlText_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 238);
            this.Controls.Add(this.urlText);
            this.Controls.Add(this.notifyCheckBox);
            this.Controls.Add(this.hotkeyComboBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.defaultTitleCheckBox);
            this.Controls.Add(this.clipContentCheckBox);
            this.Controls.Add(this.contentLabel);
            this.Controls.Add(this.contentTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.hotkeyLabel);
            this.Controls.Add(this.autoCopyCheckBox);
            this.Controls.Add(this.bootCheckBox);
            this.Controls.Add(this.urlLabel);
            this.Controls.Add(this.hotkeyCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "AutoBark v1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.NotifyIconMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox hotkeyCheckBox;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.NotifyIcon AutoBarkNotifyIcon;
        private System.Windows.Forms.CheckBox bootCheckBox;
        private System.Windows.Forms.CheckBox autoCopyCheckBox;
        private System.Windows.Forms.Label hotkeyLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox contentTextBox;
        private System.Windows.Forms.Label contentLabel;
        private System.Windows.Forms.CheckBox clipContentCheckBox;
        private System.Windows.Forms.CheckBox defaultTitleCheckBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.ComboBox hotkeyComboBox;
        private System.Windows.Forms.CheckBox notifyCheckBox;
        private System.Windows.Forms.ContextMenuStrip NotifyIconMenu;
        private System.Windows.Forms.ToolStripMenuItem HotkeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BootToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NotifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private CueTextBox urlText;
    }
}

