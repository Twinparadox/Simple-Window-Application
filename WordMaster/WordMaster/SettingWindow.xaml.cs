using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// SettingWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SettingWindow : Window
    {
        private string defaultTextBoxFrequency = "숫자(분단위)만 입력. 기본값(5분).";

        private string strMin;
        private string alarmSize;

        public SettingWindow()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBoxFrequency_GotFocus(object sender, RoutedEventArgs e)
        {
            if(TextBoxFrequency.Text.Equals(defaultTextBoxFrequency))
            {
                TextBoxFrequency.Text = "";
            }
        }

        private void TextBoxFrequency_LostFocus(object sender, RoutedEventArgs e)
        {
            int min;

            if (Int32.TryParse(TextBoxFrequency.Text, out min) == false)
            {
                if (TextBoxFrequency.Text.Equals(""))
                {
                    TextBoxFrequency.Text = defaultTextBoxFrequency;
                }
                MessageBox.Show("유효하지 않은 시간입니다.", "확인", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            strMin = min.ToString();            
        }

        /*
        private void TextBoxFrequency_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!Char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key != Key.Back | e.Key == Key.Space)
            {
                e.Handled = true;
                MessageBox.Show("숫자만 입력해주세요.\n단위는 분(min)입니다.", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        */

        private void TextBoxFrequency_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
