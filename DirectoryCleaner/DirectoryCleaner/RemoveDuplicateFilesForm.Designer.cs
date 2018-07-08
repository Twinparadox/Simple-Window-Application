namespace DirectoryCleaner
{
    partial class RemoveDuplicateFilesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoveDuplicateFilesForm));
            this.ListViewDuplicateList = new System.Windows.Forms.ListView();
            this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ButtonDeleteAll = new System.Windows.Forms.Button();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListViewDuplicateList
            // 
            this.ListViewDuplicateList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chType,
            this.chName,
            this.chPath});
            this.ListViewDuplicateList.Font = new System.Drawing.Font("굴림", 9F);
            this.ListViewDuplicateList.FullRowSelect = true;
            this.ListViewDuplicateList.Location = new System.Drawing.Point(12, 12);
            this.ListViewDuplicateList.Name = "ListViewDuplicateList";
            this.ListViewDuplicateList.Size = new System.Drawing.Size(640, 330);
            this.ListViewDuplicateList.TabIndex = 0;
            this.ListViewDuplicateList.UseCompatibleStateImageBehavior = false;
            this.ListViewDuplicateList.View = System.Windows.Forms.View.Details;
            this.ListViewDuplicateList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewDuplicateList_MouseDoubleClick);
            // 
            // chType
            // 
            this.chType.Text = "분류";
            // 
            // chName
            // 
            this.chName.Text = "이름";
            this.chName.Width = 200;
            // 
            // chPath
            // 
            this.chPath.Text = "경로";
            this.chPath.Width = 500;
            // 
            // ButtonDeleteAll
            // 
            this.ButtonDeleteAll.Location = new System.Drawing.Point(658, 154);
            this.ButtonDeleteAll.Name = "ButtonDeleteAll";
            this.ButtonDeleteAll.Size = new System.Drawing.Size(139, 47);
            this.ButtonDeleteAll.TabIndex = 1;
            this.ButtonDeleteAll.Text = "전체 삭제";
            this.ButtonDeleteAll.UseVisualStyleBackColor = true;
            this.ButtonDeleteAll.Click += new System.EventHandler(this.ButtonDeleteAll_Click);
            // 
            // ButtonClose
            // 
            this.ButtonClose.Location = new System.Drawing.Point(658, 295);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(139, 47);
            this.ButtonClose.TabIndex = 2;
            this.ButtonClose.Text = "닫기";
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Location = new System.Drawing.Point(658, 12);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(139, 47);
            this.ButtonDelete.TabIndex = 3;
            this.ButtonDelete.Text = "선택 삭제";
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // RemoveDuplicateFilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 354);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.ButtonDeleteAll);
            this.Controls.Add(this.ListViewDuplicateList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RemoveDuplicateFilesForm";
            this.Text = "DirectoryCleaner - 중복 파일 정리";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ListViewDuplicateList;
        private System.Windows.Forms.Button ButtonDeleteAll;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.ColumnHeader chType;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chPath;
    }
}