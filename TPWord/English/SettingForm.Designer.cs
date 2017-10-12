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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnInitAll = new System.Windows.Forms.Button();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.txtbxFrequency = new System.Windows.Forms.TextBox();
            this.rbtnSoundOff = new System.Windows.Forms.RadioButton();
            this.rbtnSoundOn = new System.Windows.Forms.RadioButton();
            this.lblAlarm = new System.Windows.Forms.Label();
            this.lblInit = new System.Windows.Forms.Label();
            this.btnInitSet = new System.Windows.Forms.Button();
            this.btnInitWord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("굴림", 11F);
            this.btnClose.Location = new System.Drawing.Point(267, 217);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "창 닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnInitAll
            // 
            this.btnInitAll.Font = new System.Drawing.Font("굴림", 11F);
            this.btnInitAll.Location = new System.Drawing.Point(16, 217);
            this.btnInitAll.Name = "btnInitAll";
            this.btnInitAll.Size = new System.Drawing.Size(92, 23);
            this.btnInitAll.TabIndex = 1;
            this.btnInitAll.Text = "전체초기화";
            this.btnInitAll.UseVisualStyleBackColor = true;
            this.btnInitAll.Click += new System.EventHandler(this.btnInitAll_Click);
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
            // txtbxFrequency
            // 
            this.txtbxFrequency.Location = new System.Drawing.Point(242, 22);
            this.txtbxFrequency.Name = "txtbxFrequency";
            this.txtbxFrequency.Size = new System.Drawing.Size(100, 21);
            this.txtbxFrequency.TabIndex = 3;
            this.txtbxFrequency.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxFrequency_KeyPress);
            // 
            // rbtnSoundOff
            // 
            this.rbtnSoundOff.AutoSize = true;
            this.rbtnSoundOff.Font = new System.Drawing.Font("굴림", 13F);
            this.rbtnSoundOff.Location = new System.Drawing.Point(280, 66);
            this.rbtnSoundOff.Name = "rbtnSoundOff";
            this.rbtnSoundOff.Size = new System.Drawing.Size(62, 22);
            this.rbtnSoundOff.TabIndex = 4;
            this.rbtnSoundOff.TabStop = true;
            this.rbtnSoundOff.Text = "끄기";
            this.rbtnSoundOff.UseVisualStyleBackColor = true;
            // 
            // rbtnSoundOn
            // 
            this.rbtnSoundOn.AutoSize = true;
            this.rbtnSoundOn.Font = new System.Drawing.Font("굴림", 13F);
            this.rbtnSoundOn.Location = new System.Drawing.Point(155, 67);
            this.rbtnSoundOn.Name = "rbtnSoundOn";
            this.rbtnSoundOn.Size = new System.Drawing.Size(62, 22);
            this.rbtnSoundOn.TabIndex = 5;
            this.rbtnSoundOn.TabStop = true;
            this.rbtnSoundOn.Text = "켜기";
            this.rbtnSoundOn.UseVisualStyleBackColor = true;
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
            // btnInitSet
            // 
            this.btnInitSet.Font = new System.Drawing.Font("굴림", 11F);
            this.btnInitSet.Location = new System.Drawing.Point(142, 158);
            this.btnInitSet.Name = "btnInitSet";
            this.btnInitSet.Size = new System.Drawing.Size(75, 23);
            this.btnInitSet.TabIndex = 7;
            this.btnInitSet.Text = "설정";
            this.btnInitSet.UseVisualStyleBackColor = true;
            this.btnInitSet.Click += new System.EventHandler(this.btnInitSet_Click);
            // 
            // btnInitWord
            // 
            this.btnInitWord.Font = new System.Drawing.Font("굴림", 11F);
            this.btnInitWord.Location = new System.Drawing.Point(267, 158);
            this.btnInitWord.Name = "btnInitWord";
            this.btnInitWord.Size = new System.Drawing.Size(75, 23);
            this.btnInitWord.TabIndex = 7;
            this.btnInitWord.Text = "단어장";
            this.btnInitWord.UseVisualStyleBackColor = true;
            this.btnInitWord.Click += new System.EventHandler(this.btnInitWord_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 252);
            this.Controls.Add(this.btnInitWord);
            this.Controls.Add(this.btnInitSet);
            this.Controls.Add(this.lblInit);
            this.Controls.Add(this.lblAlarm);
            this.Controls.Add(this.rbtnSoundOn);
            this.Controls.Add(this.rbtnSoundOff);
            this.Controls.Add(this.txtbxFrequency);
            this.Controls.Add(this.lblFrequency);
            this.Controls.Add(this.btnInitAll);
            this.Controls.Add(this.btnClose);
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

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnInitAll;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.TextBox txtbxFrequency;
        private System.Windows.Forms.RadioButton rbtnSoundOff;
        private System.Windows.Forms.RadioButton rbtnSoundOn;
        private System.Windows.Forms.Label lblAlarm;
        private System.Windows.Forms.Label lblInit;
        private System.Windows.Forms.Button btnInitSet;
        private System.Windows.Forms.Button btnInitWord;
    }
}