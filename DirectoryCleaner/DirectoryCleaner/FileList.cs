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
    /// LSF에 대해서는 엄청난 속도 저하 발견.
    /// 다른 방안을 모색해야 함.
    /// </summary>
    public sealed class FileList
    {
        private string filePath;
        private string directoryPath;
        private FileInfo item;
        private byte[] hashcode;
        private int extensionCode;

        public FileList()
        {
            filePath = null;
            directoryPath = null;
            item = null;
            hashcode = null;
            extensionCode = -1;
        }
        public FileList(string filePath)
        {
            this.filePath = filePath;
            directoryPath = null;
            item = new FileInfo(filePath);
            hashcode = MD5.Create().ComputeHash(item.OpenRead());

            string fileType = Extension.CheckExtensionType(item.Extension.Substring(1, item.Extension.Length - 1));
            switch (fileType)
            {
                case "":
                    extensionCode = -1;
                    break;
                case "Audio":
                    extensionCode = (int)Extension.ExtensionCode.Audio;
                    break;
                case "Compact":
                    extensionCode = (int)Extension.ExtensionCode.Compact;
                    break;
                case "Develope":
                    extensionCode = (int)Extension.ExtensionCode.Develope;
                    break;
                case "DiscImage":
                    extensionCode = (int)Extension.ExtensionCode.DiscImage;
                    break;
                case "Document":
                    extensionCode = (int)Extension.ExtensionCode.Document;
                    break;
                case "Etc":
                    extensionCode = (int)Extension.ExtensionCode.Etc;
                    break;
                case "Image":
                    extensionCode = (int)Extension.ExtensionCode.Image;
                    break;
                case "Text":
                    extensionCode = (int)Extension.ExtensionCode.Text;
                    break;
                case "Video":
                    extensionCode = (int)Extension.ExtensionCode.Video;
                    break;
                default:
                    extensionCode = -1;
                    break;
            }
        }

        public void DeleteFile()
        {
            this.item.Delete();
            this.extensionCode = -1;
            hashcode = null;
        }
        public string GetFileName()
        {
            if (item != null)
            {
                return item.Name;
            }
            else
            {
                return null;
            }
        }
        public string GetFilePath()
        {
            if (item != null)
            {
                return item.FullName;
            }
            else
            {
                return null;
            }
        }
        public int GetExtensionCode()
        {
            return this.extensionCode;
        }
        /// <summary>
        /// HashCode Comparison
        /// using MD5 Hash Algorithm
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

            if (this.item.Length != compare.item.Length)
            {
                return false;
            }

            long fileLength = item.Length;
            const int size = 0x1000000;

            Parallel.For(0, fileLength / size, x =>
                {
                    var start = (int)x * size;

                    if (start >= fileLength)
                    {
                        return;
                    }

                    using (FileStream sourceFile = File.OpenRead(this.filePath))
                    {
                        using (FileStream compareFile = File.OpenRead(compare.filePath))
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
