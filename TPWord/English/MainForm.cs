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
using LIbraryExample.Tools;

namespace TPWord
{
    public partial class MainForm : Form
    {
        /* 저장 경로 */
        private static string saveFolder = @"C:\TPWord";
        private static string saveEnPath = @"C:\TPWord\EWORD.txt";
        private static string saveKrPath = @"C:\TPWord\KWORD.txt";
        private static string saveCountPath = @"C:\TPWord\COUNT.txt";
        private static string saveSettings = @"C:\TPWord\TPSetting.txt";

        /* 타이머 */
        System.Timers.Timer timer = new System.Timers.Timer();
        private static int MinSec = 60;
        private static int Seco = 1000;

        /* 로그 매니저 */
        public static LogManager log = new LogManager();

        /* 윈도우 최상위 */
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        /* 상황 체크 변수 */
        private static bool isStart = false;


        public MainForm()
        {
            InitializeComponent();
            this.trayIcon.Visible = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            /* Check Directory and File */
            if (!Directory.Exists(saveFolder))
            {
                log.WriteLine("[Make Directory...]");
                try
                {
                    Directory.CreateDirectory(saveFolder);
                }
                catch (Exception ex)
                {
                    log.WriteLine("Ex:"+ex.ToString());
                }
            }
            if (!File.Exists(saveEnPath))
            {
                log.WriteLine("[Make saveEnPath...]");
                try
                {
                    File.CreateText(saveEnPath);
                }
                catch (Exception ex)
                {
                    log.WriteLine("Ex:" + ex.ToString());
                }
            }
            if (!File.Exists(saveKrPath))
            {
                log.WriteLine("[Make saveKrPath...]");
                try
                {
                    File.CreateText(saveKrPath);
                }
                catch (Exception ex)
                {
                    log.WriteLine("Ex:" + ex.ToString());
                }
            }
            if (!File.Exists(saveCountPath))
            {
                log.WriteLine("[Make saveCountPath...]");
                try
                {
                    File.CreateText(saveCountPath);
                }
                catch (Exception ex)
                {
                    log.WriteLine("Ex:" + ex.ToString());
                }
            }
            if (!File.Exists(saveSettings))
            {
                log.WriteLine("[Make saveSettings...]");
                try
                {
                    File.CreateText(saveSettings);
                }
                catch (Exception ex)
                {
                    log.WriteLine("Ex:" + ex.ToString());
                }
            }
            InitSetting();
        }

        #region Button Methods
        private void btnAddWord_Click(object sender, EventArgs e)
        {
            StartForm startfrm = new StartForm();
            startfrm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            SettingForm setfrm = new SettingForm();
            setfrm.ShowDialog();
        }

        // Start Button
        private void btnStart_Click(object sender, EventArgs e)
        {
            int min, curSize;

            // Read Settings
            log.WriteLine("[Read Settings and Start Word Test...]");
            try
            {
                string[] Setting = Properties.Settings.Default.settings.Split(';');

                // integer type transform
                min = Int32.Parse(Setting[1]);
                curSize = Int32.Parse(Setting[2]);

                // Timer
                timer.Interval = min * Seco * MinSec;
                timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            }
            catch (Exception ex)
            {
                log.WriteLine("Ex:" + ex.ToString());
                curSize = -1;
            }
            
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
            else if(curSize==0)
            {
                MessageBox.Show("단어를 추가하세요!", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /* Read Setting Exception */
            else
            {
            }
        }
        #endregion

        #region Other Methods
        /* Initialize Setting */
        private void InitSetting()
        {
            log.WriteLine("[Read File...]");
            /* need to handle exception */
            int currentSize = File.ReadLines(saveEnPath).Count();
            string[] Setting = File.ReadAllLines(saveSettings);

            // User Setting
            if (Setting.Length != 0)
            {
                log.WriteLine("[Initialize to User Settings...]");
                try
                {
                    File.WriteAllText(saveSettings, Setting[0] + "\r\n", Encoding.UTF8);
                    File.AppendAllText(saveSettings, Setting[1] + "\r\n", Encoding.UTF8);
                    File.AppendAllText(saveSettings, currentSize + "\r\n", Encoding.UTF8);
                }
                catch (Exception ex)
                {
                    log.WriteLine("Ex:" + ex.ToString());
                }
            }
            // Basic Setting
            else
            {
                log.WriteLine("[Initailze to Basic Settings...]");
                try
                {
                    File.WriteAllText(saveSettings, "5\r\n", Encoding.UTF8);
                    File.AppendAllText(saveSettings, "AON\r\n", Encoding.UTF8);
                    File.AppendAllText(saveSettings, "0\r\n", Encoding.UTF8);
                }
                catch(Exception ex)
                {
                    log.WriteLine("Ex:" + ex.ToString());
                }
            }
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
        #endregion

        #region Tray Transform Methods
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
        #endregion        
    }
}