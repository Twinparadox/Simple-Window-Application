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
    /// AddWordWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AddWordWindow : Window
    {
        private string defaultTextboxEng = "영단어를 입력해주세요.";
        private string defaultTextboxKor = "단어의 뜻을 입력해주세요.";

        /* Reading File and make string */
        private string[] enText = null;
        private string[] koText = null;

        /* line */
        private int lineCount;

        /* is already? */
        private bool isAlready;

        public AddWordWindow()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                lineCount=File.ReadLines(WordBook.saveEnPath).Count();
            }
            catch(Exception ex)
            {
            }
            finally
            {
                Properties.Settings.Default.curSize = lineCount;
                Properties.Settings.Default.Save();
            }
        }

        private void TextBoxEnglishWord_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxEnglishWord.Text.Equals(defaultTextboxEng))
            {
                TextBoxEnglishWord.Text = "";
            }
        }

        private void TextBoxKoreanWord_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxKoreanWord.Text.Equals(defaultTextboxKor))
            {
                TextBoxKoreanWord.Text = "";
            }
        }

        private void TextBoxEnglishWord_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxEnglishWord.Text.Equals(""))
            {
                TextBoxEnglishWord.Text = defaultTextboxEng;
            }
        }

        private void TextBoxKoreanWord_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxKoreanWord.Text.Equals(""))
            {
                TextBoxKoreanWord.Text = defaultTextboxKor;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxEnglishWord.Text.Equals(defaultTextboxEng))
            {
                MessageBox.Show("영어 단어를 입력해주세요.");
                return;
            }
            if(TextBoxKoreanWord.Text.Equals(defaultTextboxKor))
            {
                MessageBox.Show("단어의 뜻을 입력해주세요.");
                return;
            }
            try
            {
                enText = File.ReadAllLines(WordBook.saveEnPath, Encoding.GetEncoding("utf-8"));
                koText = File.ReadAllLines(WordBook.saveKrPath, Encoding.GetEncoding("utf-8"));
                lineCount = Properties.Settings.Default.curSize;
            }
            catch (Exception ex)
            {
            }

            isAlready = false;
            TextBoxEnglishWord.Focus();
            string enWord = this.TextBoxEnglishWord.Text;
            string koWord = this.TextBoxKoreanWord.Text;
            string count = ",0,0";

            if (enWord != "" && koWord != "")
            {
                for (int i = 0; i < lineCount; i++)
                {
                    if (enText[i] == enWord + count)
                        isAlready = true;
                }
                if (isAlready == true)
                {
                    MessageBox.Show("이미 입력된 단어입니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    try
                    {
                        File.AppendAllText(WordBook.saveEnPath, enWord + count + "\r\n", Encoding.UTF8);
                        File.AppendAllText(WordBook.saveKrPath, koWord + "\r\n", Encoding.UTF8);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                this.TextBoxKoreanWord.Text = defaultTextboxKor;
                this.TextBoxEnglishWord.Text = defaultTextboxEng;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Topmost = true;
            this.Focus();
        }
    }
}
