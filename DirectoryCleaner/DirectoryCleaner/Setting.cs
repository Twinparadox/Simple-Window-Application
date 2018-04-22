using System;
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
    public partial class Setting : Form
    {
        private static string initSettings = "1";

        public static TextBox pTxtExtension;

        public Setting()
        {
            InitializeComponent();
        }

        // 폼 로드 시점
        private void Setting_Load(object sender, EventArgs e)
        {
            pTxtExtension = txtExtension;
            
            Extension.curExtension = Extension.initExtension + Extension.userExtension;

            if (Properties.Settings.Default.TimeSetting.Equals("1"))
                rButton1Month.Checked = true;
            else if (Properties.Settings.Default.TimeSetting.Equals("3"))
                rButton3Months.Checked = true;
            else
                rButton6Months.Checked = true;

            txtExtension.Text = Extension.curExtension;
        }
        
        // 폼 종료
        private void Setting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("설정을 저장하시겠습니까?","확인",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                SaveSettings();
            }
        }

        // 설정 저장 후 종료
        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.Close();
        }

        // 초기화 버튼
        private void ButtonInitialize_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.EtcExtensionList = "";
            Properties.Settings.Default.DocExtensionList = "";
            Properties.Settings.Default.AudioExtensionList = "";
            Properties.Settings.Default.VideoExtensionList = "";
            Properties.Settings.Default.ImageExtensionList = "";
            Properties.Settings.Default.CompactExtensionLIst = "";
            Properties.Settings.Default.TxtExtensionList = "";
            Properties.Settings.Default.DiscExtensionList = "";

            Properties.Settings.Default.isAudio = Properties.Settings.Default.isCompac = Properties.Settings.Default.isDoc =
            Properties.Settings.Default.isEtc = Properties.Settings.Default.isImg = Properties.Settings.Default.isVideo =
            Properties.Settings.Default.isTxt = Properties.Settings.Default.isDisc = true;

            Extension.userEtcExtension = Extension.userDocExtension = 
                Extension.userAudioExtension = Extension.userVideoExtension = 
                Extension.userImgExtension = Extension.userCompacExtension = "";
            Properties.Settings.Default.TimeSetting = initSettings;
            Properties.Settings.Default.LatestPath = @"C:\";

            MainForm.pTextPath.Text = Properties.Settings.Default.LatestPath;
            pTxtExtension.Text = Extension.initExtension;
            rButton1Month.Checked = true;
        }

        // 관리 버튼
        private void ButtonManagement_Click(object sender, EventArgs e)
        {
            Point thisFormPoint = this.Location;
            ViewExtensionList viewForm = new ViewExtensionList();

            viewForm.StartPosition = FormStartPosition.Manual;
            viewForm.Location = thisFormPoint;

            this.TopMost = false;
            viewForm.ShowDialog();
            this.TopMost = true;
        }

        // 설정 저장
        private void SaveSettings()
        {
            if (rButton1Month.Checked)
                Properties.Settings.Default.TimeSetting = "1";
            if (rButton3Months.Checked)
                Properties.Settings.Default.TimeSetting = "3";
            if (rButton6Months.Checked)
                Properties.Settings.Default.TimeSetting = "6";

            Properties.Settings.Default.EtcExtensionList = Extension.userEtcExtension;
            Properties.Settings.Default.DocExtensionList = Extension.docExtension;
            Properties.Settings.Default.AudioExtensionList = Extension.audioExtension;
            Properties.Settings.Default.VideoExtensionList = Extension.videoExtension;
            Properties.Settings.Default.ImageExtensionList = Extension.imgExtension;
            Properties.Settings.Default.CompactExtensionLIst = Extension.compacExtension;

            Properties.Settings.Default.Save();
        }
    }
}
