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
    public partial class StartForm : Form
    {
        /* 저장 경로 */
        private static string saveEnPath = @"C:\TPWord\EWORD.txt";
        private static string saveKrPath = @"C:\TPWord\KWORD.txt";
        private static string saveSettings = @"C:\TPWord\TPSetting.txt";

        /* Reading File and make string */
        private string[] enText;
        private string[] koText;

        /* line */
        private int lineCount;

        /* is already? */
        private bool isAlready;

        public StartForm()
        {
            InitializeComponent();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            txtbxEnglishWord.Select();
        }

        #region Button Methods
        private void btnAdd_Click(object sender, EventArgs e)
        {
            MainForm.log.WriteLine("[Read txt Files...]");
            try
            {
                string[] enText = File.ReadAllLines(saveEnPath, Encoding.GetEncoding("utf-8"));
                string[] koText = File.ReadAllLines(saveKrPath, Encoding.GetEncoding("utf-8"));
                lineCount = File.ReadLines(saveEnPath).Count();
            }
            catch (Exception ex)
            {
                MainForm.log.WriteLine("Ex:" + ex.ToString());
            }
            
            isAlready = false;
            txtbxEnglishWord.Focus();
            string enWord = this.txtbxEnglishWord.Text;
            string koWord = this.txtbxKoreanWord.Text;
            string count = ",0,0";

            if (enWord != "" && koWord != "")
            {
                for(int i=0;i<lineCount;i++)
                {
                    if (enText[i] == enWord + count)
                        isAlready = true;
                }
                if (isAlready == true)
                {
                    MessageBox.Show("이미 입력된 단어입니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MainForm.log.WriteLine("[Append txt Files...]");
                    try
                    {
                        File.AppendAllText(saveEnPath, enWord + count + "\r\n", Encoding.UTF8);
                        File.AppendAllText(saveKrPath, koWord + "\r\n", Encoding.UTF8);
                    }
                    catch (Exception ex)
                    {
                        MainForm.log.WriteLine("Ex:" + ex.ToString());
                    }
                }
                this.txtbxKoreanWord.Text = "";
                this.txtbxEnglishWord.Text = "";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            MainForm.log.WriteLine("[StartForm Close...]");
            try
            {
                int currentSize = File.ReadLines(saveEnPath).Count();
                string[] Setting = Properties.Settings.Default.settings.Split(';');

                Properties.Settings.Default.settings = Setting[0] + ";" + Setting[1] + ";" + currentSize.ToString();
                Properties.Settings.Default.Save();
            }   
            catch (Exception ex)
            {
                MainForm.log.WriteLine("Ex:" + ex.ToString());
            }
            this.Close();
        }
        #endregion
    }
}