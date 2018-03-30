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

        /* 현재세팅 */
        private string[] curSettings = Properties.Settings.Default.curSettings.Split(';');

        /* 초기화 */
        private string[] defaultSettings = Properties.Settings.Default.defaultSettings.Split(';');
        private string alarm;
        private string strMin;
        private int size = Properties.Settings.Default.curSize;

        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            alarm = curSettings[0];
            strMin = curSettings[1];

            TextBoxFrequency.Text = strMin;
            if(alarm=="AON")
            {
                rButtonSoundOn.Checked = true;
                rButtonSoundOff.Checked = false;
            }
            else
            {
                rButtonSoundOn.Checked = false;
                rButtonSoundOff.Checked = true;
            }
        }

        #region Button Methods
        /// <summary>
        /// 종료 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            int min;

            if(Int32.TryParse(TextBoxFrequency.Text,out min)==false)
            {
                MessageBox.Show("유효하지 않은 시간입니다.", "확인", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            strMin = min.ToString();
            if (rButtonSoundOn.Checked == true)
            {
                alarm = "AON";
            }
            else
            {
                alarm = "AOFF";
            }
            Properties.Settings.Default.curSettings = alarm + ";" + strMin;
            Properties.Settings.Default.Save();
            this.Close();
        }

        /// <summary>
        /// 설정 & 단어 초기화 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonInitAll_Click(object sender, EventArgs e)
        {
            /* Initialize All(Setting, Word) */
            if (MessageBox.Show("설정을 초기화하고 입력한 단어를 모두 삭제합니다.\r계속하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                InitializeSetting();
                InitializeWord();
            }
        }

        /// <summary>
        /// 시간을 입력받는 박스에 숫자 외에 다른 형태의 값이 입력되는 것을 방지
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxFrequency_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(char.IsDigit(e.KeyChar) || e.KeyChar==Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 설정 초기화 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonInitSet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("설정이 초기화합니다.\r계속하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                InitializeSetting();
            }
        }

        /// <summary>
        /// 단어 초기화 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonInitWord_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("입력한 단어를 모두 삭제합니다.\r계속하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                InitializeWord();
            }
        }
        #endregion

        #region Other Methods
        /// <summary>
        /// 설정 초기화
        /// </summary>
        private void InitializeSetting()
        {
            MainForm.log.WriteLine("[Initialize Settings...]");

            TextBoxFrequency.Text = "5";
            rButtonSoundOn.Checked = true;
            try
            {
                Properties.Settings.Default.curSettings = Properties.Settings.Default.defaultSettings;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MainForm.log.WriteLine("Ex:" + ex.ToString());
            }
        }

        /// <summary>
        /// 단어 초기화
        /// </summary>
        private void InitializeWord()
        {
            MainForm.log.WriteLine("[Clear Word Files...]]");

            try
            {
                StreamWriter enFile = File.CreateText(saveEnPath);
                StreamWriter koFile = File.CreateText(saveKrPath);
                enFile.Close();
                koFile.Close();

                Properties.Settings.Default.curSize = 0;
            }
            catch (Exception ex)
            {
                MainForm.log.WriteLine("Ex:" + ex.ToString());
            }
        }
        #endregion
    }
}