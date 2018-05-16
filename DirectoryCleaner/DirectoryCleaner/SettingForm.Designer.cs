namespace DirectoryCleaner
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
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.lblExtension = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.rButton1Month = new System.Windows.Forms.RadioButton();
            this.rButton3Months = new System.Windows.Forms.RadioButton();
            this.rButton6Months = new System.Windows.Forms.RadioButton();
            this.ButtonAccept = new System.Windows.Forms.Button();
            this.ButtonInitialize = new System.Windows.Forms.Button();
            this.ButtonManagement = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtExtension
            // 
            this.txtExtension.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtExtension.Location = new System.Drawing.Point(15, 41);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.ReadOnly = true;
            this.txtExtension.Size = new System.Drawing.Size(332, 26);
            this.txtExtension.TabIndex = 0;
            // 
            // lblExtension
            // 
            this.lblExtension.AutoSize = true;
            this.lblExtension.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblExtension.Location = new System.Drawing.Point(12, 20);
            this.lblExtension.Name = "lblExtension";
            this.lblExtension.Size = new System.Drawing.Size(59, 16);
            this.lblExtension.TabIndex = 2;
            this.lblExtension.Text = "확장자";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDate.Location = new System.Drawing.Point(12, 101);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(82, 16);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "날짜 설정";
            // 
            // rButton1Month
            // 
            this.rButton1Month.AutoSize = true;
            this.rButton1Month.Location = new System.Drawing.Point(15, 131);
            this.rButton1Month.Name = "rButton1Month";
            this.rButton1Month.Size = new System.Drawing.Size(81, 16);
            this.rButton1Month.TabIndex = 4;
            this.rButton1Month.TabStop = true;
            this.rButton1Month.Text = "1개월 이상";
            this.rButton1Month.UseVisualStyleBackColor = true;
            // 
            // rButton3Months
            // 
            this.rButton3Months.AutoSize = true;
            this.rButton3Months.Location = new System.Drawing.Point(193, 131);
            this.rButton3Months.Name = "rButton3Months";
            this.rButton3Months.Size = new System.Drawing.Size(81, 16);
            this.rButton3Months.TabIndex = 5;
            this.rButton3Months.TabStop = true;
            this.rButton3Months.Text = "3개월 이상";
            this.rButton3Months.UseVisualStyleBackColor = true;
            // 
            // rButton6Months
            // 
            this.rButton6Months.AutoSize = true;
            this.rButton6Months.Location = new System.Drawing.Point(371, 131);
            this.rButton6Months.Name = "rButton6Months";
            this.rButton6Months.Size = new System.Drawing.Size(81, 16);
            this.rButton6Months.TabIndex = 6;
            this.rButton6Months.TabStop = true;
            this.rButton6Months.Text = "6개월 이상";
            this.rButton6Months.UseVisualStyleBackColor = true;
            // 
            // ButtonAccept
            // 
            this.ButtonAccept.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ButtonAccept.Location = new System.Drawing.Point(353, 163);
            this.ButtonAccept.Name = "ButtonAccept";
            this.ButtonAccept.Size = new System.Drawing.Size(99, 26);
            this.ButtonAccept.TabIndex = 9;
            this.ButtonAccept.Text = "확인";
            this.ButtonAccept.UseVisualStyleBackColor = true;
            this.ButtonAccept.Click += new System.EventHandler(this.ButtonAccept_Click);
            // 
            // ButtonInitialize
            // 
            this.ButtonInitialize.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ButtonInitialize.Location = new System.Drawing.Point(12, 163);
            this.ButtonInitialize.Name = "ButtonInitialize";
            this.ButtonInitialize.Size = new System.Drawing.Size(99, 26);
            this.ButtonInitialize.TabIndex = 10;
            this.ButtonInitialize.Text = "초기화";
            this.ButtonInitialize.UseVisualStyleBackColor = true;
            this.ButtonInitialize.Click += new System.EventHandler(this.ButtonInitialize_Click);
            // 
            // ButtonManagement
            // 
            this.ButtonManagement.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ButtonManagement.Location = new System.Drawing.Point(353, 41);
            this.ButtonManagement.Name = "ButtonManagement";
            this.ButtonManagement.Size = new System.Drawing.Size(99, 26);
            this.ButtonManagement.TabIndex = 11;
            this.ButtonManagement.Text = "관리";
            this.ButtonManagement.UseVisualStyleBackColor = true;
            this.ButtonManagement.Click += new System.EventHandler(this.ButtonManagement_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 201);
            this.Controls.Add(this.ButtonManagement);
            this.Controls.Add(this.ButtonInitialize);
            this.Controls.Add(this.ButtonAccept);
            this.Controls.Add(this.rButton6Months);
            this.Controls.Add(this.rButton3Months);
            this.Controls.Add(this.rButton1Month);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblExtension);
            this.Controls.Add(this.txtExtension);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingForm";
            this.ShowInTaskbar = false;
            this.Text = "DirectoryCleaner - 설정";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Setting_FormClosing);
            this.Load += new System.EventHandler(this.Setting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtExtension;
        private System.Windows.Forms.Label lblExtension;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.RadioButton rButton1Month;
        private System.Windows.Forms.RadioButton rButton3Months;
        private System.Windows.Forms.RadioButton rButton6Months;
        private System.Windows.Forms.Button ButtonAccept;
        private System.Windows.Forms.Button ButtonInitialize;
        private System.Windows.Forms.Button ButtonManagement;
    }
}