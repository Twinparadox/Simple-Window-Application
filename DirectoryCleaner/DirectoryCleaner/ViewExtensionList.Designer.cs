namespace DirectoryCleaner
{
    partial class ViewExtensionList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewExtensionList));
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.ButtonAddExtension = new System.Windows.Forms.Button();
            this.ListViewExtension = new System.Windows.Forms.ListView();
            this.chKind = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chContent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ComboBoxDocument = new System.Windows.Forms.CheckBox();
            this.ComboBoxImage = new System.Windows.Forms.CheckBox();
            this.ComboBoxAudio = new System.Windows.Forms.CheckBox();
            this.ComboBoxVideo = new System.Windows.Forms.CheckBox();
            this.ComboBoxCompact = new System.Windows.Forms.CheckBox();
            this.ComboBoxEtc = new System.Windows.Forms.CheckBox();
            this.ComboBoxList = new System.Windows.Forms.ComboBox();
            this.ButtonAccept = new System.Windows.Forms.Button();
            this.ComboBoxTxt = new System.Windows.Forms.CheckBox();
            this.ComboBoxDisc = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtExtension
            // 
            this.txtExtension.Location = new System.Drawing.Point(139, 423);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.Size = new System.Drawing.Size(133, 21);
            this.txtExtension.TabIndex = 0;
            this.txtExtension.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ButtonAddExtension
            // 
            this.ButtonAddExtension.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ButtonAddExtension.Location = new System.Drawing.Point(197, 465);
            this.ButtonAddExtension.Name = "ButtonAddExtension";
            this.ButtonAddExtension.Size = new System.Drawing.Size(75, 23);
            this.ButtonAddExtension.TabIndex = 1;
            this.ButtonAddExtension.Text = "Add";
            this.ButtonAddExtension.UseVisualStyleBackColor = true;
            this.ButtonAddExtension.Click += new System.EventHandler(this.ButtonAddExtension_Click);
            // 
            // ListViewExtension
            // 
            this.ListViewExtension.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chKind,
            this.chContent});
            this.ListViewExtension.GridLines = true;
            this.ListViewExtension.Location = new System.Drawing.Point(12, 12);
            this.ListViewExtension.Name = "ListViewExtension";
            this.ListViewExtension.Size = new System.Drawing.Size(260, 210);
            this.ListViewExtension.TabIndex = 2;
            this.ListViewExtension.UseCompatibleStateImageBehavior = false;
            this.ListViewExtension.View = System.Windows.Forms.View.Details;
            // 
            // chKind
            // 
            this.chKind.Text = "종류";
            // 
            // chContent
            // 
            this.chContent.Text = "내용";
            this.chContent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chContent.Width = 196;
            // 
            // ComboBoxDocument
            // 
            this.ComboBoxDocument.AutoSize = true;
            this.ComboBoxDocument.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ComboBoxDocument.Checked = true;
            this.ComboBoxDocument.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ComboBoxDocument.Font = new System.Drawing.Font("굴림", 10F);
            this.ComboBoxDocument.Location = new System.Drawing.Point(118, 249);
            this.ComboBoxDocument.Name = "ComboBoxDocument";
            this.ComboBoxDocument.Size = new System.Drawing.Size(39, 32);
            this.ComboBoxDocument.TabIndex = 3;
            this.ComboBoxDocument.Text = "문서";
            this.ComboBoxDocument.UseVisualStyleBackColor = true;
            this.ComboBoxDocument.CheckedChanged += new System.EventHandler(this.ComboBoxDocument_CheckedChanged);
            // 
            // ComboBoxImage
            // 
            this.ComboBoxImage.AutoSize = true;
            this.ComboBoxImage.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ComboBoxImage.Checked = true;
            this.ComboBoxImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ComboBoxImage.Font = new System.Drawing.Font("굴림", 10F);
            this.ComboBoxImage.Location = new System.Drawing.Point(12, 249);
            this.ComboBoxImage.Name = "ComboBoxImage";
            this.ComboBoxImage.Size = new System.Drawing.Size(53, 32);
            this.ComboBoxImage.TabIndex = 4;
            this.ComboBoxImage.Text = "이미지";
            this.ComboBoxImage.UseVisualStyleBackColor = true;
            this.ComboBoxImage.CheckedChanged += new System.EventHandler(this.ComboBoxImage_CheckedChanged);
            // 
            // ComboBoxAudio
            // 
            this.ComboBoxAudio.AutoSize = true;
            this.ComboBoxAudio.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ComboBoxAudio.Checked = true;
            this.ComboBoxAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ComboBoxAudio.Font = new System.Drawing.Font("굴림", 10F);
            this.ComboBoxAudio.Location = new System.Drawing.Point(219, 249);
            this.ComboBoxAudio.Name = "ComboBoxAudio";
            this.ComboBoxAudio.Size = new System.Drawing.Size(53, 32);
            this.ComboBoxAudio.TabIndex = 5;
            this.ComboBoxAudio.Text = "오디오";
            this.ComboBoxAudio.UseVisualStyleBackColor = true;
            this.ComboBoxAudio.CheckedChanged += new System.EventHandler(this.ComboBoxAudio_CheckedChanged);
            // 
            // ComboBoxVideo
            // 
            this.ComboBoxVideo.AutoSize = true;
            this.ComboBoxVideo.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ComboBoxVideo.Checked = true;
            this.ComboBoxVideo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ComboBoxVideo.Font = new System.Drawing.Font("굴림", 10F);
            this.ComboBoxVideo.Location = new System.Drawing.Point(12, 316);
            this.ComboBoxVideo.Name = "ComboBoxVideo";
            this.ComboBoxVideo.Size = new System.Drawing.Size(53, 32);
            this.ComboBoxVideo.TabIndex = 6;
            this.ComboBoxVideo.Text = "비디오";
            this.ComboBoxVideo.UseVisualStyleBackColor = true;
            this.ComboBoxVideo.CheckedChanged += new System.EventHandler(this.ComboBoxVideo_CheckedChanged);
            // 
            // ComboBoxCompact
            // 
            this.ComboBoxCompact.AutoSize = true;
            this.ComboBoxCompact.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ComboBoxCompact.Checked = true;
            this.ComboBoxCompact.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ComboBoxCompact.Font = new System.Drawing.Font("굴림", 10F);
            this.ComboBoxCompact.Location = new System.Drawing.Point(118, 316);
            this.ComboBoxCompact.Name = "ComboBoxCompact";
            this.ComboBoxCompact.Size = new System.Drawing.Size(39, 32);
            this.ComboBoxCompact.TabIndex = 7;
            this.ComboBoxCompact.Text = "압축";
            this.ComboBoxCompact.UseVisualStyleBackColor = true;
            this.ComboBoxCompact.CheckedChanged += new System.EventHandler(this.ComboBoxCompact_CheckedChanged);
            // 
            // ComboBoxEtc
            // 
            this.ComboBoxEtc.AutoSize = true;
            this.ComboBoxEtc.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ComboBoxEtc.Checked = true;
            this.ComboBoxEtc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ComboBoxEtc.Font = new System.Drawing.Font("굴림", 10F);
            this.ComboBoxEtc.Location = new System.Drawing.Point(219, 316);
            this.ComboBoxEtc.Name = "ComboBoxEtc";
            this.ComboBoxEtc.Size = new System.Drawing.Size(53, 32);
            this.ComboBoxEtc.TabIndex = 8;
            this.ComboBoxEtc.Text = "사용자";
            this.ComboBoxEtc.UseVisualStyleBackColor = true;
            this.ComboBoxEtc.CheckedChanged += new System.EventHandler(this.ComboBoxEtc_CheckedChanged);
            // 
            // ComboBoxList
            // 
            this.ComboBoxList.Font = new System.Drawing.Font("굴림", 10F);
            this.ComboBoxList.FormattingEnabled = true;
            this.ComboBoxList.Location = new System.Drawing.Point(12, 422);
            this.ComboBoxList.Name = "ComboBoxList";
            this.ComboBoxList.Size = new System.Drawing.Size(121, 21);
            this.ComboBoxList.TabIndex = 6;
            this.ComboBoxList.Text = "확장자 종류 선택";
            // 
            // ButtonAccept
            // 
            this.ButtonAccept.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ButtonAccept.Location = new System.Drawing.Point(12, 465);
            this.ButtonAccept.Name = "ButtonAccept";
            this.ButtonAccept.Size = new System.Drawing.Size(75, 23);
            this.ButtonAccept.TabIndex = 9;
            this.ButtonAccept.Text = "확인";
            this.ButtonAccept.UseVisualStyleBackColor = true;
            this.ButtonAccept.Click += new System.EventHandler(this.ButtonAccept_Click);
            // 
            // ComboBoxTxt
            // 
            this.ComboBoxTxt.AutoSize = true;
            this.ComboBoxTxt.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ComboBoxTxt.Checked = true;
            this.ComboBoxTxt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ComboBoxTxt.Font = new System.Drawing.Font("굴림", 10F);
            this.ComboBoxTxt.Location = new System.Drawing.Point(12, 371);
            this.ComboBoxTxt.Name = "ComboBoxTxt";
            this.ComboBoxTxt.Size = new System.Drawing.Size(53, 32);
            this.ComboBoxTxt.TabIndex = 10;
            this.ComboBoxTxt.Text = "텍스트";
            this.ComboBoxTxt.UseVisualStyleBackColor = true;
            this.ComboBoxTxt.CheckedChanged += new System.EventHandler(this.ComboBoxTxt_CheckedChanged);
            // 
            // ComboBoxDisc
            // 
            this.ComboBoxDisc.AutoSize = true;
            this.ComboBoxDisc.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ComboBoxDisc.Checked = true;
            this.ComboBoxDisc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ComboBoxDisc.Font = new System.Drawing.Font("굴림", 10F);
            this.ComboBoxDisc.Location = new System.Drawing.Point(219, 371);
            this.ComboBoxDisc.Name = "ComboBoxDisc";
            this.ComboBoxDisc.Size = new System.Drawing.Size(53, 32);
            this.ComboBoxDisc.TabIndex = 11;
            this.ComboBoxDisc.Text = "디스크";
            this.ComboBoxDisc.UseVisualStyleBackColor = true;
            this.ComboBoxDisc.CheckedChanged += new System.EventHandler(this.ComboBoxDisc_CheckedChanged);
            // 
            // ViewExtensionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 500);
            this.Controls.Add(this.ComboBoxDisc);
            this.Controls.Add(this.ComboBoxTxt);
            this.Controls.Add(this.ButtonAccept);
            this.Controls.Add(this.ComboBoxList);
            this.Controls.Add(this.ComboBoxEtc);
            this.Controls.Add(this.ComboBoxCompact);
            this.Controls.Add(this.ComboBoxVideo);
            this.Controls.Add(this.ComboBoxAudio);
            this.Controls.Add(this.ComboBoxImage);
            this.Controls.Add(this.ComboBoxDocument);
            this.Controls.Add(this.ListViewExtension);
            this.Controls.Add(this.ButtonAddExtension);
            this.Controls.Add(this.txtExtension);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ViewExtensionList";
            this.ShowInTaskbar = false;
            this.Text = "확장자 관리";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ViewExtensionList_FormClosed);
            this.Load += new System.EventHandler(this.ViewExtensionList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtExtension;
        private System.Windows.Forms.Button ButtonAddExtension;
        private System.Windows.Forms.ListView ListViewExtension;
        private System.Windows.Forms.ColumnHeader chKind;
        private System.Windows.Forms.ColumnHeader chContent;
        private System.Windows.Forms.CheckBox ComboBoxDocument;
        private System.Windows.Forms.CheckBox ComboBoxImage;
        private System.Windows.Forms.CheckBox ComboBoxAudio;
        private System.Windows.Forms.CheckBox ComboBoxVideo;
        private System.Windows.Forms.CheckBox ComboBoxCompact;
        private System.Windows.Forms.CheckBox ComboBoxEtc;
        private System.Windows.Forms.ComboBox ComboBoxList;
        private System.Windows.Forms.Button ButtonAccept;
        private System.Windows.Forms.CheckBox ComboBoxTxt;
        private System.Windows.Forms.CheckBox ComboBoxDisc;
    }
}