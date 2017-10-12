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
        static string saveEnPath = @"C:\TPWord\EWORD.txt";
        static string saveKrPath = @"C:\TPWord\KWORD.txt";
        static string saveSettings = @"C:\TPWord\TPSetting.txt";
        static string saveFolderPath = @"C:\TPWord";

        /* Reading File and make string */
        private string[] enText = File.ReadAllLines(saveEnPath, Encoding.GetEncoding("utf-8"));
        private string[] koText = File.ReadAllLines(saveKrPath, Encoding.GetEncoding("utf-8"));
        private string[] Setting = File.ReadAllLines(saveSettings, Encoding.GetEncoding("utf-8"));

        /* contine? */
        private bool cont;

        /* line */
        private int lineCount;
        private int lineRandom;

        /* correct or incorrect */
        private int question;
        private int correct;
        private char sep = ',';

        /* 창 최상위 */
        private bool isTopMost = false;


        public Answer()
        {
            isTopMost = false;
            cont = true;
            InitializeComponent();
            lineCount = File.ReadLines(saveEnPath).Count();
            Random r = new Random();
            lineRandom = r.Next(0, lineCount - 1);
            string[] questionStr = enText[lineRandom].Split(sep);
            this.txtbxEnglish.Text = questionStr[0];
        }

        private void Answer_Load(object sender, EventArgs e)
        {
            // Form Focus
            this.Focus();
            if (this.TopMost)
            {
                isTopMost = true;
                this.TopMost = false;
                this.TopMost = true;
            }
            else
            {
                this.TopMost = true;
            }


            convertInt();
            if (Setting[1] == "AON")
            {
                SystemSounds.Beep.Play();
            }
        }

        private void btnAdmit_Click(object sender, EventArgs e)
        {
            if (this.txtbxKorean.Text == koText[lineRandom])
            {
                correct++;
                MessageBox.Show("정답입니다!", "정답", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isTopMost = false;
                convertStr();
                this.Close();
            }
            else
            {
                MessageBox.Show("틀렸습니다!", "틀림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isTopMost = false;
                convertStr();
                btnAdmit.Visible = false;
                this.txtbxKorean.Text = koText[lineRandom];
                this.txtbxKorean.ReadOnly = true;
                Delay(2000);
                this.Close();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            cont = false;
            isTopMost = false;
            this.Close();
        }

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
        private void convertInt()
        {
            string[] correctStr = enText[lineRandom].Split(',');
            correct = Int32.Parse(correctStr[1]);
            question = Int32.Parse(correctStr[2]);
            question++;
        }

        // 문자열 변환 함수
        private void convertStr()
        {
            string tmpPath = @"C:\TPWord\tmp.txt";
            string[] questionStr = enText[lineRandom].Split(sep);
            string correctStr = questionStr[0] + ',' + correct + ',' + question;
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
    }
}