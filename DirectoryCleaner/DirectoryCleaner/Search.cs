using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Security.Permissions;
using System.Security.Principal;
using System.Collections;

namespace DirectoryCleaner
{
    public partial class Search : Form
    {
        private string extension = Extension.curExtension;
        private string[] extensionList;
        private string movePath;
        public static int[] sortStatus=new int[5];

        public Search()
        {
            InitializeComponent();
            SetColumnWidth();
            extensionList = extension.Split(',');
            ApplyAllFiles(MainForm.pTextPath.Text, SearchFile);
            for (int i = 0; i < 5; i++)
                sortStatus[i] = 1;
        }

        #region 파일 탐색 & 목록 저장
        private void SearchFile(string searchPath)
        {
            if (File.Exists(searchPath))
            {
                try
                {
                    FileInfo item = new FileInfo(searchPath);

                    ListViewFileList.BeginUpdate();
                    if (item.Attributes == FileAttributes.System)
                    {
                        ListViewFileList.EndUpdate();
                        return;
                    }
                    if (IsExist(item))
                    {
                        string fileName = GetPureFileName(item.Name);
                        string fileSize = item.Length.ToString();
                        string directoryName = item.DirectoryName;
                        string accessTime = item.LastAccessTime.ToString();

                        fileSize = (Double.Parse(fileSize) / 1024.0).ToString("0.#");
                        ListViewItem tmp = new ListViewItem(new String[] { fileName, directoryName, accessTime, fileSize });
                        this.ListViewFileList.Items.Add(tmp);
                    }
                }
                catch (UnauthorizedAccessException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            ListViewFileList.EndUpdate();
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

        // 파일 이름 추출
        private string GetPureFileName(string filename)
        {
            string pureName;
            pureName = filename.Substring(0, filename.LastIndexOf('.'));
            pureName += filename.Substring(filename.LastIndexOf('.'));
            return pureName;
        }

        // 파일 존재 여부 확인
        private bool IsExist(FileInfo item)
        {
            DateTime date = DateTime.Now;
            int settingDate = Int32.Parse(Properties.Settings.Default.TimeSetting);
            date = date.AddMonths(-settingDate);
            for (int i = 0; i < extensionList.Length; i++)
            {
                if (("." + extensionList[i]).Equals(item.Extension) && DateTime.Compare(item.LastAccessTime, date) <= 0)
                    return true;
            }
            return false;
        }

        // 폼 닫히는 경우 업데이트 종료
        private void Search_FormClosed(object sender, FormClosedEventArgs e)
        {
            ListViewFileList.EndUpdate();
        }

        // 확인
        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 새로고침
        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            ListViewFileList.BeginUpdate();
            ListViewFileList.Items.Clear();
            ApplyAllFiles(MainForm.pTextPath.Text, SearchFile);
            ListViewFileList.EndUpdate();
        }

        // 삭제
        private void ButtonDeleteSelect_Click(object sender, EventArgs e)
        {
            int i = 0;
            ListView.SelectedListViewItemCollection selectedItems = ListViewFileList.SelectedItems;
            ListView.SelectedIndexCollection items = ListViewFileList.SelectedIndices;

            while (items.Count>0)
            {
                string remove = selectedItems[i].SubItems[1].Text + @"\" + selectedItems[i].Text;
                FileInfo removeFile = new FileInfo(remove);
                if (removeFile.Exists)
                {
                    removeFile.Delete();
                }
                ListViewFileList.Items[i].Remove();
            }
            ListViewFileList.Refresh();
        }
        
        // 일괄 이동
        private void ButtonMove_Click(object sender, EventArgs e)
        {
            int i = 0;
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            movePath = dialog.SelectedPath;

            ListView.SelectedListViewItemCollection selectedItems = ListViewFileList.SelectedItems;
            ListView.SelectedIndexCollection items = ListViewFileList.SelectedIndices;

            while (items.Count>0)
            {
                string move = selectedItems[i].SubItems[1].Text + @"\" + selectedItems[i].Text;
                FileInfo moveFile = new FileInfo(move);
                if (moveFile.Exists)
                {
                    try
                    {
                        moveFile.MoveTo(movePath + @"\" + selectedItems[i].Text);
                        ListViewFileList.Items[i].SubItems[1].Text = movePath;
                    }
                    catch
                    {
                        // 중복 시, 상위 폴더 명을 접합
                        string tmp = CreateAdditionalString(selectedItems[i].SubItems[1].Text);
                        moveFile.MoveTo(movePath + @"\" + tmp + selectedItems[i].Text);
                        ListViewFileList.Items[i].SubItems[1].Text = movePath;
                    }
                }
                ListViewFileList.Items[i].Remove();
            }
            ListViewFileList.Refresh();
        }

        // 중복 시 파일에 폴더명 추가
        private string CreateAdditionalString(string s)
        {
            string[] tmp=s.Split('\\');
            return tmp[tmp.Length - 1];
        }

        // 더블클릭 이벤트
        private void ListViewFileList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ListViewFileList.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = ListViewFileList.SelectedItems;
                ListViewItem ListViewItem = items[0];
                try
                {
                    Process.Start(ListViewItem.SubItems[1].Text);
                }
                catch
                {
                    MessageBox.Show("존재하지 않는 경로입니다.", MessageBoxIcon.Error.ToString());
                }
            }
        }

        #region 반응형
        private void ListViewResizing()
        {
            ListViewFileList.Width = this.Size.Width * 98 / 100 - 10;
            ListViewFileList.Height = this.Size.Height * 80 / 100 - 10;
            SetColumnWidth();
            ButtonAccept.Left = this.Size.Width * 98 / 100 - ButtonAccept.Width - 8;
            ButtonRefresh.Left= this.Size.Width * 98 / 100 - ButtonAccept.Width - ButtonRefresh.Width - 10;
        }

        private void ListViewFileList_Resize(object sender, EventArgs e)
        {
        //    ListViewResizing((ListView)sender);
        }

        private void Search_ResizeBegin(object sender, EventArgs e)
        {
        //    ListViewResizing((ListView)sender);
        }

        private void Search_Resize(object sender, EventArgs e)
        {
            ListViewResizing();
        }

        private void SetColumnWidth()
        {
            ListViewFileList.Columns[0].Width = ListViewFileList.Width * 20 / 100;
            ListViewFileList.Columns[1].Width = ListViewFileList.Width * 50 / 100;
            ListViewFileList.Columns[2].Width = ListViewFileList.Width * 20 / 100;
            ListViewFileList.Columns[3].Width = ListViewFileList.Width * 10 / 100;
        }

        private void Search_Load(object sender, EventArgs e)
        {
            SetColumnWidth();
        }
        #endregion

        private void ListViewFileList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region Column Sorting
        private void ListViewFileList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.ListViewFileList.ListViewItemSorter = new ListViewItemComparer(e.Column);
            if (sortStatus[e.Column] == 1)
                sortStatus[e.Column] = 2;
            else
                sortStatus[e.Column] = 1;
        }

        class ListViewItemComparer : IComparer
        {
            private int col;
            public ListViewItemComparer()
            {
                col = 0;
            }
            public ListViewItemComparer(int column)
            {
                col = column;
            }
            public int Compare(object x, object y)
            {
                if (col == 0 || col == 1 || col == 2)
                {
                    if (sortStatus[col] == 1)
                        return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
                    else
                        return -String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
                }
                else
                {
                    double dx, dy;
                    dx = Double.Parse(((ListViewItem)x).SubItems[col].Text);
                    dy = Double.Parse(((ListViewItem)y).SubItems[col].Text);
                    if (sortStatus[col] == 1)
                    {
                        if (dx < dy)
                            return -1;
                        else if (dx == dy)
                            return 0;
                        else
                            return 1;
                    }
                    else
                    {
                        if (dx < dy)
                            return 1;
                        else if (dx == dy)
                            return 0;
                        else
                            return -1;
                    }
                }
            }
        }
        #endregion
    }
}
