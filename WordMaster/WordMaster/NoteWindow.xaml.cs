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

        private const int PageSize = 20;
        private int pageCount;
        private int curPage;

        public NoteWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            wordList = new List<Words>();
            this.Topmost = true;

            try
            {
                enText = File.ReadAllLines(WordBook.saveEnPath, Encoding.GetEncoding("utf-8"));
                koText = File.ReadAllLines(WordBook.saveKrPath, Encoding.GetEncoding("utf-8"));
                lineCount = Properties.Settings.Default.curSize;

                PageSlider.Minimum = 1;
                if (lineCount % 20 == 0)
                {
                    PageSlider.Maximum = lineCount / 20;
                }
                else
                {
                    PageSlider.Maximum = lineCount / 20 + 1;
                }
                PageSlider.Value = 1;

                for (int i = 0; i < lineCount; i++)
                {
                    string kor = koText[i];
                    string[] eng = enText[i].Split(sep);

                    wordList.Add(new Words(eng, kor));
                }

                wordList.Sort((w1, w2) => w1.rate.CompareTo(w2.rate));

                for (int i = 0; i < PageSize; i++)
                {
                    ListViewWord.Items.Add(new ListViewItem { Content = wordList[i].eng, HorizontalContentAlignment = HorizontalAlignment.Center });
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void ChangeListView()
        {
            // 현재 임시 구현 상태, 매번 이런 식으로 업데이트하면 성능 저하, 메모리 낭비 발생할 듯.
            ListViewWord.Items.Clear();
            for(int i=(curPage-1)*PageSize;i<curPage*PageSize;i++)
            {
                if(i<lineCount)
                {
                    ListViewWord.Items.Add(new ListViewItem { Content = wordList[i].eng, HorizontalContentAlignment = HorizontalAlignment.Center });
                }
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PageSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            curPage = (int)PageSlider.Value;
            ChangeListView();
        }
    }
}
