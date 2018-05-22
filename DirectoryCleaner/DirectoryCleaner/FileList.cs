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
    /// </summary>
    class FileList
    {
        private FileInfo item;
        public byte[] hashcode;
        public int extensionCode;

        public FileList()
        {
            item = null;
            hashcode = null;
            extensionCode = -1;
        }
        public FileList(string filePath)
        {
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
        public bool CompareHashCode(FileList compare)
        {
            for (int i = 0; i < this.hashcode.Length; i++)
            {
                if (this.hashcode[i]!=compare.hashcode[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
