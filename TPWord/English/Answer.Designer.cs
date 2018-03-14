namespace TPWord
{
    partial class Answer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Answer));
            this.ButtonAdmit = new System.Windows.Forms.Button();
            this.TextBoxEnglish = new System.Windows.Forms.TextBox();
            this.TextBoxKorean = new System.Windows.Forms.TextBox();
            this.ButtonStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonAdmit
            // 
            this.ButtonAdmit.Font = new System.Drawing.Font("굴림", 9F);
            this.ButtonAdmit.Location = new System.Drawing.Point(459, 86);
            this.ButtonAdmit.Name = "ButtonAdmit";
            this.ButtonAdmit.Size = new System.Drawing.Size(75, 23);
            this.ButtonAdmit.TabIndex = 0;
            this.ButtonAdmit.Text = "정답제출";
            this.ButtonAdmit.UseVisualStyleBackColor = true;
            this.ButtonAdmit.Click += new System.EventHandler(this.ButtonAdmit_Click);
            // 
            // TextBoxEnglish
            // 
            this.TextBoxEnglish.Font = new System.Drawing.Font("굴림", 13F);
            this.TextBoxEnglish.Location = new System.Drawing.Point(33, 40);
            this.TextBoxEnglish.Name = "TextBoxEnglish";
            this.TextBoxEnglish.ReadOnly = true;
            this.TextBoxEnglish.Size = new System.Drawing.Size(232, 27);
            this.TextBoxEnglish.TabIndex = 1;
            // 
            // TextBoxKorean
            // 
            this.TextBoxKorean.Font = new System.Drawing.Font("굴림", 13F);
            this.TextBoxKorean.Location = new System.Drawing.Point(302, 40);
            this.TextBoxKorean.Name = "TextBoxKorean";
            this.TextBoxKorean.Size = new System.Drawing.Size(232, 27);
            this.TextBoxKorean.TabIndex = 2;
            // 
            // ButtonStop
            // 
            this.ButtonStop.Location = new System.Drawing.Point(33, 86);
            this.ButtonStop.Name = "ButtonStop";
            this.ButtonStop.Size = new System.Drawing.Size(75, 23);
            this.ButtonStop.TabIndex = 3;
            this.ButtonStop.Text = "중단하기";
            this.ButtonStop.UseVisualStyleBackColor = true;
            this.ButtonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // Answer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 132);
            this.Controls.Add(this.ButtonStop);
            this.Controls.Add(this.TextBoxKorean);
            this.Controls.Add(this.TextBoxEnglish);
            this.Controls.Add(this.ButtonAdmit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Answer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TPWord-Answer";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Answer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonAdmit;
        private System.Windows.Forms.TextBox TextBoxEnglish;
        private System.Windows.Forms.TextBox TextBoxKorean;
        private System.Windows.Forms.Button ButtonStop;
    }
}