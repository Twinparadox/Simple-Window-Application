using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHConverter
{
    public partial class SHConverter : Form
    {
        private string source;
        private string[] data = {"ActionScript3","Bash-shell","ColdFusion","C#","C++","CSS",
                                "JavaScript","Java","Perl","PHP","Powershell","Python",
                                "Ruby","Scala","SQL","Visual Basic","XML(+HTML)" };
        private string[] className = {"actionscript3","bash","cf","csharp","cpp","css",
                                "javascript","java","perl","php","powershell","python",
                                "ruby","scala","sql","vb","xml"};
        private string tagFront;
        private string tagFront1 = "<pre name=\"code\" class=\"brush:";
        private string tagFront2;
        private string tagFront3 = "\";>";
        private string tagEnd = "</pre>";

        public SHConverter()
        {
            InitializeComponent();
            this.boxList.Items.AddRange(data);
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (this.boxList.Text.Equals(""))
            {
                MessageBox.Show("언어를 선택해주세요.");
                return;
            }
            else
            {
                source = this.txtSource.Text;
                source = source.Replace("<", "&lt;");
                source = source.Replace(">", "&gt;");
                source = tagFront + source + tagEnd;
                this.txtResult.Text = source;
            }
        }

        private void boxList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tagFront2 = className[this.boxList.SelectedIndex];
            tagFront = tagFront1 + tagFront2 + tagFront3;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.txtResult.Text);
        }
    }
}
