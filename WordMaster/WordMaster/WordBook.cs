using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMaster
{
    public class WordBook
    {
        /* 저장 경로 */
        public static string saveFolderPath = @"C:\WordMaster";
        public static string saveEnPath = @"C:\WordMaster\EWORD.txt";
        public static string saveKrPath = @"C:\WordMaster\KWORD.txt";

        public static void CreateDirectoryAndFiles()
        {
            /* Check Directory and File */
            if (!Directory.Exists(saveFolderPath))
            {
                try
                {
                    Directory.CreateDirectory(saveFolderPath);
                }
                catch (Exception ex)
                {
                }
            }
            if (!File.Exists(saveEnPath))
            {
                try
                {
                    File.CreateText(saveEnPath);
                }
                catch (Exception ex)
                {
                }
            }
            if (!File.Exists(saveKrPath))
            {
                try
                {
                    File.CreateText(saveKrPath);
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}
