using System;
using System.Collections.Generic;
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

        public AddWordWindow()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
        }
    }
}
