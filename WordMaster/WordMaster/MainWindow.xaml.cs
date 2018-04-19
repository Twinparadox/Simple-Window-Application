using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WordMaster
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        /* 타이머 */
        System.Timers.Timer timer = new System.Timers.Timer();
        private static int MinSec = 1;
        private static int Seco = 1000;

        /* 상황 체크 변수 */
        private static bool isStart = false;

        // 시스템 트레이 아이콘
        public System.Windows.Forms.NotifyIcon notifyIcon;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            notifyIcon = new System.Windows.Forms.NotifyIcon();
            notifyIcon.Icon = Properties.Resources.icon;
            notifyIcon.Text = "WordMaster";
            notifyIcon.DoubleClick += NotifyIcon_DoubleClick;
            WordBook.CreateDirectoryAndFiles();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddWordWindow addWindow = new AddWordWindow();
            addWindow.Show();
        }

        private void ButtonSetting_Click(object sender, RoutedEventArgs e)
        {
            SettingWindow settingWindow = new SettingWindow();
            settingWindow.Show();
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            int min, curSize;

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
                curSize = -1;
            }

            if (curSize > 0)
            {
                if (isStart == true)
                {
                    isStart = false;
                    ButtonStart.Content = "시작하기";
                    timer.Stop();
                }
                else
                {
                    isStart = true;
                    ButtonStart.Content = "중단하기";
                    CloseWindow();
                    timer.Start();
                }
            }
            else if (curSize == 0)
            {
                MessageBox.Show("단어를 추가하세요!", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            AnswerWindow ans = null;
            Dispatcher.Invoke(() =>
            {
                ans = new AnswerWindow();
                ans.ShowDialog();
            });
            if (ans.DoNotContinue() == false)
            {
                timer.Stop();
                this.Focus();
                this.Topmost = true;
            }
        }

        private void CloseWindow()
        {
            this.Visibility = Visibility.Collapsed;
            notifyIcon.Visible = true;
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Visibility = Visibility.Visible;
            notifyIcon.Visible = false;
        }

        private void ButtonNote_Click(object sender, RoutedEventArgs e)
        {
            NoteWindow note = new NoteWindow();
            note.ShowDialog();
        }
    }
}
