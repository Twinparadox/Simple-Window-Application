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

namespace TPWord
{
    public partial class SettingForm : Form
    {
        /* 저장 경로 */
        private static string saveEnPath = @"C:\TPWord\EWORD.txt";
        private static string saveKrPath = @"C:\TPWord\KWORD.txt";
        private static string saveSettings = @"C:\TPWord\TPSetting.txt";


        /* 세팅 */
        private string[] Setting = File.ReadAllLines(saveSettings, Encoding.GetEncoding("utf-8"));

        /* 초기화 */
        private string[] options = Properties.Settings.Default.settings.Split(';');
        private string alarm;
        private string strMin;
        private string initSize;

        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            alarm = options[0];
            strMin = options[1];
            initSize = options[2];

            txtbxFrequency.Text = strMin;
            if(alarm=="AON")
            {
                rbtnSoundOn.Checked = true;
                rbtnSoundOff.Checked = false;
            }
            else
            {
                rbtnSoundOn.Checked = false;
                rbtnSoundOff.Checked = true;
            }
        }

        #region Button Methods
        private void btnClose_Click(object sender, EventArgs e)
        {
            int currentSize = File.ReadLines(saveEnPath).Count();
            strMin = txtbxFrequency.Text;
            if (rbtnSoundOn.Checked == true)
            {
                alarm = "AON";
            }
            else
            {
                alarm = "AOFF";
            }
            initSize = currentSize.ToString();

            Properties.Settings.Default.settings = alarm + ";" + strMin + ";" + initSize;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void btnInitAll_Click(object sender, EventArgs e)
        {
            /* Remake txt file */
            MainForm.log.WriteLine("[Remake txt Files...]");
            try
            {
                StreamWriter enFile = File.CreateText(saveEnPath);
                StreamWriter koFile = File.CreateText(saveKrPath);
                enFile.Close();
                koFile.Close();
            }
            catch(Exception ex)
            {
                MainForm.log.WriteLine("Ex:" + ex.ToString());
            }
            InitializeSetting();
        }

        private void txtbxFrequency_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(char.IsDigit(e.KeyChar) || e.KeyChar==Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void btnInitSet_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("모든 설정이 초기화 됩니다.\r계속하시겠습니까?","확인",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                InitializeSetting();
            }
        }

        private void btnInitWord_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("입력하신 단어가 모두 삭제됩니다.\r계속하시겠습니까?","확인",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                MainForm.log.WriteLine("[Clear Word Files...]]");
                try
                {
                    File.CreateText(saveEnPath);
                    File.CreateText(saveKrPath);
                }
                catch (Exception ex)
                {
                    MainForm.log.WriteLine("Ex:" + ex.ToString());
                }
            }
        }
        #endregion

        #region Other Methods
        private void InitializeSetting()
        {
            MainForm.log.WriteLine("[Initialize Settings...]");
            int currentSize = File.ReadLines(saveEnPath).Count();

            /* Initialize Setting */
            txtbxFrequency.Text = "5";
            rbtnSoundOn.Checked = true;
            try
            {
                alarm = options[0] = "AON";
                strMin = options[1] = "5";
                initSize = options[2] = currentSize.ToString();
                Properties.Settings.Default.settings = alarm + ";" + strMin + ";" + initSize;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MainForm.log.WriteLine("Ex:" + ex.ToString());
            }
        }
        #endregion
    }
}