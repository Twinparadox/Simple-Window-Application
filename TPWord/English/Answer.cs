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
using System.Media;

namespace TPWord
{
    public partial class Answer : Form
    {
        /* 저장 경로 */
        private static string saveEnPath = @"C:\TPWord\EWORD.txt";
        private static string saveKrPath = @"C:\TPWord\KWORD.txt";
        private static string saveFolderPath = @"C:\TPWord";

        /* Reading File and make string */
        private string[] enText = File.ReadAllLines(saveEnPath, Encoding.GetEncoding("utf-8"));
        private string[] koText = File.ReadAllLines(saveKrPath, Encoding.GetEncoding("utf-8"));
        private string[] Setting = Properties.Settings.Default.curSettings.Split(';');

        /* contine? */
        private bool cont;

        /* line */
        private int lineCount;
        private int lineRandom;

        /* correct or incorrect */
        private int question;
        private int correct;
        private char sep = ',';

        public Answer()
        {
            cont = true;
            InitializeComponent();

            MainForm.log.WriteLine("[Read saveEnPath.txt...]");
            try
            {
                lineCount = File.ReadLines(saveEnPath).Count();
            }
            catch(Exception ex)
            {
                MainForm.log.WriteLine("Ex: " + ex.ToString());
            }
            Random r = new Random();
            lineRandom = r.Next(0, lineCount - 1);
            string[] questionStr = enText[lineRandom].Split(sep);
            this.TextBoxEnglish.Text = questionStr[0];
        }

        private void Answer_Load(object sender, EventArgs e)
        {
            // Form Focus
            this.Focus();
            if (this.TopMost)
            {
                this.TopMost = false;
                this.TopMost = true;
            }
            else
            {
                this.TopMost = true;
            }


            ConvertInt();
            if (Setting[1] == "AON")
            {
                SystemSounds.Beep.Play();
            }
        }

        #region Button Methods
        private void ButtonAdmit_Click(object sender, EventArgs e)
        {
            if (this.TextBoxKorean.Text == koText[lineRandom])
            {
                MessageBox.Show("정답입니다!", "정답", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ConvertInt();
                correct++;
                ConvertStr();
                this.Close();
            }
            else
            {
                MessageBox.Show("틀렸습니다!", "틀림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ButtonAdmit.Visible = false;
                this.TextBoxKorean.Text = koText[lineRandom];
                this.TextBoxKorean.ReadOnly = true;
                Delay(2000);

                ConvertInt();
                ConvertStr();
                this.Close();
            }
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            cont = false;
            this.Close();
        }
        #endregion

        #region Other Methods
        public bool DoNotContinue()
        {
            return cont;
        }

        // 시간 관리
        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);
            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }
            return DateTime.Now;
        }

        // 정수 변환 함수
        private void ConvertInt()
        {
            string[] correctStr = enText[lineRandom].Split(',');
            correct = Int32.Parse(correctStr[1]);
            question = Int32.Parse(correctStr[2]);
            question++;
        }

        // 문자열 변환 함수
        private void ConvertStr()
        {
            string tmpPath = @"C:\TPWord\tmp.txt";
            string[] questionStr = enText[lineRandom].Split(sep);
            string correctStr = questionStr[0] + ',' + correct.ToString() + ',' + question.ToString();

            MainForm.log.WriteLine("[Modify txt files...]");
            try
            {
                StreamWriter tmpFile = File.CreateText(tmpPath);
                tmpFile.Close();
                string sourceFile = Path.Combine(saveFolderPath, "tmp.txt");
                string destFile = Path.Combine(saveFolderPath, "EWORD.txt");


                for (int i = 0; i < lineCount; i++)
                {
                    if (i == lineRandom)
                    {
                        File.AppendAllText(tmpPath, correctStr + "\r\n");
                    }
                    else
                    {
                        File.AppendAllText(tmpPath, enText[i] + "\r\n");
                    }
                }

                File.Copy(sourceFile, destFile, true);
                File.Delete(tmpPath);
            }
            catch(Exception ex)
            {
                MainForm.log.WriteLine("Ex: " + ex.ToString());
            }
        }
        #endregion
    }
}