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
        private List<FileInfo> fileInfos = null;

        private bool?[,] checkTable;

        private string extension = Extension.curExtension;
        private string[] extensionList;

        public RemoveDuplicateFilesForm()
        {
            InitializeComponent();

            extensionList = extension.Split(',');
            fileInfos = new List<FileInfo>();

            ApplyAllFiles(MainForm.pTextPath.Text, SearchFile);
            CheckDuplicateFiles();
            MessageBox.Show("Hellos");
        }        

        #region 파일 탐색 & 목록 저장
        private void SearchFile(string searchPath)
        {
            if (File.Exists(searchPath))
            {
                try
                {
                    FileInfo item = new FileInfo(searchPath);
/*
                    string fileType = Extension.CheckExtensionType(item.Extension.Substring(1, item.Extension.Length - 1));
                    switch (fileType)
                    {
                        case "":
                            break;
                        case "Audio":
                            break;
                        case "Compac":
                            break;
                        case "Dev":
                            break;
                        case "Disc":
                            break;
                        case "Doc":
                            break;
                        case "Etc":
                            break;
                        case "Image":
                            break;
                        case "Txt":
                            break;
                        case "Video":
                            break;
                        default:
                            break;
                    }
                    */
                    fileInfos.Add(item);
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
        /// 단순 해싱 비교 200개 기준 약 5초 소요
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
                        checkTable[i, j] = checkTable[j, i] = CompareFilesHash(fileInfos[i], fileInfos[j]);
                    }
                }
            }
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
