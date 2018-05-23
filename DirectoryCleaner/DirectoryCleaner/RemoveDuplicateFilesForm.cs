using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectoryCleaner
{
    public partial class RemoveDuplicateFilesForm : Form
    {
        private List<FileList> fileInfos = null;

        private bool?[,] checkTable;

        private string extension = Extension.curExtension;
        private string[] extensionList;

        public RemoveDuplicateFilesForm()
        {
            InitializeComponent();

            extensionList = extension.Split(',');
            fileInfos = new List<FileList>();

            ApplyAllFiles(MainForm.pTextPath.Text, SearchFile);
            CheckDuplicateFiles();
            MakeDuplicateFileList();
        }        

        #region 파일 탐색 & 목록 저장
        private void SearchFile(string searchPath)
        {
            if (File.Exists(searchPath))
            {
                try
                {
                    fileInfos.Add(new FileList(searchPath));
                }
                catch (UnauthorizedAccessException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void ApplyAllFiles(string directory, Action<string> fileAction)
        {
            foreach (string file in Directory.GetFiles(directory))
            {
                fileAction(file);
            }
            foreach (string subDir in Directory.GetDirectories(directory))
            {
                try
                {
                    ApplyAllFiles(subDir, fileAction);
                }
                catch (Exception ex)
                {
                }
            }
        }
        #endregion

        /// <summary>
        /// 단순 해싱 비교 200개 기준 약 0.2초 소요 (LSF가 없는 경우)
        /// LSF가 있는 경우 엄청난 시간 소요됨.
        /// </summary>
        #region 중복파일 탐색 및 리스트 생성
        public void CheckDuplicateFiles()
        {
            int size = fileInfos.Count;
            checkTable = new bool?[size, size];
            for(int i=0;i<size;i++)
            {
                checkTable[i, i] = false;
                for (int j = 0; j < size; j++)
                {
                    if (checkTable[i, j] == null)
                    {
                        checkTable[i, j] = checkTable[j, i] = fileInfos[i].CompareHashCode(fileInfos[j]);
                    }
                }
            }
        }
        public void MakeDuplicateFileList()
        {
            ListViewDuplicateList.BeginUpdate();
            int size = fileInfos.Count;
            for(int i=0;i<size;i++)
            {
                for(int j=i;j<size;j++)
                {
                    if(checkTable[i,j]==true)
                    {
                        ListViewItem item = new ListViewItem(fileInfos[i].GetFilePath());
                        ListViewDuplicateList.Items.Add(item);
                    }
                }
            }
            ListViewDuplicateList.EndUpdate();
        }
        #endregion

        /// <summary>
        /// 리스트 확인을 위해서 임시로 생성함.
        /// 차후 중복파일들을 그룹 형식으로 노출할 것
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewDuplicateList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ListViewDuplicateList.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = ListViewDuplicateList.SelectedItems;
                ListViewItem ListViewItem = items[0];
                try
                {
                    Process.Start(ListViewItem.SubItems[0].Text);
                }
                catch
                {
                    MessageBox.Show("존재하지 않는 경로입니다.", MessageBoxIcon.Error.ToString());
                }
            }
        }
    }
}
