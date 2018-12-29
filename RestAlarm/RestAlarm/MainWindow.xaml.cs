using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace RestAlarm
{
	/// <summary>
	/// MainWindow.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class MainWindow : Window
	{
		public DispatcherTimer mTimer { get; set; }
		public bool mIsPlaying { get; set; }

		public int mRemainigTime { get; set; }
		public int mHours { get; set; }
		public int mMinutes { get; set; }
		public int mSeconds { get; set; }

		public MainWindow()
		{
			InitializeComponent();
			mIsPlaying = false;
			if (Properties.Settings.Default.CustomTimer != 0)
			{
				mRemainigTime = Properties.Settings.Default.CustomTimer;
			}
			else
			{
				mRemainigTime = Properties.Settings.Default.DefaultTimer;
			}
			calculateRemainingTime();
			changeLabelTimer();
		}

		/// <summary>
		/// Change Label
		/// </summary>
		public void changeLabelTimer()
		{
			if (mHours < 10)
			{
				labelTimer.Content = "0" + mHours.ToString();
			}
			else
			{
				labelTimer.Content = mHours.ToString();
			}
			labelTimer.Content += ":";

			if (mMinutes < 10)
			{
				labelTimer.Content += "0" + mMinutes.ToString();
			}
			else
			{
				labelTimer.Content += mMinutes.ToString();
			}
			labelTimer.Content += ":";

			if (mSeconds < 10)
			{
				labelTimer.Content += "0" + mSeconds.ToString();
			}
			else
			{
				labelTimer.Content += mSeconds.ToString();
			}
		}

		/// <summary>
		/// Calculate Time
		/// </summary>
		public void calculateRemainingTime()
		{
			mSeconds = mRemainigTime;
			mHours = mSeconds / 3600;
			mSeconds %= 3600;
			mMinutes = mSeconds / 60;
			mSeconds %= 60;
		}

		public void reloadSettings()
		{
			Properties.Settings.Default.Reload();
			mRemainigTime = Properties.Settings.Default.CustomTimer;
		}

		/// <summary>
		/// Window Loaded Event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			mTimer = new DispatcherTimer
			{
				Interval = TimeSpan.FromSeconds(1)
			};
			mTimer.Tick += mTimerTicker;
		}

		/// <summary>
		/// Setting Button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void settingbutton_Click(object sender, RoutedEventArgs e)
		{
			SettingWindow win = new SettingWindow();
			win.ShowDialog();
		}

		/// <summary>
		/// Clear Button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void clearbutton_Click(object sender, RoutedEventArgs e)
		{
			Properties.Settings.Default.isRepeat = false;
			Properties.Settings.Default.CustomTimer = Properties.Settings.Default.DefaultTimer;
			Properties.Settings.Default.customAlarm = false;
			Properties.Settings.Default.filePath = "";
			Properties.Settings.Default.Save();

			mRemainigTime = Properties.Settings.Default.DefaultTimer;
			calculateRemainingTime();
			changeLabelTimer();
		}

		/// <summary>
		/// Play Button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void playbutton_Click(object sender, RoutedEventArgs e)
		{
			if (mIsPlaying == false)
			{
				mIsPlaying = true;
				calculateRemainingTime();
				if (mRemainigTime <= 0)
				{
					MessageBox.Show("시간을 설정해주세요.", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else
				{
					changeLabelTimer();
					changeButton();
					mTimer.Start();
				}
			}
			else
			{
				mIsPlaying = false;
				changeButton();
				mTimer.Stop();
			}
		}

		/// <summary>
		/// Timer Ticker
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mTimerTicker(object sender, EventArgs e)
		{
			mRemainigTime--;
			if (mRemainigTime==0)
			{
				mIsPlaying = false;
				mTimer.Stop();
				changeButton();
				ringAlarm();
				this.Topmost = false;
				this.Topmost = true;
			}

			if (mSeconds > 0)
			{
				mSeconds--;
			}
			else
			{
				if (mMinutes > 0)
				{
					mMinutes--;
				}
				else
				{
					mHours--;
					mMinutes = 59;
				}
				mSeconds = 59;
			}

			changeLabelTimer();
		}

		/// <summary>
		/// Ringing Alarm
		/// Custom Sound File or System Beep
		/// </summary>
		private void ringAlarm()
		{
			if(Properties.Settings.Default.customAlarm==true)
			{
				SoundPlayer player = new SoundPlayer(Properties.Settings.Default.filePath);
			}
			else
			{
				SystemSounds.Beep.Play();
			}
		}

		/// <summary>
		///  Change Button States
		/// </summary>
		private void changeButton()
		{
			if(mIsPlaying==false)
			{
				playbutton.Content = "▶";
				clearbutton.IsEnabled = true;
				settingbutton.IsEnabled = true;
			}
			else
			{
				playbutton.Content = "∥";
				clearbutton.IsEnabled = false;
				settingbutton.IsEnabled = false;
			}
		}
	}
}
