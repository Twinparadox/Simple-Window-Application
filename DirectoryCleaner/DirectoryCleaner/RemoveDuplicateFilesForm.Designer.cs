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
            this.SuspendLayout();
            // 
            // ListViewDuplicateList
            // 
            this.ListViewDuplicateList.Location = new System.Drawing.Point(12, 12);
            this.ListViewDuplicateList.Name = "ListViewDuplicateList";
            this.ListViewDuplicateList.Size = new System.Drawing.Size(640, 330);
            this.ListViewDuplicateList.TabIndex = 0;
            this.ListViewDuplicateList.UseCompatibleStateImageBehavior = false;
            this.ListViewDuplicateList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewDuplicateList_MouseDoubleClick);
            // 
            // RemoveDuplicateFilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 354);
            this.Controls.Add(this.ListViewDuplicateList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RemoveDuplicateFilesForm";
            this.Text = "DirectoryCleaner - 중복 파일 정리";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ListViewDuplicateList;
    }
}