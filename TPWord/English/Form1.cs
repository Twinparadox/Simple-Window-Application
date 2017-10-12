using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Timers;
using System.Runtime.InteropServices;

namespace TPWord
{
    public partial class Form1 : Form
    {
        /* 저장 경로 */
        static string saveFolder = @"C:\TPWord";
        static string saveEnPath = @"C:\TPWord\EWORD.txt";
        static string saveKrPath = @"C:\TPWord\KWORD.txt";
        static string saveCountPath = @"C:\TPWord\COUNT.txt";
        static string saveSettings = @"C:\TPWord\TPSetting.txt";

        /* 타이머 */
        System.Timers.Timer timer = new System.Timers.Timer();
        static int MinSec = 60;
        static int Seco = 1000;

        /* 윈도우 최상위 */
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        /* 상황 체크 변수 */
        static bool isStart = false;


        public Form1()
        {
            InitializeComponent();
            this.trayIcon.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /* Check Directory and File */
            if (!Directory.Exists(saveFolder))
            {
                Directory.CreateDirectory(saveFolder);
            }
            if (!File.Exists(saveEnPath))
            {
                File.CreateText(saveEnPath);
            }
            if (!File.Exists(saveKrPath))
            {
                File.CreateText(saveKrPath);
            }
            if (!File.Exists(saveCountPath))
            {
                File.CreateText(saveCountPath);
            }
            if (!File.Exists(saveSettings))
            {
                File.CreateText(saveSettings);
            }
            InitSetting();
        }

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            SettingForm setfrm = new SettingForm();
            setfrm.ShowDialog();
        }

        // Start Button
        private void btnStart_Click(object sender, EventArgs e)
        {
            // Read Settings
            string[] Setting = File.ReadAllLines(saveSettings, Encoding.GetEncoding("utf-8"));

            // integer type transform
            int min = Int32.Parse(Setting[0]);
            int curSize = Int32.Parse(Setting[2]);

            // Timer
            timer.Interval = min * Seco * MinSec;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);

            if (curSize > 0)
            {
                if (isStart == true)
                {
                    isStart = false;
                    btnStart.Text = "시작하기";
                    VisibleChange(true, false);
                    timer.Stop();
                }
                else
                {
                    isStart = true;
                    btnStart.Text = "중단하기";
                    VisibleChange(false, true);
                    timer.Start();
                }
            }
            else
            {
                MessageBox.Show("단어를 추가하세요!", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* Initialize Setting */
        private void InitSetting()
        {
            int currentSize = File.ReadLines(saveEnPath).Count();
            string[] Setting = File.ReadAllLines(saveSettings);

            // User Setting
            if (Setting.Length != 0)
            {
                File.WriteAllText(saveSettings, Setting[0] + "\r\n", Encoding.UTF8);
                File.AppendAllText(saveSettings, Setting[1] + "\r\n", Encoding.UTF8);
                File.AppendAllText(saveSettings, currentSize + "\r\n", Encoding.UTF8);
            }
            // Basic Setting
            else
            {
                File.WriteAllText(saveSettings, "5\r\n", Encoding.UTF8);
                File.AppendAllText(saveSettings, "AON\r\n", Encoding.UTF8);
                File.AppendAllText(saveSettings, "0\r\n", Encoding.UTF8);
            }
        }



        /* form, tray transform */
        private void VisibleChange(Boolean FormVisible, Boolean TrayIconVisible)
        {
            this.Visible = FormVisible;
            this.trayIcon.Visible = TrayIconVisible;
        }
        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VisibleChange(true, false);
        }

        /* Answer Form Renewal */
        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Answer ans = new Answer();
            ans.ShowDialog();
            if (ans.DoNotContinue() == false)
            {
                timer.Stop();
                VisibleChange(true, false);
                this.Focus();
                this.TopLevel = true;
            }
        }
    }
}