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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RestAlarm
{
	/// <summary>
	/// SettingWindow.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class SettingWindow : Window
	{
		public bool mCustomSound { get; set; }
		public string mCustomFilePath { get; set; }

        public SettingWindow()
        {
            InitializeComponent();
        }

		/// <summary>
		/// Window Loaded Event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			if(Properties.Settings.Default.customAlarm==false)
			{
				mCustomSound = false;
				rButtonBeep.IsChecked = true;
			}
			else
			{
				mCustomSound = true;
				rButtonCustom.IsChecked = true;
			}
			textBoxFilePath.Text = Properties.Settings.Default.filePath;

			int hrs, mins, secs;
			secs = Properties.Settings.Default.CustomTimer;

			hrs = secs / 3600;
			secs %= 3600;
			mins = secs / 60;
			secs %= 60;

			textBoxHours.Text = hrs.ToString();
			textBoxMinutes.Text = mins.ToString();
			textBoxSeconds.Text = secs.ToString();
		}

		/// <summary>
		/// rButtonBeep Checked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rButtonBeep_Checked(object sender, RoutedEventArgs e)
		{
			mCustomSound = false;
		}

		/// <summary>
		/// rButtonCustom Checked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rButtonCustom_Checked(object sender, RoutedEventArgs e)
		{
			mCustomSound = true;
		}

		/// <summary>
		/// Find Button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonFind_Click(object sender, RoutedEventArgs e)
		{
			settingPath();
		}

		/// <summary>
		/// TextBox DoubleClick Event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void textBoxFilePath_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			settingPath();
		}

		/// <summary>
		/// Set Path of Custom Alarm File
		/// </summary>
		private void settingPath()
		{
			Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();

			dialog.DefaultExt = ".mp3";
			dialog.Filter = "MP3 Files (*.mp3)|*.mp3|WAV Files (*.wav)|*.wav";

			Nullable<bool> result = dialog.ShowDialog();

			if(result==true)
			{
				mCustomFilePath = dialog.FileName;
				textBoxFilePath.Text = mCustomFilePath;
			}
		}

		/// <summary>
		/// Save Button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void savebutton_Click(object sender, RoutedEventArgs e)
		{
			if(rButtonCustom.IsChecked==true && File.Exists(textBoxFilePath.Text)==false)
			{
				System.Windows.MessageBox.Show("올바르지 않은 파일 경로입니다.\n 올바른 경로를 지정해주세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			Properties.Settings.Default.filePath = mCustomFilePath;
			Properties.Settings.Default.customAlarm = (rButtonCustom.IsChecked == true) ? true : false;
			Properties.Settings.Default.CustomTimer = int.Parse(textBoxHours.Text) * 3600 + int.Parse(textBoxMinutes.Text) * 60 + int.Parse(textBoxSeconds.Text);
			Properties.Settings.Default.Save();
			Properties.Settings.Default.Reload();

			((MainWindow)System.Windows.Application.Current.MainWindow).reloadSettings();
			((MainWindow)System.Windows.Application.Current.MainWindow).calculateRemainingTime();
			((MainWindow)System.Windows.Application.Current.MainWindow).changeLabelTimer();
			this.Close();
		}
	}
}
