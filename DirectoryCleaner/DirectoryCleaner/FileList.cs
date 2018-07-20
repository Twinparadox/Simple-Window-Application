using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryCleaner
{
    /// <summary>
    /// 파일정보, 해시코드, 확장자코드를 이용한 중복 확인. 
    /// 해시코드:LSF에 대해서는 엄청난 속도 저하 발견.
    /// TODO: 해시 계산은 일단 주석처리했음, 다른 방안을 모색해야 함.
    /// </summary>
    public sealed class FileList
    {
        private string filePath;
        private string directoryPath;
        private FileInfo item;
        private byte[] hashcode;

        public string FilePath
        {
            get
            {
                return filePath;
            }
            set
            {
                if ((value == null) || (value.Length == 0))
                    throw new ArgumentException("FilePath cannot be blank", "FilePath");
                filePath = value;
            }
        }
        public string DirectoryPath
        {
            get
            {
                return directoryPath;
            }
            set
            {
                if ((value == null) || (value.Length == 0))
                    throw new ArgumentException("DirectoryPath Cannot be blank", "DirectoryPath");
                directoryPath = value;
            }
        }
        public int ExtensionCode { get; set; }
        public FileInfo Item
        {
            get
            {
                return item;
            }
            set
            {
                if (value == null)
                    throw new ArgumentException("FileInfo cannot be blank", "FilePath");
                item = value;
            }
        }

        public FileList()
        {
            FilePath = null;
            DirectoryPath = null;
            Item = null;
            //hashcode = null;
            ExtensionCode = -1;
        }

        public FileList(string filePath)
        {
            FilePath = filePath;
            Item = new FileInfo(filePath);
            DirectoryPath = item.DirectoryName;
            //hashcode = MD5.Create().ComputeHash(item.OpenRead());

            string fileType = Extension.CheckExtensionType(item.Extension.Substring(1, item.Extension.Length - 1));
            ExtensionCode = Extension.GetExtensionCode(fileType);
        }

        public void DeleteFile()
        {
            FilePath = null;
            DirectoryPath = null;
            Item.Delete();
            ExtensionCode = -1;
            hashcode = null;
        }

        public string GetFileName()
        {
            if (Item != null)
            {
                return Item.Name;
            }
            else
            {
                return null;
            }
        }

        public string GetFilePath()
        {
            if (Item != null)
            {
                return Item.FullName;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// HashCode Comparison
        /// using MD5 Hash Algorithm
        /// TODO : 다른 방안 모색하거나 삭제 고려
        /// </summary>
        /// <param name="compare"></param>
        /// <returns></returns>
        public bool CompareHashCode(FileList compare)
        {
            for (int i = 0; i < this.hashcode.Length; i++)
            {
                if (this.hashcode[i] != compare.hashcode[i])
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Byte To Byte Comparison
        /// using Parallel.For
        /// </summary>
        /// <param name="compare"></param>
        /// <returns></returns>
        public bool CompareByteToByte(FileList compare)
        {
            bool success = true;

            if (this.Item.Length != compare.Item.Length)
            {
                return false;
            }
            if(ExtensionCode==compare.ExtensionCode)
            {
                return false;
            }

            long fileLength = Item.Length;
            const int size = 0x1000000;

            Parallel.For(0, fileLength / size, x =>
                {
                    var start = (int)x * size;

                    if (start >= fileLength)
                    {
                        return;
                    }

                    using (FileStream sourceFile = File.OpenRead(this.FilePath))
                    {
                        using (FileStream compareFile = File.OpenRead(compare.FilePath))
                        {
                            var bufferSource = new byte[size];
                            var bufferCompare = new byte[size];

                            sourceFile.Position = start;
                            compareFile.Position = start;

                            int cnt = sourceFile.Read(bufferSource, 0, size);
                            compareFile.Read(bufferCompare, 0, size);

                            for (int i = 0; i < cnt; i++)
                            {
                                if (bufferSource[i] != bufferCompare[i])
                                {
                                    success = false;
                                    return;
                                }
                            }
                        }
                    }
                });
            return success;
        }
    }
}
