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
    public partial class AddForm : Form
    {
        /* 저장 경로 */
        private static string saveEnPath = @"C:\TPWord\EWORD.txt";
        private static string saveKrPath = @"C:\TPWord\KWORD.txt";

        /* Reading File and make string */
        private string[] enText;
        private string[] koText;

        /* line */
        private int lineCount;

        /* is already? */
        private bool isAlready;

        public AddForm()
        {
            InitializeComponent();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            TextBoxEnglishWord.Select();
        }

        #region Button Methods
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            MainForm.log.WriteLine("[Read txt Files...]");
            try
            {
                string[] enText = File.ReadAllLines(saveEnPath, Encoding.GetEncoding("utf-8"));
                string[] koText = File.ReadAllLines(saveKrPath, Encoding.GetEncoding("utf-8"));
                lineCount = Properties.Settings.Default.curSize;
            }
            catch (Exception ex)
            {
                MainForm.log.WriteLine("Ex:" + ex.ToString());
            }
            
            isAlready = false;
            TextBoxEnglishWord.Focus();
            string enWord = this.TextBoxEnglishWord.Text;
            string koWord = this.TextBoxKoreanWord.Text;
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
                this.TextBoxKoreanWord.Text = "";
                this.TextBoxEnglishWord.Text = "";
            }
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            MainForm.log.WriteLine("[StartForm Close...]");
            try
            {
                lineCount = File.ReadLines(saveEnPath).Count();
                string[] Setting = Properties.Settings.Default.curSettings.Split(';');

                Properties.Settings.Default.curSettings = Setting[0] + ";" + Setting[1];
                Properties.Settings.Default.curSize = lineCount;
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
