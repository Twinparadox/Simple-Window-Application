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
        static string saveEnPath = @"C:\TPWord\EWORD.txt";
        static string saveKrPath = @"C:\TPWord\KWORD.txt";
        static string saveSettings = @"C:\TPWord\TPSetting.txt";


        /* 세팅 */
        private string[] Setting = File.ReadAllLines(saveSettings, Encoding.GetEncoding("utf-8"));

        /* 초기화 */
        static string alarm = "AON";
        static string strMin = "5";
        static string initSize = "0";

        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            txtbxFrequency.Text = Setting[0];
            if(Setting[1]=="AON")
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            int currentSize = File.ReadLines(saveEnPath).Count();
            File.WriteAllText(saveSettings,txtbxFrequency.Text + "\r\n", Encoding.UTF8);
            if (rbtnSoundOn.Checked == true)
            {
                File.AppendAllText(saveSettings, alarm + "\r\n", Encoding.UTF8);
            }
            else
            {
                File.AppendAllText(saveSettings, "AOFF\r\n", Encoding.UTF8);
            }
            File.AppendAllText(saveSettings, currentSize + "\r\n", Encoding.UTF8);
            this.Close();
        }

        private void btnInitAll_Click(object sender, EventArgs e)
        {
            /* Remake txt file */
            StreamWriter enFile=File.CreateText(saveEnPath);
            StreamWriter koFile=File.CreateText(saveKrPath);
            enFile.Close();
            koFile.Close();

            /* Initialize Setting */
            txtbxFrequency.Text = strMin;
            rbtnSoundOn.Checked = true;
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
                int currentSize = File.ReadLines(saveEnPath).Count();

                /* Initialize Setting */
                txtbxFrequency.Text = strMin;
                rbtnSoundOn.Checked = true;
                File.WriteAllText(saveSettings, strMin + "\r\n", Encoding.UTF8);
                File.AppendAllText(saveSettings, alarm + "\r\n", Encoding.UTF8);
                File.AppendAllText(saveSettings, currentSize + "\r\n", Encoding.UTF8);
            }
        }

        private void btnInitWord_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("입력하신 단어가 모두 삭제됩니다.\r계속하시겠습니까?","확인",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                File.CreateText(saveEnPath);
                File.CreateText(saveKrPath);
            }
        }
    }
}