namespace DirectoryCleaner
{
    partial class SearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.ListViewFileList = new System.Windows.Forms.ListView();
            this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ButtonRefresh = new System.Windows.Forms.Button();
            this.ButtonAccept = new System.Windows.Forms.Button();
            this.ButtonDeleteSelect = new System.Windows.Forms.Button();
            this.ButtonMove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListViewFileList
            // 
            this.ListViewFileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chType,
            this.chName,
            this.chPath,
            this.chDate,
            this.chSize});
            this.ListViewFileList.Font = new System.Drawing.Font("굴림", 12F);
            this.ListViewFileList.FullRowSelect = true;
            this.ListViewFileList.GridLines = true;
            this.ListViewFileList.Location = new System.Drawing.Point(12, 12);
            this.ListViewFileList.Name = "ListViewFileList";
            this.ListViewFileList.Size = new System.Drawing.Size(1040, 336);
            this.ListViewFileList.TabIndex = 0;
            this.ListViewFileList.UseCompatibleStateImageBehavior = false;
            this.ListViewFileList.View = System.Windows.Forms.View.Details;
            this.ListViewFileList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListViewFileList_ColumnClick);
            this.ListViewFileList.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.ListViewFileList_ItemMouseHover);
            this.ListViewFileList.SelectedIndexChanged += new System.EventHandler(this.ListViewFileList_SelectedIndexChanged);
            this.ListViewFileList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewFileList_MouseDoubleClick);
            this.ListViewFileList.Resize += new System.EventHandler(this.ListViewFileList_Resize);
            // 
            // chType
            // 
            this.chType.Text = "분류";
            // 
            // chName
            // 
            this.chName.Text = "이름";
            this.chName.Width = 160;
            // 
            // chPath
            // 
            this.chPath.Text = "경로";
            this.chPath.Width = 500;
            // 
            // chDate
            // 
            this.chDate.Text = "최종 수정일";
            this.chDate.Width = 240;
            // 
            // chSize
            // 
            this.chSize.Text = "용량(KB)";
            this.chSize.Width = 76;
            // 
            // ButtonRefresh
            // 
            this.ButtonRefresh.AutoSize = true;
            this.ButtonRefresh.Font = new System.Drawing.Font("굴림", 10F);
            this.ButtonRefresh.Location = new System.Drawing.Point(12, 366);
            this.ButtonRefresh.Name = "ButtonRefresh";
            this.ButtonRefresh.Size = new System.Drawing.Size(75, 25);
            this.ButtonRefresh.TabIndex = 2;
            this.ButtonRefresh.Text = "새로고침";
            this.ButtonRefresh.UseVisualStyleBackColor = true;
            this.ButtonRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
            // 
            // ButtonAccept
            // 
            this.ButtonAccept.AutoSize = true;
            this.ButtonAccept.Font = new System.Drawing.Font("굴림", 10F);
            this.ButtonAccept.Location = new System.Drawing.Point(977, 405);
            this.ButtonAccept.Name = "ButtonAccept";
            this.ButtonAccept.Size = new System.Drawing.Size(75, 25);
            this.ButtonAccept.TabIndex = 3;
            this.ButtonAccept.Text = "확인";
            this.ButtonAccept.UseVisualStyleBackColor = true;
            this.ButtonAccept.Click += new System.EventHandler(this.ButtonAccept_Click);
            // 
            // ButtonDeleteSelect
            // 
            this.ButtonDeleteSelect.AutoSize = true;
            this.ButtonDeleteSelect.Font = new System.Drawing.Font("굴림", 10F);
            this.ButtonDeleteSelect.Location = new System.Drawing.Point(12, 405);
            this.ButtonDeleteSelect.Name = "ButtonDeleteSelect";
            this.ButtonDeleteSelect.Size = new System.Drawing.Size(75, 24);
            this.ButtonDeleteSelect.TabIndex = 4;
            this.ButtonDeleteSelect.Text = "삭제";
            this.ButtonDeleteSelect.UseVisualStyleBackColor = true;
            this.ButtonDeleteSelect.Click += new System.EventHandler(this.ButtonDeleteSelect_Click);
            // 
            // ButtonMove
            // 
            this.ButtonMove.Font = new System.Drawing.Font("굴림", 10F);
            this.ButtonMove.Location = new System.Drawing.Point(977, 368);
            this.ButtonMove.Name = "ButtonMove";
            this.ButtonMove.Size = new System.Drawing.Size(75, 23);
            this.ButtonMove.TabIndex = 5;
            this.ButtonMove.Text = "일괄이동";
            this.ButtonMove.UseVisualStyleBackColor = true;
            this.ButtonMove.Click += new System.EventHandler(this.ButtonMove_Click);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 441);
            this.Controls.Add(this.ButtonMove);
            this.Controls.Add(this.ButtonDeleteSelect);
            this.Controls.Add(this.ButtonAccept);
            this.Controls.Add(this.ButtonRefresh);
            this.Controls.Add(this.ListViewFileList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Search";
            this.Text = " ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Search_FormClosed);
            this.Load += new System.EventHandler(this.Search_Load);
            this.ResizeBegin += new System.EventHandler(this.Search_ResizeBegin);
            this.Resize += new System.EventHandler(this.Search_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ListViewFileList;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chPath;
        private System.Windows.Forms.ColumnHeader chDate;
        private System.Windows.Forms.ColumnHeader chSize;
        private System.Windows.Forms.Button ButtonRefresh;
        private System.Windows.Forms.Button ButtonAccept;
        private System.Windows.Forms.Button ButtonDeleteSelect;
        private System.Windows.Forms.Button ButtonMove;
        private System.Windows.Forms.ColumnHeader chType;
    }
}