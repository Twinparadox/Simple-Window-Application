namespace TPWord
{
    partial class NoteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteForm));
            this.TrackBarPage = new System.Windows.Forms.TrackBar();
            this.ListViewWord = new System.Windows.Forms.ListView();
            this.chWord = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ButtonPrevPage = new System.Windows.Forms.Button();
            this.ButtonNextPage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarPage)).BeginInit();
            this.SuspendLayout();
            // 
            // TrackBarPage
            // 
            this.TrackBarPage.Location = new System.Drawing.Point(53, 618);
            this.TrackBarPage.Name = "TrackBarPage";
            this.TrackBarPage.Size = new System.Drawing.Size(418, 45);
            this.TrackBarPage.TabIndex = 3;
            this.TrackBarPage.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // ListViewWord
            // 
            this.ListViewWord.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.ListViewWord.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chWord});
            this.ListViewWord.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ListViewWord.LabelWrap = false;
            this.ListViewWord.Location = new System.Drawing.Point(12, 12);
            this.ListViewWord.Name = "ListViewWord";
            this.ListViewWord.Size = new System.Drawing.Size(500, 600);
            this.ListViewWord.TabIndex = 4;
            this.ListViewWord.UseCompatibleStateImageBehavior = false;
            this.ListViewWord.View = System.Windows.Forms.View.List;
            this.ListViewWord.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.ListViewWord_ItemMouseHover);
            // 
            // chWord
            // 
            this.chWord.Text = "단어";
            this.chWord.Width = 500;
            // 
            // ButtonPrevPage
            // 
            this.ButtonPrevPage.Location = new System.Drawing.Point(12, 618);
            this.ButtonPrevPage.Name = "ButtonPrevPage";
            this.ButtonPrevPage.Size = new System.Drawing.Size(35, 45);
            this.ButtonPrevPage.TabIndex = 5;
            this.ButtonPrevPage.Text = "button1";
            this.ButtonPrevPage.UseVisualStyleBackColor = true;
            this.ButtonPrevPage.Click += new System.EventHandler(this.ButtonPrevPage_Click);
            // 
            // ButtonNextPage
            // 
            this.ButtonNextPage.Location = new System.Drawing.Point(477, 618);
            this.ButtonNextPage.Name = "ButtonNextPage";
            this.ButtonNextPage.Size = new System.Drawing.Size(35, 45);
            this.ButtonNextPage.TabIndex = 6;
            this.ButtonNextPage.Text = "button2";
            this.ButtonNextPage.UseVisualStyleBackColor = true;
            this.ButtonNextPage.Click += new System.EventHandler(this.ButtonNextPage_Click);
            // 
            // NoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 690);
            this.Controls.Add(this.ButtonNextPage);
            this.Controls.Add(this.ButtonPrevPage);
            this.Controls.Add(this.ListViewWord);
            this.Controls.Add(this.TrackBarPage);
            this.Font = new System.Drawing.Font("나눔스퀘어 ExtraBold", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NoteForm";
            this.ShowIcon = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.NoteForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarPage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar TrackBarPage;
        private System.Windows.Forms.ListView ListViewWord;
        private System.Windows.Forms.Button ButtonPrevPage;
        private System.Windows.Forms.Button ButtonNextPage;
        private System.Windows.Forms.ColumnHeader chWord;
    }
}