namespace TPWord
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ButtonAddWord = new System.Windows.Forms.Button();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.ButtonSetting = new System.Windows.Forms.Button();
            this.ButtonExit = new System.Windows.Forms.Button();
            this.lblCopyRight = new System.Windows.Forms.Label();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // ButtonAddWord
            // 
            this.ButtonAddWord.Location = new System.Drawing.Point(87, 24);
            this.ButtonAddWord.Name = "ButtonAddWord";
            this.ButtonAddWord.Size = new System.Drawing.Size(145, 43);
            this.ButtonAddWord.TabIndex = 0;
            this.ButtonAddWord.Text = "단어 추가";
            this.ButtonAddWord.UseVisualStyleBackColor = true;
            this.ButtonAddWord.Click += new System.EventHandler(this.ButtonAddWord_Click);
            // 
            // ButtonStart
            // 
            this.ButtonStart.Location = new System.Drawing.Point(87, 84);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(145, 43);
            this.ButtonStart.TabIndex = 0;
            this.ButtonStart.Text = "시작하기";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // ButtonSetting
            // 
            this.ButtonSetting.Location = new System.Drawing.Point(87, 144);
            this.ButtonSetting.Name = "ButtonSetting";
            this.ButtonSetting.Size = new System.Drawing.Size(145, 43);
            this.ButtonSetting.TabIndex = 0;
            this.ButtonSetting.Text = "설정";
            this.ButtonSetting.UseVisualStyleBackColor = true;
            this.ButtonSetting.Click += new System.EventHandler(this.ButtonSetting_Click);
            // 
            // ButtonExit
            // 
            this.ButtonExit.Location = new System.Drawing.Point(87, 203);
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.Size = new System.Drawing.Size(145, 43);
            this.ButtonExit.TabIndex = 0;
            this.ButtonExit.Text = "종료";
            this.ButtonExit.UseVisualStyleBackColor = true;
            this.ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // lblCopyRight
            // 
            this.lblCopyRight.AutoSize = true;
            this.lblCopyRight.Location = new System.Drawing.Point(12, 271);
            this.lblCopyRight.Name = "lblCopyRight";
            this.lblCopyRight.Size = new System.Drawing.Size(292, 12);
            this.lblCopyRight.TabIndex = 1;
            this.lblCopyRight.Text = "Copyright(c)2018 Twinparadox All rights reserved. ";
            // 
            // trayIcon
            // 
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "TPWord";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 292);
            this.Controls.Add(this.lblCopyRight);
            this.Controls.Add(this.ButtonExit);
            this.Controls.Add(this.ButtonSetting);
            this.Controls.Add(this.ButtonStart);
            this.Controls.Add(this.ButtonAddWord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TPWord";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonAddWord;
        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.Button ButtonSetting;
        private System.Windows.Forms.Button ButtonExit;
        private System.Windows.Forms.Label lblCopyRight;
        private System.Windows.Forms.NotifyIcon trayIcon;
    }
}

