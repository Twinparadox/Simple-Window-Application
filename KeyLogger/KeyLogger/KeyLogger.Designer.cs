namespace KeyLogger
{
    partial class KeyLogger
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
            this.btnSetPath = new System.Windows.Forms.Button();
            this.lvLog = new System.Windows.Forms.ListView();
            this.btnSetUsers = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSetPath
            // 
            this.btnSetPath.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSetPath.Location = new System.Drawing.Point(130, 12);
            this.btnSetPath.Name = "btnSetPath";
            this.btnSetPath.Size = new System.Drawing.Size(91, 37);
            this.btnSetPath.TabIndex = 0;
            this.btnSetPath.Text = "경로 설정";
            this.btnSetPath.UseVisualStyleBackColor = true;
            // 
            // lvLog
            // 
            this.lvLog.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvLog.Location = new System.Drawing.Point(12, 55);
            this.lvLog.Name = "lvLog";
            this.lvLog.Size = new System.Drawing.Size(323, 309);
            this.lvLog.TabIndex = 1;
            this.lvLog.UseCompatibleStateImageBehavior = false;
            // 
            // btnSetUsers
            // 
            this.btnSetUsers.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSetUsers.Location = new System.Drawing.Point(12, 12);
            this.btnSetUsers.Name = "btnSetUsers";
            this.btnSetUsers.Size = new System.Drawing.Size(91, 37);
            this.btnSetUsers.TabIndex = 2;
            this.btnSetUsers.Text = "사용자 설정";
            this.btnSetUsers.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExit.Location = new System.Drawing.Point(244, 14);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(91, 37);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "종료";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 376);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSetUsers);
            this.Controls.Add(this.lvLog);
            this.Controls.Add(this.btnSetPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "KeyLogger";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSetPath;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.Button btnSetUsers;
        private System.Windows.Forms.Button btnExit;
    }
}

