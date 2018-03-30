using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPWord
{
    public partial class NoteForm : Form
    {   
        /// <summary>
        /// 저장 경로
        /// </summary>
        private static string saveEnPath = @"C:\TPWord\EWORD.txt";
        private static string saveKrPath = @"C:\TPWord\KWORD.txt";
        private static string saveFolderPath = @"C:\TPWord";

        /// <summary>
        /// 단어 파일 및 세팅 읽기
        /// </summary>
        private string[] enText = File.ReadAllLines(saveEnPath, Encoding.GetEncoding("utf-8"));
        private string[] koText = File.ReadAllLines(saveKrPath, Encoding.GetEncoding("utf-8"));
        private string[] Setting = Properties.Settings.Default.curSettings.Split(';');

        /* line */
        private int lineCount;
        private int lineRandom;

        /* page setting */
        private int pages = 8;
        private int startIndex;
        private int endIndex;

        /// <summary>
        /// 단어 정보를 담는 구조체
        /// </summary>
        private struct Word
        {
            public string english;
            public string korean;
            public int question;
            public int correct;

            public Word(string eng, string kor, int que, int cor)
            {
                english = eng;
                korean = kor;
                question = que;
                correct = cor;
            }
        }
        List<Word> wordList = new List<Word>();

        /* etc */
        private char sep = ',';


        public NoteForm()
        {
            InitializeComponent();
        }

        private void NoteForm_Load(object sender, EventArgs e)
        {
            lineCount = File.ReadLines(saveEnPath).Count();
            MakeList();
            SettingWord();
        }

        /// <summary>
        /// 단어 리스트 생성 함수
        /// </summary>
        private void MakeList()
        {
            for(int i=0;i<lineCount;i++)
            {
                string[] tmp = enText[i].Split(sep);
                wordList.Add(new Word(tmp[0], koText[i], Int32.Parse(tmp[1]), Int32.Parse(tmp[2])));
            }
        }

        /// <summary>
        /// 단어 리스트를 리스트뷰에 추가
        /// </summary>
        private void SettingWord()
        {
            ListViewWord.BeginUpdate();
            for(int i=0;i<pages && i<lineCount;i++)
            {
                ListViewItem tmp = new ListViewItem(wordList[i].english);
                ListViewWord.Items.Add(tmp);
            }
            ListViewWord.EndUpdate();
        }

        #region Button Methods
        private void ButtonNextPage_Click(object sender, EventArgs e)
        {

        }

        private void ButtonPrevPage_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void ListViewWord_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            e.Item.Text = koText[e.Item.Index];
        }
    }
}
