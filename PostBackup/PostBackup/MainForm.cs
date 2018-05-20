using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostBackup
{
    public partial class MainForm : Form
    {
        public static string savePath = "";
        public static string blogURL = "";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 현재 실행 중 경로
            txtSavePath.Text = System.IO.Directory.GetCurrentDirectory();
        }

        #region Button Methods
        private void btnFinder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            string selectedDialog = dialog.SelectedPath;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            blogURL = txtLink.Text;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
