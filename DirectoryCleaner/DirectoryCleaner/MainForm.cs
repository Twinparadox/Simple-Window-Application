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

        #region 경로 설정
        /// <summary>
        /// 경로 설정 버튼(Find)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonFinder_Click(object sender, EventArgs e)
        {
            SettingPath();
        }

        /// <summary>
        /// 경로 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextPath_MouseClick(object sender, MouseEventArgs e)
        {
            SettingPath();
        }

        /// <summary>
        /// 경로 설정
        /// </summary>
        private void SettingPath()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            string selectedPath = dialog.SelectedPath;

            if (selectedPath.Equals(""))
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
        #endregion

        /// <summary>
        /// 설정 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSetting_Click(object sender, EventArgs e)
        {
            Point thisFormPoint = this.Location;
            SettingForm settingForm = new SettingForm();

            if (exceptionCheck == true)
                return;
            settingForm.StartPosition = FormStartPosition.Manual;
            settingForm.Location = thisFormPoint;

            settingForm.ShowDialog();
        }

        /// <summary>
        /// 닫기 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 목록보기 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonList_Click(object sender, EventArgs e)
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
            if (!di.Exists)
            {
                MessageBox.Show("해당 경로가 존재하지 않습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Extension.LoadExtension();
            Extension.TokenizeExtension();

            Point thisFormPoint = this.Location;
            SearchForm searchForm = new SearchForm
            {
                StartPosition = FormStartPosition.Manual,
                Location = thisFormPoint
            };

            if (searchForm.IsListEmpty())
            {
                MessageBox.Show("검색된 파일이 없습니다.");
            }
            else
            {
                this.Visible = false;
                searchForm.ShowDialog();
                this.Visible = true;
            }
        }

        /// <summary>
        /// 파일조회 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDuplicate_Click(object sender, EventArgs e)
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
            if (!di.Exists)
            {
                MessageBox.Show("해당 경로가 존재하지 않습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Extension.LoadExtension();
            Extension.TokenizeExtension();

            Point thisFormPoint = this.Location;
            RemoveDuplicateFilesForm removeForm = new RemoveDuplicateFilesForm
            {
                StartPosition = FormStartPosition.Manual,
                Location = thisFormPoint
            };
            removeForm.ShowDialog();
        }

        // 프로그램 종료
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.LatestPath = this.TextPath.Text;
            Properties.Settings.Default.Save();
        }
    }
}
