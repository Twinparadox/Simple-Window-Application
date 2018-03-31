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
    /// SettingWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SettingWindow : Window
    {
        private string defaultTextBoxFrequency = "숫자(분단위)만 입력. 기본값(5분).";

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
            if(TextBoxFrequency.Text.Equals(""))
            {
                TextBoxFrequency.Text = defaultTextBoxFrequency;
            }
        }
    }
}
