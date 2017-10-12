using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwinNotePad
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void txtWord_TextChanged(object sender, EventArgs e)
        {
            if (this.txtWord.Text == "")
                this.btnOk.Enabled = false; // Disable button
            else
                this.btnOk.Enabled = true; // Enable button
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Form2 Close
        }
    }
}
