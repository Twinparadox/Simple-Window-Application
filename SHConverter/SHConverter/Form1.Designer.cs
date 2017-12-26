namespace SHConverter
{
    partial class SHConverter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SHConverter));
            this.txtSource = new System.Windows.Forms.RichTextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.boxList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtSource
            // 
            this.txtSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSource.Location = new System.Drawing.Point(12, 12);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(550, 300);
            this.txtSource.TabIndex = 0;
            this.txtSource.Text = "";
            // 
            // btnConvert
            // 
            this.btnConvert.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.btnConvert.Location = new System.Drawing.Point(12, 348);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(150, 42);
            this.btnConvert.TabIndex = 1;
            this.btnConvert.Text = "변환";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold);
            this.btnCopy.Location = new System.Drawing.Point(411, 348);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(150, 42);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "복사";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(12, 417);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(550, 300);
            this.txtResult.TabIndex = 3;
            this.txtResult.Text = "";
            // 
            // boxList
            // 
            this.boxList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxList.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.boxList.FormattingEnabled = true;
            this.boxList.Location = new System.Drawing.Point(231, 350);
            this.boxList.Name = "boxList";
            this.boxList.Size = new System.Drawing.Size(121, 40);
            this.boxList.TabIndex = 4;
            this.boxList.SelectionChangeCommitted += new System.EventHandler(this.boxList_SelectionChangeCommitted);
            // 
            // SHConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 729);
            this.Controls.Add(this.boxList);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.txtSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SHConverter";
            this.Text = "SHConverter";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtSource;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.ComboBox boxList;
    }
}

