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
            if (this.Topmost)
            {
                this.Topmost = false;
                this.Topmost = true;
            }
            else
            {
                this.Topmost = true;
            }
        }
    }
}
