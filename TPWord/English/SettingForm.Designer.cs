namespace TPWord
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.ButtonClose = new System.Windows.Forms.Button();
            this.ButtonInitAll = new System.Windows.Forms.Button();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.TextBoxFrequency = new System.Windows.Forms.TextBox();
            this.rButtonSoundOff = new System.Windows.Forms.RadioButton();
            this.rButtonSoundOn = new System.Windows.Forms.RadioButton();
            this.lblAlarm = new System.Windows.Forms.Label();
            this.lblInit = new System.Windows.Forms.Label();
            this.ButtonInitSet = new System.Windows.Forms.Button();
            this.ButtonInitWord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonClose
            // 
            this.ButtonClose.Font = new System.Drawing.Font("굴림", 11F);
            this.ButtonClose.Location = new System.Drawing.Point(267, 217);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(75, 23);
            this.ButtonClose.TabIndex = 0;
            this.ButtonClose.Text = "창 닫기";
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // ButtonInitAll
            // 
            this.ButtonInitAll.Font = new System.Drawing.Font("굴림", 11F);
            this.ButtonInitAll.Location = new System.Drawing.Point(16, 217);
            this.ButtonInitAll.Name = "ButtonInitAll";
            this.ButtonInitAll.Size = new System.Drawing.Size(92, 23);
            this.ButtonInitAll.TabIndex = 1;
            this.ButtonInitAll.Text = "전체초기화";
            this.ButtonInitAll.UseVisualStyleBackColor = true;
            this.ButtonInitAll.Click += new System.EventHandler(this.ButtonInitAll_Click);
            // 
            // lblFrequency
            // 
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.Font = new System.Drawing.Font("굴림", 13F);
            this.lblFrequency.Location = new System.Drawing.Point(13, 25);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(74, 18);
            this.lblFrequency.TabIndex = 2;
            this.lblFrequency.Text = "시간(분)";
            // 
            // TextBoxFrequency
            // 
            this.TextBoxFrequency.Location = new System.Drawing.Point(242, 22);
            this.TextBoxFrequency.Name = "TextBoxFrequency";
            this.TextBoxFrequency.Size = new System.Drawing.Size(100, 21);
            this.TextBoxFrequency.TabIndex = 3;
            this.TextBoxFrequency.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxFrequency_KeyPress);
            // 
            // rButtonSoundOff
            // 
            this.rButtonSoundOff.AutoSize = true;
            this.rButtonSoundOff.Font = new System.Drawing.Font("굴림", 13F);
            this.rButtonSoundOff.Location = new System.Drawing.Point(280, 66);
            this.rButtonSoundOff.Name = "rButtonSoundOff";
            this.rButtonSoundOff.Size = new System.Drawing.Size(62, 22);
            this.rButtonSoundOff.TabIndex = 4;
            this.rButtonSoundOff.TabStop = true;
            this.rButtonSoundOff.Text = "끄기";
            this.rButtonSoundOff.UseVisualStyleBackColor = true;
            // 
            // rButtonSoundOn
            // 
            this.rButtonSoundOn.AutoSize = true;
            this.rButtonSoundOn.Font = new System.Drawing.Font("굴림", 13F);
            this.rButtonSoundOn.Location = new System.Drawing.Point(155, 67);
            this.rButtonSoundOn.Name = "rButtonSoundOn";
            this.rButtonSoundOn.Size = new System.Drawing.Size(62, 22);
            this.rButtonSoundOn.TabIndex = 5;
            this.rButtonSoundOn.TabStop = true;
            this.rButtonSoundOn.Text = "켜기";
            this.rButtonSoundOn.UseVisualStyleBackColor = true;
            // 
            // lblAlarm
            // 
            this.lblAlarm.AutoSize = true;
            this.lblAlarm.Font = new System.Drawing.Font("굴림", 13F);
            this.lblAlarm.Location = new System.Drawing.Point(43, 70);
            this.lblAlarm.Name = "lblAlarm";
            this.lblAlarm.Size = new System.Drawing.Size(44, 18);
            this.lblAlarm.TabIndex = 6;
            this.lblAlarm.Text = "알람";
            // 
            // lblInit
            // 
            this.lblInit.AutoSize = true;
            this.lblInit.Font = new System.Drawing.Font("굴림", 13F);
            this.lblInit.Location = new System.Drawing.Point(25, 160);
            this.lblInit.Name = "lblInit";
            this.lblInit.Size = new System.Drawing.Size(62, 18);
            this.lblInit.TabIndex = 6;
            this.lblInit.Text = "초기화";
            // 
            // ButtonInitSet
            // 
            this.ButtonInitSet.Font = new System.Drawing.Font("굴림", 11F);
            this.ButtonInitSet.Location = new System.Drawing.Point(142, 158);
            this.ButtonInitSet.Name = "ButtonInitSet";
            this.ButtonInitSet.Size = new System.Drawing.Size(75, 23);
            this.ButtonInitSet.TabIndex = 7;
            this.ButtonInitSet.Text = "설정";
            this.ButtonInitSet.UseVisualStyleBackColor = true;
            this.ButtonInitSet.Click += new System.EventHandler(this.ButtonInitSet_Click);
            // 
            // ButtonInitWord
            // 
            this.ButtonInitWord.Font = new System.Drawing.Font("굴림", 11F);
            this.ButtonInitWord.Location = new System.Drawing.Point(267, 158);
            this.ButtonInitWord.Name = "ButtonInitWord";
            this.ButtonInitWord.Size = new System.Drawing.Size(75, 23);
            this.ButtonInitWord.TabIndex = 7;
            this.ButtonInitWord.Text = "단어장";
            this.ButtonInitWord.UseVisualStyleBackColor = true;
            this.ButtonInitWord.Click += new System.EventHandler(this.ButtonInitWord_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 252);
            this.Controls.Add(this.ButtonInitWord);
            this.Controls.Add(this.ButtonInitSet);
            this.Controls.Add(this.lblInit);
            this.Controls.Add(this.lblAlarm);
            this.Controls.Add(this.rButtonSoundOn);
            this.Controls.Add(this.rButtonSoundOff);
            this.Controls.Add(this.TextBoxFrequency);
            this.Controls.Add(this.lblFrequency);
            this.Controls.Add(this.ButtonInitAll);
            this.Controls.Add(this.ButtonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TPWord-Setting";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.Button ButtonInitAll;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.TextBox TextBoxFrequency;
        private System.Windows.Forms.RadioButton rButtonSoundOff;
        private System.Windows.Forms.RadioButton rButtonSoundOn;
        private System.Windows.Forms.Label lblAlarm;
        private System.Windows.Forms.Label lblInit;
        private System.Windows.Forms.Button ButtonInitSet;
        private System.Windows.Forms.Button ButtonInitWord;
    }
}