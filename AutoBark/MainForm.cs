using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json.Linq;
using Microsoft.Win32;
using KeyboardMonitor;
using System.Threading;

namespace AutoBark
{
    public partial class MainForm : Form
    {
        private String clipboardText;
        private KeyboardHook hook;
        private Dictionary<string, int> hotkeyDict;
        public MainForm()
        {
            InitializeComponent();

            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

            this.StartPosition = FormStartPosition.CenterScreen;

            hook = new KeyboardHook();
            hotkeyDict = new Dictionary<string, int>();
            hotkeyDict.Add("Ctrl + Alt + C", (int)Keys.Control + (int)Keys.Alt);
            hotkeyDict.Add("Shift + Alt + C", (int)Keys.Shift + (int)Keys.Alt);
            hotkeyDict.Add("Shift + C", (int)Keys.Shift);
            hotkeyDict.Add("Alt + C", (int)Keys.Alt);

            // Set HotkeyComboBox Items
            foreach (string key in hotkeyDict.Keys)
            {
                this.hotkeyComboBox.Items.Add(key);
            }

            // Set HotkeyComboBox Key Actions
            this.hotkeyComboBox.KeyDown += (s, e) => e.Handled = true;
            this.hotkeyComboBox.KeyPress += (s, e) => e.Handled = true;
            this.hotkeyComboBox.KeyUp += (s, e) => e.Handled = true;

            // Get Settins
            this.bootCheckBox.Checked = this.BootToolStripMenuItem.Checked = Properties.Settings.Default.boot;
            this.hotkeyComboBox.Text = Properties.Settings.Default.hotkey;
            this.hotkeyCheckBox.Checked = this.HotkeyToolStripMenuItem.Checked = Properties.Settings.Default.hotkeyCheck;
            this.urlText.Text = Properties.Settings.Default.url;
            this.titleTextBox.Text = Properties.Settings.Default.title;
            this.defaultTitleCheckBox.Checked = Properties.Settings.Default.titleCheck;
            this.contentTextBox.Text = Properties.Settings.Default.content;
            this.clipContentCheckBox.Checked = Properties.Settings.Default.contentCheck;
            this.autoCopyCheckBox.Checked = Properties.Settings.Default.autoCopyCheck;
            this.notifyCheckBox.Checked = this.NotifyToolStripMenuItem.Checked = Properties.Settings.Default.notifyCheck;
        }

        System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string dllName = args.Name.Contains(",") ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");
            dllName = dllName.Replace(".", "_");
            if (dllName.EndsWith("_resources")) return null;
            System.Resources.ResourceManager rm = new System.Resources.ResourceManager(GetType().Namespace + ".Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
            byte[] bytes = (byte[])rm.GetObject(dllName);
            return System.Reflection.Assembly.Load(bytes);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.AutoBarkNotifyIcon_ShowBalloonTip(2000, "AutoBark通知", "运行成功，点击打开", ToolTipIcon.Info);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
            }
        }

