using System;
using System.Collections.Generic;
using System.IO;
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
        
        /* 현재세팅 */
        private string[] curSettings = Properties.Settings.Default.curSettings.Split(';');

        /* 초기화 */
        private string[] defaultSettings = Properties.Settings.Default.defaultSettings.Split(';');
        private string alarm;
        private string strMin;
        private int size = Properties.Settings.Default.curSize;

        public SettingWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            alarm = curSettings[0];
            strMin = curSettings[1];

            TextBoxFrequency.Text = strMin;
        }

        private void Window_Closed(object sender, EventArgs e)
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

            Properties.Settings.Default.curSettings = alarm + ";" + strMin;
            Properties.Settings.Default.Save();
            this.Close();
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

        private void ButtonInitSetting_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("설정이 초기화합니다.\r계속하시겠습니까?", "확인", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                InitializeSetting();
            }
        }

        private void ButtonInitWord_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("입력한 단어를 모두 삭제합니다.\r계속하시겠습니까?", "확인", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                InitializeWord();
            }
        }

        private void ButtonInitAll_Click(object sender, RoutedEventArgs e)
        {
            /* Initialize All(Setting, Word) */
            if (MessageBox.Show("설정을 초기화하고 입력한 단어를 모두 삭제합니다.\r계속하시겠습니까?", "확인", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                InitializeSetting();
                InitializeWord();
            }
        }

        #region Other Methods
        /// <summary>
        /// 설정 초기화
        /// </summary>
        private void InitializeSetting()
        {
            TextBoxFrequency.Text = "5";
            try
            {
                Properties.Settings.Default.curSettings = Properties.Settings.Default.defaultSettings;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 단어 초기화
        /// </summary>
        private void InitializeWord()
        {
            try
            {
                StreamWriter enFile = File.CreateText(WordBook.saveEnPath);
                StreamWriter koFile = File.CreateText(WordBook.saveKrPath);
                enFile.Close();
                koFile.Close();

                Properties.Settings.Default.curSize = 0;
            }
            catch (Exception ex)
            {
            }
        }
        #endregion
    }
}
