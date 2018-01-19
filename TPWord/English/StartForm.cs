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
    public partial class StartForm : Form
    {
        /* 저장 경로 */
        static string saveEnPath = @"C:\TPWord\EWORD.txt";
        static string saveKrPath = @"C:\TPWord\KWORD.txt";
        static string saveSettings = @"C:\TPWord\TPSetting.txt";

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string[] enText = File.ReadAllLines(saveEnPath, Encoding.GetEncoding("utf-8"));
            string[] koText = File.ReadAllLines(saveKrPath, Encoding.GetEncoding("utf-8"));
            isAlready = false;
            txtbxEnglishWord.Focus();
            string enWord = this.txtbxEnglishWord.Text;
            string koWord = this.txtbxKoreanWord.Text;
            string count = ",0,0";
            lineCount = File.ReadLines(saveEnPath).Count();

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
                    try
                    {
                        File.AppendAllText(saveEnPath, enWord + count + "\r\n", Encoding.UTF8);
                        File.AppendAllText(saveKrPath, koWord + "\r\n", Encoding.UTF8);
                    }
                    catch (Exception ex)
                    { }
                }
                this.txtbxKoreanWord.Text = "";
                this.txtbxEnglishWord.Text = "";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                int currentSize = File.ReadLines(saveEnPath).Count();
                string[] Setting = File.ReadAllLines(saveSettings);

                File.WriteAllText(saveSettings, Setting[0] + "\r\n", Encoding.UTF8);
                File.AppendAllText(saveSettings, Setting[1] + "\r\n", Encoding.UTF8);
                File.AppendAllText(saveSettings, currentSize + "\r\n", Encoding.UTF8);
            }
            catch (Exception ex)
            { }
            this.Close();
        }
    }
}