        private void AutoBarkNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            this.NotifyIconMenu.Show(Cursor.Position);
        }

        private void AutoBarkNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowForm();
        }

        private void AutoBarkNotifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            this.ShowForm();
        }

        private void ShowForm()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
                this.Activate();
                this.ShowInTaskbar = true;
            }
            else
            {
                this.Activate();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ExitProgram();
        }

        private void ExitProgram()
        {
            this.Dispose();
            this.Close();
        }

        private void SendBarkMsg()
        {
            String url = this.urlText.Text;
            if (String.IsNullOrWhiteSpace(url))
            {
                this.AutoBarkNotifyIcon_ShowBalloonTip(3000, "AutoBark通知", "推送链接不能为空", ToolTipIcon.Warning);
                return;
            }

            clipboardText = Clipboard.GetText();

            Thread sendMsgThread = new Thread(new ParameterizedThreadStart(HttpSendBarkMsgThread));
            sendMsgThread.IsBackground = true;
            sendMsgThread.Start(url);
        }

        private void HttpSendBarkMsgThread(object obj)
        {
            try
            {
                HttpWebRequest request;
                request = (HttpWebRequest)WebRequest.Create(obj.ToString());
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";

                // Set Post Params
                String title = this.defaultTitleCheckBox.Checked ? "AutoBark" : this.titleTextBox.Text;
                String body = this.clipContentCheckBox.Checked ? clipboardText : this.contentTextBox.Text;
                StringBuilder builder = new StringBuilder();
                builder.AppendFormat("title={0}", title);
                builder.AppendFormat("&body={0}", body);
                builder.AppendFormat("&copy={0}", body);
                builder.AppendFormat("&automaticallyCopy={0}", this.autoCopyCheckBox.Checked ? "1" : "0");

                byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
                request.ContentLength = data.Length;
                using (System.IO.Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);
                    reqStream.Close();
                }

                HttpWebResponse response;
                response = (HttpWebResponse)request.GetResponse();
                System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string responseText = myreader.ReadToEnd();
                JObject barkResp = JObject.Parse(responseText);

                if (Convert.ToInt16(barkResp["code"]) == 200)
                {
                    if (this.notifyCheckBox.Checked)
                    {
                        this.AutoBarkNotifyIcon_ShowBalloonTip(2000, "AutoBark通知", "推送成功", ToolTipIcon.Info);
                    }
                }
                else
                {
                    this.AutoBarkNotifyIcon_ShowBalloonTip(3000, "AutoBark通知", "推送失败：\n" + barkResp["message"], ToolTipIcon.Error);
                }
            }
            catch (Exception e)
            {
                this.AutoBarkNotifyIcon_ShowBalloonTip(3000, "AutoBark通知", "发起推送失败：" + e, ToolTipIcon.Error);
            }
        }

        private void hook_Start()
        {
            hook.KeyDownEvent += new KeyEventHandler(hook_KeyDown);
            hook.Start();
        }

        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.C && (int)Control.ModifierKeys == hotkeyDict[this.hotkeyComboBox.Text])
            {
                this.SendBarkMsg();
            }
        }

        private void hotkeyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool hotkeyChecked = this.hotkeyCheckBox.Checked;

            try
            {
                // Change Hook Status
                if (this.hotkeyCheckBox.Checked)
                {
                    this.hook_Start();
                }
                else
                {
                    hook.Stop();
                }
            }
            catch (Exception)
            {
                this.AutoBarkNotifyIcon_ShowBalloonTip(3000, "AutoBark通知", "启用失败" , ToolTipIcon.Warning);
                this.hotkeyCheckBox.Checked = !hotkeyChecked;
                return;
            }

            if (hotkeyChecked == Properties.Settings.Default.hotkeyCheck) return;

            this.HotkeyToolStripMenuItem.Checked = hotkeyChecked;

            // Save HotkeyChecked Config
            Properties.Settings.Default.hotkeyCheck = hotkeyChecked;
            Properties.Settings.Default.Save();
        }

        private void HotkeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.hotkeyCheckBox.Checked = !this.hotkeyCheckBox.Checked;
        }

        public void AutoBarkNotifyIcon_ShowBalloonTip(int tipDisplayTime, String tipTitle, String tipText, ToolTipIcon tipIcon)
        {
            this.AutoBarkNotifyIcon.ShowBalloonTip(tipDisplayTime, tipTitle, tipText, tipIcon);
        }

        private void clipContentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool contentChecked = this.clipContentCheckBox.Checked;

            // Change ContentText ReadOnly
            this.contentTextBox.ReadOnly = contentChecked;

            if (contentChecked == Properties.Settings.Default.contentCheck) return;

            // Save ContentChecked Config
            Properties.Settings.Default.contentCheck = contentChecked;
            Properties.Settings.Default.Save();

        }

        private void defaultTitleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool defaultTitleChecked = this.defaultTitleCheckBox.Checked;

            // Change TitleText ReadOnly
            this.titleTextBox.ReadOnly = defaultTitleChecked;

            if (defaultTitleChecked == Properties.Settings.Default.titleCheck) return;

            // Save TitleChecked Config
            Properties.Settings.Default.titleCheck = defaultTitleChecked;
            Properties.Settings.Default.Save();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            this.SendBarkMsg();
        }

        private void bootCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool bootChecked = this.bootCheckBox.Checked;

            if (bootChecked == Properties.Settings.Default.boot) return;

            if (bootChecked)
            {
                RegistryKey R_local = Registry.CurrentUser;
                RegistryKey R_run = R_local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                R_run.SetValue("AutoBark", Application.ExecutablePath);
                R_run.Close();
                R_local.Close();
            }
            else
            {
                RegistryKey R_local = Registry.CurrentUser;
                RegistryKey R_run = R_local.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                R_run.DeleteValue("AutoBark", false);
                R_run.Close();
                R_local.Close();
            }

            this.BootToolStripMenuItem.Checked = bootChecked;

            // Save BootChecked Config
            Properties.Settings.Default.boot = bootChecked;
            Properties.Settings.Default.Save();
        }

        private void BootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.bootCheckBox.Checked = !this.bootCheckBox.Checked;
        }

        private void hotkeyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String hotkeyText = this.hotkeyComboBox.Text;

            if (hotkeyText == Properties.Settings.Default.hotkey) return;

            Properties.Settings.Default.hotkey = hotkeyText;
            Properties.Settings.Default.Save();
        }

        private void urlText_TextChanged(object sender, EventArgs e)
        {
            String urlText = this.urlText.Text;

            if (urlText == Properties.Settings.Default.url) return;

            Properties.Settings.Default.url = urlText;
            Properties.Settings.Default.Save();
        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {
            String titleText = this.titleTextBox.Text;

            if (titleText == Properties.Settings.Default.title) return;

            Properties.Settings.Default.title = titleText;
            Properties.Settings.Default.Save();
        }

        private void contentTextBox_TextChanged(object sender, EventArgs e)
        {
            String contentText = this.contentTextBox.Text;

            if (contentText == Properties.Settings.Default.content) return;

            Properties.Settings.Default.content = contentText;
            Properties.Settings.Default.Save();
        }

        private void autoCopyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool autoCopyChecked = this.autoCopyCheckBox.Checked;

            if (autoCopyChecked == Properties.Settings.Default.autoCopyCheck) return;

            Properties.Settings.Default.autoCopyCheck = autoCopyChecked;
            Properties.Settings.Default.Save();
        }

        private void notifyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool notifyChecked = this.notifyCheckBox.Checked;

            if (notifyChecked == Properties.Settings.Default.notifyCheck) return;

            this.NotifyToolStripMenuItem.Checked = notifyChecked;

            Properties.Settings.Default.notifyCheck = notifyChecked;
            Properties.Settings.Default.Save();
        }

        private void NotifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.notifyCheckBox.Checked = !this.notifyCheckBox.Checked;
        }
    }
}
