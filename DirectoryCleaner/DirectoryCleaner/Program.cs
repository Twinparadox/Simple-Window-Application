using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectoryCleaner
{
    static class Program
    {
        private static MainForm mainForm;

        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InitializeSetting();
            mainForm = new MainForm();
            Application.Run(mainForm);
            Application.Exit();
        }

        /// <summary>
        /// 프로그램 실행 전 초기 설정 지정
        /// 경로 지정이 따로 필요할 것 같음
        /// </summary>
        private static void InitializeSetting()
        {
            if(Properties.Settings.Default.TimeSetting.Equals(""))
            {
                Properties.Settings.Default.TimeSetting = "1";
            }
            if(Properties.Settings.Default.LatestPath.Equals(""))
            {
                Properties.Settings.Default.LatestPath=@"C:\";
            }
        }

        public static void OpenMainForm()
        {
            mainForm.ShowDialog();
        }
    }
}
