namespace TPWord
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.lblWord = new System.Windows.Forms.Label();
            this.txtbxEnglishWord = new System.Windows.Forms.TextBox();
            this.txtbxKoreanWord = new System.Windows.Forms.TextBox();
            this.lblMeaning = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
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
            // txtbxEnglishWord
            // 
            this.txtbxEnglishWord.Location = new System.Drawing.Point(84, 19);
            this.txtbxEnglishWord.Name = "txtbxEnglishWord";
            this.txtbxEnglishWord.Size = new System.Drawing.Size(149, 21);
            this.txtbxEnglishWord.TabIndex = 1;
            // 
            // txtbxKoreanWord
            // 
            this.txtbxKoreanWord.Location = new System.Drawing.Point(299, 19);
            this.txtbxKoreanWord.Name = "txtbxKoreanWord";
            this.txtbxKoreanWord.Size = new System.Drawing.Size(149, 21);
            this.txtbxKoreanWord.TabIndex = 1;
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
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(332, 58);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(116, 28);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "창 닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(210, 58);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(116, 28);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "추가하기";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(484, 107);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtbxKoreanWord);
            this.Controls.Add(this.txtbxEnglishWord);
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
        private System.Windows.Forms.TextBox txtbxEnglishWord;
        private System.Windows.Forms.TextBox txtbxKoreanWord;
        private System.Windows.Forms.Label lblMeaning;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
    }
}