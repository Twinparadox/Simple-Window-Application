using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TwinNotePad
{
    public partial class Form1 : Form
    {
        private Boolean txtNoteChange; // check content change
        private string fWord; // find word
        private Form2 frm2; // form2(find word) create
        public Form1()
        {
            InitializeComponent();
        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {
            this.txtNoteChange = true; // data add
        }

        private void 새로만들기NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.txtNoteChange == true)
            {
                var msg = this.Text + " 파일의 내용이 변경되었습니다. \r\n 변경된 내용을 저장하시겠습니까?";
                var dlr = MessageBox.Show(msg, "메모장", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dlr == DialogResult.Yes)
                {
                    textSave();
                    this.txtNote.ResetText();
                    this.Text = "제목 없음";
                }
                else if (dlr == DialogResult.No)
                {
                    this.txtNote.ResetText();
                    this.Text = "제목 없음";
                    this.txtNoteChange = false;
                }
                else if (dlr == DialogResult.Cancel)
                    return;
                else
                {
                    this.txtNote.ResetText();
                    this.Text = "제목 없음";
                    this.txtNoteChange = false;
                }
            }
        }

        private void textSave()
        {
            if (this.Text == "제목 없음")
            {
                var dlr = this.sfdFile.ShowDialog();
                if (dlr != DialogResult.Cancel)
                {
                    var str = this.sfdFile.FileName;
                    var sw = new StreamWriter(str, false, System.Text.Encoding.Default);
                    sw.Write(this.txtNote.Text);
                    sw.Flush();
                    sw.Close();
                    var f = new FileInfo(str);
                    this.Text = f.Name;
                    this.txtNoteChange = false;
                }
                else
                {
                    var strt = this.Text;
                    var sw = new StreamWriter(strt, false, System.Text.Encoding.Default);
                    sw.Write(this.txtNote.Text);
                    sw.Flush();
                    sw.Close();
                    this.Text = strt;
                    this.txtNoteChange = false;
                }
            }
        }

        private void textOpeN()
        {
            var dr = this.ofdFile.ShowDialog();
            if (dr != DialogResult.Cancel)
            {
                var str = this.ofdFile.FileName;
                var sr = new StreamReader(str, System.Text.Encoding.Default);
                this.txtNote.Text = sr.ReadToEnd();
                sr.Close();
                var f = new FileInfo(str);
                this.Text = f.Name;
                this.txtNoteChange = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (this.txtNoteChange == true)
            {
                var msg = this.Text + " 파일의 내용이 변경되었습니다. \r\n 변경된 내용을 저장하시겠습니까?";
                var dlr = MessageBox.Show(msg, "메모장", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dlr == DialogResult.Yes)
                {
                    if (this.Text == "제목 없음")
                    {
                        var dr = this.sfdFile.ShowDialog();
                        if (dr != DialogResult.Cancel)
                        {
                            var str = this.sfdFile.FileName;
                            var sw = new StreamWriter(str, false, System.Text.Encoding.Default);
                            sw.Write(this.txtNote.Text);
                            sw.Flush();
                            sw.Close();
                            this.txtNoteChange = false;
                        }
                    }
                    else
                    {
                        var str = this.Text;
                        var sw = new StreamWriter(str, false, System.Text.Encoding.Default);
                        sw.Write(this.txtNote.Text);
                        sw.Flush();
                        sw.Close();
                        this.txtNoteChange = false;
                    }
                    this.Dispose();
                }
                else if (dlr == DialogResult.No)
                {
                    this.Dispose();
                }
                else if (dlr == DialogResult.Cancel)
                {
                    return;
                }
            }
            else
            {
                this.Dispose();
            }
        }

        private void 찾기FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(frm2 == null || !frm2.Visible))
            {
                frm2.Focus();
                return;
            }
            frm2 = new Form2();
            if (this.txtNote.SelectionLength == 0)
                frm2.txtWord.Text = this.fWord;
            else
                frm2.txtWord.Text = this.txtNote.SelectedText;
            frm2.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            frm2.Show();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var updown = -1;
            var str = this.txtNote.Text; // save content
            var findWord = frm2.txtWord.Text; // save find word
            if (!frm2.chb.Checked)
            {
                str = str.ToUpper(); // transform content to capital
                findWord = findWord.ToUpper();
            }
            if (frm2.rdb01.Checked)
            {
                if (this.txtNote.SelectionStart != 0)
                {
                    updown = str.LastIndexOf(findWord, this.txtNote.SelectionStart - 1);
                }
            }
            else
            {
                updown = str.IndexOf(findWord, this.txtNote.SelectionStart + this.txtNote.SelectionLength);
            }
            if (updown == -1)
            {
                MessageBox.Show("더 이상 찾는 문자열이 없습니다", "메모장", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.txtNote.Select(updown, findWord.Length);
            fWord = frm2.txtWord.Text;
            this.txtNote.Focus();
            this.txtNote.ScrollToCaret();
        }

        private void 다음찾기NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(frm2 == null || !frm2.Visible))
            {
                frm2.txtWord.Text = this.fWord;
                this.btnOk_Click(this, null);
            }
        }

        private void 끝내기XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); // exit program
        }

        private void 저장SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textSave();
        }

        private void 실행취소ZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtNote.Undo();
        }

        private void 복사CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtNote.Copy();
        }

        private void 붙여넣기PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtNote.Paste();
        }

        private void 삭제RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtNote.SelectedText = "";
        }

        private void 모두선택AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtNote.SelectAll();
        }

        private void 잘라내기XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtNote.Cut();
        }

        private void 글꼴FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.fdText.ShowDialog() != DialogResult.Cancel)
                this.txtNote.Font = this.fdText.Font;
        }

        private void 시간날짜DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var time = DateTime.Now.ToShortTimeString(); //현재 시간 얻기
            var date = DateTime.Today.ToShortDateString(); //오늘 날짜 얻기
            this.txtNote.AppendText(time + "/" + date); //입력 데이터 맨뒤에 이어서 시간/날짜 정보 추가
        }

        private void 정보AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3(); //Form3 객체 초기화 선언
            frm3.ShowDialog(); //폼3 호출
        }

        private void 가운데정렬ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.SelectAll();
            txtNote.TextAlign = HorizontalAlignment.Center;
        }
    }
}
