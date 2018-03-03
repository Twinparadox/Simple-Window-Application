﻿using System;
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
            int min;

            if(Int32.TryParse(txtbxFrequency.Text,out min)==false)
            {
                MessageBox.Show("유효하지 않은 시간입니다.", "확인", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            strMin = min.ToString();
            if (rbtnSoundOn.Checked == true)
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

        private void btnInitAll_Click(object sender, EventArgs e)
        {
            /* Initialize All(Setting, Word) */
            if (MessageBox.Show("설정을 초기화하고 입력한 단어를 모두 삭제합니다.\r계속하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                InitializeSetting();
                InitializeWord();
            }
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
            if (MessageBox.Show("설정이 초기화합니다.\r계속하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                InitializeSetting();
            }
        }

        private void btnInitWord_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("입력한 단어를 모두 삭제합니다.\r계속하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                InitializeWord();
            }
        }
        #endregion

        #region Other Methods
        private void InitializeSetting()
        {
            MainForm.log.WriteLine("[Initialize Settings...]");

            txtbxFrequency.Text = "5";
            rbtnSoundOn.Checked = true;
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