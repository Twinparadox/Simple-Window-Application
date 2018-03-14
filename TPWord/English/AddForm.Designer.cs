namespace TPWord
{
    partial class AddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddForm));
            this.lblWord = new System.Windows.Forms.Label();
            this.TextBoxEnglishWord = new System.Windows.Forms.TextBox();
            this.TextBoxKoreanWord = new System.Windows.Forms.TextBox();
            this.lblMeaning = new System.Windows.Forms.Label();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWord
            // 
            this.lblWord.AutoSize = true;
            this.lblWord.Font = new System.Drawing.Font("굴림", 15F);
            this.lblWord.Location = new System.Drawing.Point(29, 20);
            this.lblWord.Name = "lblWord";
            this.lblWord.Size = new System.Drawing.Size(49, 20);
            this.lblWord.TabIndex = 0;
            this.lblWord.Text = "단어";
            // 
            // TextBoxEnglishWord
            // 
            this.TextBoxEnglishWord.Location = new System.Drawing.Point(84, 19);
            this.TextBoxEnglishWord.Name = "TextBoxEnglishWord";
            this.TextBoxEnglishWord.Size = new System.Drawing.Size(149, 21);
            this.TextBoxEnglishWord.TabIndex = 1;
            // 
            // TextBoxKoreanWord
            // 
            this.TextBoxKoreanWord.Location = new System.Drawing.Point(299, 19);
            this.TextBoxKoreanWord.Name = "TextBoxKoreanWord";
            this.TextBoxKoreanWord.Size = new System.Drawing.Size(149, 21);
            this.TextBoxKoreanWord.TabIndex = 1;
            // 
            // lblMeaning
            // 
            this.lblMeaning.AutoSize = true;
            this.lblMeaning.Font = new System.Drawing.Font("굴림", 15F);
            this.lblMeaning.Location = new System.Drawing.Point(264, 20);
            this.lblMeaning.Name = "lblMeaning";
            this.lblMeaning.Size = new System.Drawing.Size(29, 20);
            this.lblMeaning.TabIndex = 0;
            this.lblMeaning.Text = "뜻";
            // 
            // ButtonClose
            // 
            this.ButtonClose.Location = new System.Drawing.Point(332, 58);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(116, 28);
            this.ButtonClose.TabIndex = 2;
            this.ButtonClose.Text = "창 닫기";
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(210, 58);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(116, 28);
            this.ButtonAdd.TabIndex = 2;
            this.ButtonAdd.Text = "추가하기";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(484, 107);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.TextBoxKoreanWord);
            this.Controls.Add(this.TextBoxEnglishWord);
            this.Controls.Add(this.lblMeaning);
            this.Controls.Add(this.lblWord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TPWord-Add";
            this.Load += new System.EventHandler(this.StartForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWord;
        private System.Windows.Forms.TextBox TextBoxEnglishWord;
        private System.Windows.Forms.TextBox TextBoxKoreanWord;
        private System.Windows.Forms.Label lblMeaning;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.Button ButtonAdd;
    }
}