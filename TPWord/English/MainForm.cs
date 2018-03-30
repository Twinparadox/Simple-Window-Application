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
        /// <summary>
        /// 프로그램 최초 실행 시 디렉토리와 파일을 체크해주는 작업을 실시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        }

        #region Button Methods
        /// <summary>
        /// 단어 추가 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddWord_Click(object sender, EventArgs e)
        {
            AddForm addform = new AddForm();
            addform.ShowDialog();
        }

        /// <summary>
        /// 종료 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        /// <summary>
        /// 설정 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSetting_Click(object sender, EventArgs e)
        {
            SettingForm setfrm = new SettingForm();
            setfrm.ShowDialog();
        }

        /// <summary>
        /// 시작 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStart_Click(object sender, EventArgs e)
        {
            int min, curSize;

            // Read Settings
            log.WriteLine("[Read Settings and Start Word Test...]");
            try
            {
                string[] Setting = Properties.Settings.Default.curSettings.Split(';');

                // integer type transform
                min = Int32.Parse(Setting[1]);
                curSize = Properties.Settings.Default.curSize;

                // Timer
                timer.Interval = min * Seco * MinSec;
                timer.Elapsed += new ElapsedEventHandler(TimerElapsed);
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
                    ButtonStart.Text = "시작하기";
                    VisibleChange(true, false);
                    timer.Stop();
                }
                else
                {
                    isStart = true;
                    ButtonStart.Text = "중단하기";
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

        /// <summary>
        /// 오답 노트 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNote_Click(object sender, EventArgs e)
        {
            NoteForm noteform = new NoteForm();
            noteform.ShowDialog();
        }
        #endregion

        #region Other Methods

        /* Answer Form Renewal */
        private void TimerElapsed(object sender, ElapsedEventArgs e)
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
        /// <summary>
        /// 트레이 해제 시, 화면 포커싱
        /// </summary>
        /// <param name="FormVisible"></param>
        /// <param name="TrayIconVisible"></param>
        private void VisibleChange(Boolean FormVisible, Boolean TrayIconVisible)
        {
            this.Visible = FormVisible;
            this.trayIcon.Visible = TrayIconVisible;
        }
        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VisibleChange(true, false);
        }
        #endregion
    }
}