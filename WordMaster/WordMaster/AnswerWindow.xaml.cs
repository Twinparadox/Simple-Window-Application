using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WordMaster
{
    /// <summary>
    /// AnswerWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AnswerWindow : Window
    {
        /* Reading File and make string */
        private string[] enText = File.ReadAllLines(WordBook.saveEnPath, Encoding.GetEncoding("utf-8"));
        private string[] koText = File.ReadAllLines(WordBook.saveKrPath, Encoding.GetEncoding("utf-8"));
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

        public AnswerWindow()
        {
            cont = true;
            InitializeComponent();
            
            try
            {
                lineCount = File.ReadLines(WordBook.saveEnPath).Count();
            }
            catch (Exception ex)
            {
            }
            Random r = new Random();
            lineRandom = r.Next(0, lineCount - 1);
            string[] questionStr = enText[lineRandom].Split(sep);
            this.TextBoxEnglish.Text = questionStr[0];
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Focus();
            /*
            if (this.Topmost)
            {
                this.Topmost = false;
                this.Topmost = true;
            }
            else
            {
                this.Topmost = true;
            }
            */
            this.Topmost = true;
        }

        private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (this.TextBoxKorean.Text == koText[lineRandom])
            {
                MessageBox.Show("정답입니다!", "정답", MessageBoxButton.OK, MessageBoxImage.Information);

                ConvertInt();
                correct++;
                ConvertStr();
                this.Close();
            }
            else
            {
                MessageBox.Show("틀렸습니다!", "틀림", MessageBoxButton.OK, MessageBoxImage.Information);

                ButtonSubmit.Visibility = Visibility.Hidden;
                this.TextBoxKorean.Text = koText[lineRandom];
                this.TextBoxKorean.IsEnabled = true;
                Delay(2000);

                ConvertInt();
                ConvertStr();
                this.Close();
            }
        }

        private void ButtonStop_Click(object sender, RoutedEventArgs e)
        {
            cont = false;
            this.Close();
        }

        #region Other Methods
        public bool DoNotContinue()
        {
            return cont;
        }

        /// <summary>
        /// 시간 함수
        /// </summary>
        /// <param name="MS"></param>
        /// <returns></returns>
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

        /// <summary>
        /// int형으로 파싱
        /// </summary>
        private void ConvertInt()
        {
            string[] correctStr = enText[lineRandom].Split(',');
            correct = Int32.Parse(correctStr[1]);
            question = Int32.Parse(correctStr[2]);
            question++;
        }

        /// <summary>
        /// string형으로 변환
        /// 단어의 정보 갱신
        /// </summary>
        private void ConvertStr()
        {
            string tmpPath = WordBook.saveFolderPath+@"\tmp.txt";
            string[] questionStr = enText[lineRandom].Split(sep);
            string correctStr = questionStr[0] + ',' + correct.ToString() + ',' + question.ToString();
            
            try
            {
                StreamWriter tmpFile = File.CreateText(tmpPath);
                tmpFile.Close();
                string sourceFile = System.IO.Path.Combine(WordBook.saveFolderPath, "tmp.txt");
                string destFile = System.IO.Path.Combine(WordBook.saveFolderPath, "EWORD.txt");


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
            catch (Exception ex)
            {
            }
        }
        #endregion
    }
}
