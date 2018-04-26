using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WordMaster
{
    /// <summary>
    /// NoteWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class NoteWindow : Window
    {
        struct Words
        {
            public string eng;
            public string kor;
            public int ac;
            public int wr;
            public double rate;

            public Words(string[] e, string k)
            {
                eng = e[0];
                kor = k;
                ac = Int32.Parse(e[1]);
                wr = Int32.Parse(e[2]);
                rate = (double)ac / (double)wr;
            }

            public int CompareTo(Words a, Words b)
            {
                if (a.rate < b.rate)
                    return 1;
                else if (a.rate == b.rate)
                {
                    if (a.wr > b.wr)
                        return 1;
                    else
                        return -1;
                }
                else
                    return -1;
            }
        }

        List<Words> wordList;

        private string[] enText = null;
        private string[] koText = null;

        private int lineCount;

        private char sep = ',';

        public NoteWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Topmost = true;

            try
            {
                enText = File.ReadAllLines(WordBook.saveEnPath, Encoding.GetEncoding("utf-8"));
                koText = File.ReadAllLines(WordBook.saveKrPath, Encoding.GetEncoding("utf-8"));
                lineCount = Properties.Settings.Default.curSize;

                for (int i = 0; i < lineCount; i++)
                {
                    string kor = koText[i];
                    string[] eng = enText[i].Split(sep);

                    wordList.Add(new Words(eng, kor));
                }

                wordList.Sort((w1, w2) => w1.rate.CompareTo(w2.rate));

                for (int i = 0; i < lineCount; i++)
                {
                    ListViewWord.Items.Add(wordList[i].eng);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
