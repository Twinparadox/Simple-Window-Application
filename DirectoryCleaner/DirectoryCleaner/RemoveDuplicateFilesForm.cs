using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public List<FileInfo> fileInfos;

        private string extension = Extension.curExtension;
        private string[] extensionList;

        public RemoveDuplicateFilesForm()
        {
            InitializeComponent();
            extensionList = extension.Split(',');
            ApplyAllFiles(MainForm.pTextPath.Text, SearchFile);
            CheckDuplicateFiles();
        }        

        #region 파일 탐색 & 목록 저장
        private void SearchFile(string searchPath)
        {
            if (File.Exists(searchPath))
            {
                try
                {
                    fileInfos.Add(new FileInfo(searchPath));
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

        #region 중복파일 탐색 및 리스트 생성
        public void CheckDuplicateFiles()
        {

        }

        public bool CompareFilesHash(FileInfo source, FileInfo compare)
        {
            byte[] sourceHash = MD5.Create().ComputeHash(source.OpenRead());
            byte[] compareHash = MD5.Create().ComputeHash(compare.OpenRead());

            for (int i = 0; i < sourceHash.Length; i++)
            {
                if (sourceHash[i] != compareHash[i])
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
