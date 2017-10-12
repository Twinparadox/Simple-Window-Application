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
            this.btnAdmit = new System.Windows.Forms.Button();
            this.txtbxEnglish = new System.Windows.Forms.TextBox();
            this.txtbxKorean = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdmit
            // 
            this.btnAdmit.Font = new System.Drawing.Font("굴림", 9F);
            this.btnAdmit.Location = new System.Drawing.Point(459, 86);
            this.btnAdmit.Name = "btnAdmit";
            this.btnAdmit.Size = new System.Drawing.Size(75, 23);
            this.btnAdmit.TabIndex = 0;
            this.btnAdmit.Text = "정답제출";
            this.btnAdmit.UseVisualStyleBackColor = true;
            this.btnAdmit.Click += new System.EventHandler(this.btnAdmit_Click);
            // 
            // txtbxEnglish
            // 
            this.txtbxEnglish.Font = new System.Drawing.Font("굴림", 13F);
            this.txtbxEnglish.Location = new System.Drawing.Point(33, 40);
            this.txtbxEnglish.Name = "txtbxEnglish";
            this.txtbxEnglish.ReadOnly = true;
            this.txtbxEnglish.Size = new System.Drawing.Size(232, 27);
            this.txtbxEnglish.TabIndex = 1;
            // 
            // txtbxKorean
            // 
            this.txtbxKorean.Font = new System.Drawing.Font("굴림", 13F);
            this.txtbxKorean.Location = new System.Drawing.Point(302, 40);
            this.txtbxKorean.Name = "txtbxKorean";
            this.txtbxKorean.Size = new System.Drawing.Size(232, 27);
            this.txtbxKorean.TabIndex = 2;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(33, 86);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "중단하기";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // Answer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 132);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.txtbxKorean);
            this.Controls.Add(this.txtbxEnglish);
            this.Controls.Add(this.btnAdmit);
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

        private System.Windows.Forms.Button btnAdmit;
        private System.Windows.Forms.TextBox txtbxEnglish;
        private System.Windows.Forms.TextBox txtbxKorean;
        private System.Windows.Forms.Button btnStop;
    }
}