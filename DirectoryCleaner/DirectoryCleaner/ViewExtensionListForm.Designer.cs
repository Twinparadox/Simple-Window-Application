namespace DirectoryCleaner
{
    partial class ViewExtensionListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewExtensionListForm));
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.ButtonAddExtension = new System.Windows.Forms.Button();
            this.ListViewExtension = new System.Windows.Forms.ListView();
            this.chKind = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chContent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CheckBoxDocument = new System.Windows.Forms.CheckBox();
            this.CheckBoxImage = new System.Windows.Forms.CheckBox();
            this.CheckBoxAudio = new System.Windows.Forms.CheckBox();
            this.CheckBoxVideo = new System.Windows.Forms.CheckBox();
            this.CheckBoxCompact = new System.Windows.Forms.CheckBox();
            this.CheckBoxEtc = new System.Windows.Forms.CheckBox();
            this.ComboBoxList = new System.Windows.Forms.ComboBox();
            this.ButtonAccept = new System.Windows.Forms.Button();
            this.CheckBoxTxt = new System.Windows.Forms.CheckBox();
            this.CheckBoxDisc = new System.Windows.Forms.CheckBox();
            this.CheckBoxDevelope = new System.Windows.Forms.CheckBox();
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
            // CheckBoxDocument
            // 
            this.CheckBoxDocument.AutoSize = true;
            this.CheckBoxDocument.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CheckBoxDocument.Checked = true;
            this.CheckBoxDocument.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxDocument.Font = new System.Drawing.Font("굴림", 10F);
            this.CheckBoxDocument.Location = new System.Drawing.Point(118, 249);
            this.CheckBoxDocument.Name = "CheckBoxDocument";
            this.CheckBoxDocument.Size = new System.Drawing.Size(39, 32);
            this.CheckBoxDocument.TabIndex = 3;
            this.CheckBoxDocument.Text = "문서";
            this.CheckBoxDocument.UseVisualStyleBackColor = true;
            this.CheckBoxDocument.CheckedChanged += new System.EventHandler(this.CheckBoxDocument_CheckedChanged);
            // 
            // CheckBoxImage
            // 
            this.CheckBoxImage.AutoSize = true;
            this.CheckBoxImage.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CheckBoxImage.Checked = true;
            this.CheckBoxImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxImage.Font = new System.Drawing.Font("굴림", 10F);
            this.CheckBoxImage.Location = new System.Drawing.Point(12, 249);
            this.CheckBoxImage.Name = "CheckBoxImage";
            this.CheckBoxImage.Size = new System.Drawing.Size(53, 32);
            this.CheckBoxImage.TabIndex = 4;
            this.CheckBoxImage.Text = "이미지";
            this.CheckBoxImage.UseVisualStyleBackColor = true;
            this.CheckBoxImage.CheckedChanged += new System.EventHandler(this.CheckBoxImage_CheckedChanged);
            // 
            // CheckBoxAudio
            // 
            this.CheckBoxAudio.AutoSize = true;
            this.CheckBoxAudio.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CheckBoxAudio.Checked = true;
            this.CheckBoxAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxAudio.Font = new System.Drawing.Font("굴림", 10F);
            this.CheckBoxAudio.Location = new System.Drawing.Point(219, 249);
            this.CheckBoxAudio.Name = "CheckBoxAudio";
            this.CheckBoxAudio.Size = new System.Drawing.Size(53, 32);
            this.CheckBoxAudio.TabIndex = 5;
            this.CheckBoxAudio.Text = "오디오";
            this.CheckBoxAudio.UseVisualStyleBackColor = true;
            this.CheckBoxAudio.CheckedChanged += new System.EventHandler(this.CheckBoxAudio_CheckedChanged);
            // 
            // CheckBoxVideo
            // 
            this.CheckBoxVideo.AutoSize = true;
            this.CheckBoxVideo.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CheckBoxVideo.Checked = true;
            this.CheckBoxVideo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxVideo.Font = new System.Drawing.Font("굴림", 10F);
            this.CheckBoxVideo.Location = new System.Drawing.Point(12, 316);
            this.CheckBoxVideo.Name = "CheckBoxVideo";
            this.CheckBoxVideo.Size = new System.Drawing.Size(53, 32);
            this.CheckBoxVideo.TabIndex = 6;
            this.CheckBoxVideo.Text = "비디오";
            this.CheckBoxVideo.UseVisualStyleBackColor = true;
            this.CheckBoxVideo.CheckedChanged += new System.EventHandler(this.CheckBoxVideo_CheckedChanged);
            // 
            // CheckBoxCompact
            // 
            this.CheckBoxCompact.AutoSize = true;
            this.CheckBoxCompact.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CheckBoxCompact.Checked = true;
            this.CheckBoxCompact.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxCompact.Font = new System.Drawing.Font("굴림", 10F);
            this.CheckBoxCompact.Location = new System.Drawing.Point(118, 316);
            this.CheckBoxCompact.Name = "CheckBoxCompact";
            this.CheckBoxCompact.Size = new System.Drawing.Size(39, 32);
            this.CheckBoxCompact.TabIndex = 7;
            this.CheckBoxCompact.Text = "압축";
            this.CheckBoxCompact.UseVisualStyleBackColor = true;
            this.CheckBoxCompact.CheckedChanged += new System.EventHandler(this.CheckBoxCompact_CheckedChanged);
            // 
            // CheckBoxEtc
            // 
            this.CheckBoxEtc.AutoSize = true;
            this.CheckBoxEtc.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CheckBoxEtc.Checked = true;
            this.CheckBoxEtc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxEtc.Font = new System.Drawing.Font("굴림", 10F);
            this.CheckBoxEtc.Location = new System.Drawing.Point(219, 316);
            this.CheckBoxEtc.Name = "CheckBoxEtc";
            this.CheckBoxEtc.Size = new System.Drawing.Size(53, 32);
            this.CheckBoxEtc.TabIndex = 8;
            this.CheckBoxEtc.Text = "사용자";
            this.CheckBoxEtc.UseVisualStyleBackColor = true;
            this.CheckBoxEtc.CheckedChanged += new System.EventHandler(this.CheckBoxEtc_CheckedChanged);
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
            // CheckBoxTxt
            // 
            this.CheckBoxTxt.AutoSize = true;
            this.CheckBoxTxt.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CheckBoxTxt.Checked = true;
            this.CheckBoxTxt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxTxt.Font = new System.Drawing.Font("굴림", 10F);
            this.CheckBoxTxt.Location = new System.Drawing.Point(12, 371);
            this.CheckBoxTxt.Name = "CheckBoxTxt";
            this.CheckBoxTxt.Size = new System.Drawing.Size(53, 32);
            this.CheckBoxTxt.TabIndex = 10;
            this.CheckBoxTxt.Text = "텍스트";
            this.CheckBoxTxt.UseVisualStyleBackColor = true;
            this.CheckBoxTxt.CheckedChanged += new System.EventHandler(this.CheckBoxTxt_CheckedChanged);
            // 
            // CheckBoxDisc
            // 
            this.CheckBoxDisc.AutoSize = true;
            this.CheckBoxDisc.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CheckBoxDisc.Checked = true;
            this.CheckBoxDisc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxDisc.Font = new System.Drawing.Font("굴림", 10F);
            this.CheckBoxDisc.Location = new System.Drawing.Point(219, 371);
            this.CheckBoxDisc.Name = "CheckBoxDisc";
            this.CheckBoxDisc.Size = new System.Drawing.Size(53, 32);
            this.CheckBoxDisc.TabIndex = 11;
            this.CheckBoxDisc.Text = "디스크";
            this.CheckBoxDisc.UseVisualStyleBackColor = true;
            this.CheckBoxDisc.CheckedChanged += new System.EventHandler(this.CheckBoxDisc_CheckedChanged);
            // 
            // CheckBoxDevelope
            // 
            this.CheckBoxDevelope.AutoSize = true;
            this.CheckBoxDevelope.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CheckBoxDevelope.Checked = true;
            this.CheckBoxDevelope.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxDevelope.Font = new System.Drawing.Font("굴림", 10F);
            this.CheckBoxDevelope.Location = new System.Drawing.Point(118, 371);
            this.CheckBoxDevelope.Name = "CheckBoxDevelope";
            this.CheckBoxDevelope.Size = new System.Drawing.Size(39, 32);
            this.CheckBoxDevelope.TabIndex = 12;
            this.CheckBoxDevelope.Text = "개발";
            this.CheckBoxDevelope.UseVisualStyleBackColor = true;
            this.CheckBoxDevelope.CheckedChanged += new System.EventHandler(this.CheckBoxDevelope_CheckedChanged);
            // 
            // ViewExtensionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 500);
            this.Controls.Add(this.CheckBoxDevelope);
            this.Controls.Add(this.CheckBoxDisc);
            this.Controls.Add(this.CheckBoxTxt);
            this.Controls.Add(this.ButtonAccept);
            this.Controls.Add(this.ComboBoxList);
            this.Controls.Add(this.CheckBoxEtc);
            this.Controls.Add(this.CheckBoxCompact);
            this.Controls.Add(this.CheckBoxVideo);
            this.Controls.Add(this.CheckBoxAudio);
            this.Controls.Add(this.CheckBoxImage);
            this.Controls.Add(this.CheckBoxDocument);
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
        private System.Windows.Forms.CheckBox CheckBoxDocument;
        private System.Windows.Forms.CheckBox CheckBoxImage;
        private System.Windows.Forms.CheckBox CheckBoxAudio;
        private System.Windows.Forms.CheckBox CheckBoxVideo;
        private System.Windows.Forms.CheckBox CheckBoxCompact;
        private System.Windows.Forms.CheckBox CheckBoxEtc;
        private System.Windows.Forms.ComboBox ComboBoxList;
        private System.Windows.Forms.Button ButtonAccept;
        private System.Windows.Forms.CheckBox CheckBoxTxt;
        private System.Windows.Forms.CheckBox CheckBoxDisc;
        private System.Windows.Forms.CheckBox CheckBoxDevelope;
    }
}