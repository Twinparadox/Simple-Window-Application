﻿using System;
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
        // FileInfo 클래스와 혼동될 수 있으므로 변수 바꿔야..
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
        /// 해시값 비교는 두 파일이 다르다는 걸 입증해줄 수 있을지언정, 같다는 걸 입증할 수는 없음.
        /// </summary>
        #region 중복파일 탐색 및 리스트 생성
        public void CheckDuplicateFiles()
        {
            int size = fileInfos.Count;
            checkTable = new bool?[size, size];
            for (int i = 0; i < size; i++)
            {
                checkTable[i, i] = false;
                for (int j = 0; j < size; j++)
                {
                    if (checkTable[i, j] == null)
                    {
                        checkTable[i, j] = checkTable[j, i] = fileInfos[i].CompareByteToByte(fileInfos[j]);
                    }
                }
            }
        }

        public void MakeDuplicateFileList()
        {
            ListViewDuplicateList.BeginUpdate();
            int size = fileInfos.Count;
            for (int i = 0; i < size; i++)
            {
                int cnt = 0;
                ListViewGroup index = null;
                for (int j = i; j < size; j++)
                {
                    if (checkTable[i, j] == true)
                    {
                        if (cnt == 0)
                        {
                            index = new ListViewGroup(fileInfos[i].GetFileName());
                            ListViewDuplicateList.Groups.Add(index);
                            ListViewDuplicateList.Items.Add(
                                new ListViewItem(new string[]
                                {
                                    Extension.GetKorFileType(fileInfos[i].GetExtensionCode()),
                                    fileInfos[i].GetFileName(),
                                    fileInfos[i].GetDirectoryPath()},
                                index));
                        }
                        ListViewDuplicateList.Items.Add(
                                new ListViewItem(new string[] {
                                    Extension.GetKorFileType(fileInfos[j].GetExtensionCode()),
                                    fileInfos[j].GetFileName(),
                                    fileInfos[j].GetDirectoryPath()},
                                index));
                        cnt++;

                        // 이 부분 너무 비효율적이니, 개선해야 함.
                        for (int k = 0; k < size; k++)
                        {
                            checkTable[j, k] = false;
                        }
                    }
                }
            }
            ListViewDuplicateList.EndUpdate();
        }

        public void RefreshListView()
        {

        }
        #endregion

        #region 버튼 이벤트 처리
        private void ListViewDuplicateList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ListViewDuplicateList.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = ListViewDuplicateList.SelectedItems;
                ListViewItem ListViewItem = items[0];
                try
                {
                    Process.Start(ListViewItem.SubItems[2].Text);
                }
                catch
                {
                    MessageBox.Show("존재하지 않는 경로입니다.", MessageBoxIcon.Error.ToString());
                }
            }
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonDeleteAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("파일이 영구히 삭제됩니다.", "경고", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    foreach(FileList info in fileInfos)
                    {
                        info.DeleteFile();
                    }
                    fileInfos.Clear();
                    ListViewDuplicateList.Clear();

                    MessageBox.Show("모든 파일이 삭제되었습니다.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("오류가 발생했습니다.\n" + ex.Message);
                }
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("파일이 영구히 삭제됩니다.", "경고", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    HashSet<FileList> deleteFileInfoIndex = new HashSet<FileList>();
                    HashSet<int> deleteListViewIndex = new HashSet<int>();
                    ListView.SelectedListViewItemCollection selectedItem = this.ListViewDuplicateList.SelectedItems;
                    int selectedItemSize = selectedItem.Count;
                    int fileInfoSize = fileInfos.Count;

                    // 이미 삭제된 파일을 HashSet에 넣는 비효율 작업 해결 필요.
                    for (int i = 0; i < selectedItemSize; i++)
                    {
                        for (int j = 0; j < fileInfoSize; j++)
                        {
                            if (selectedItem[i].SubItems[1].Text.Equals(fileInfos[j].GetFileName()) == true)
                            {
                                deleteFileInfoIndex.Add(fileInfos[j]);
                                deleteListViewIndex.Add(i);
                            }
                        }
                    }
                    
                    while(selectedItem.Count!=0)
                    {
                        selectedItem[0].Remove();
                    }
                    foreach(FileList info in deleteFileInfoIndex)
                    {
                        info.DeleteFile();
                    }

                    MessageBox.Show("선택한 파일이 삭제되었습니다.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("오류가 발생했습니다.\n" + ex.Message);
                }
            }
        }
        #endregion
    }
}
