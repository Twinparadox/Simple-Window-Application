using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectoryCleaner
{
    public partial class MainForm : Form
    {
        public static TextBox pTextPath;

        // 예외 체크 변수
        public static bool exceptionCheck;

        // 시작 금지 변수
        public static bool isCheck;

        public MainForm()
        {
            InitializeComponent();
        }

        // 메인폼 로드 시
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadSetting();
        }

        // 초기 설정 불러오는 함수
        private void LoadSetting()
        {
            pTextPath = TextPath;
            TextPath.Text = Properties.Settings.Default.LatestPath;

            Extension.LoadExtension();

            Extension.curExtension = Extension.initExtension + Extension.userExtension;

            exceptionCheck = false;
            isCheck = Extension.CheckActivatedExtension(); 
        }

        // 경로 설정 버튼
        private void ButtonFinder_Click(object sender, EventArgs e)
        {
            SettingPath();
        }

        // 설정 버튼
        private void ButtonSetting_Click(object sender, EventArgs e)
        {
            Point thisFormPoint = this.Location;
            Setting settingForm = new Setting();

            if (exceptionCheck == true)
                return;
            settingForm.StartPosition = FormStartPosition.Manual;
            settingForm.Location = thisFormPoint;

            settingForm.ShowDialog();
        }

        // 종료 버튼
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // 시작 버튼
        private void ButtonStart_Click(object sender, EventArgs e)
        {
            isCheck = Extension.CheckActivatedExtension();
            DirectoryInfo di = new DirectoryInfo(pTextPath.Text);

            if (!isCheck)
            {
                MessageBox.Show("파일 종류를 설정하지 않았습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (pTextPath.Text == "")
            {
                MessageBox.Show("경로를 지정하지 않았습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!di.Exists)
            {
                MessageBox.Show("해당 경로가 존재하지 않습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            Extension.LoadExtension();
            Extension.TokenizeExtension();

            Point thisFormPoint = this.Location;
            Search searchForm = new Search
            {
                StartPosition = FormStartPosition.Manual,
                Location = thisFormPoint
            };

            this.Visible = false;
            searchForm.ShowDialog();
            this.Visible = true;
        }

        // 경로 클릭
        private void TextPath_MouseClick(object sender, MouseEventArgs e)
        {
            SettingPath();
        }

        // 경로 설정
        private void SettingPath()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            string selectedPath = dialog.SelectedPath;

            if(selectedPath.Equals(""))
            {
                TextPath.Text = Properties.Settings.Default.LatestPath;
            }
            else
            {
                TextPath.Text = selectedPath;
                Properties.Settings.Default.LatestPath = selectedPath;
            }
            Properties.Settings.Default.Save();
        }

        // 프로그램 종료
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.LatestPath = this.TextPath.Text;
            Properties.Settings.Default.Save();
        }
    }
}
