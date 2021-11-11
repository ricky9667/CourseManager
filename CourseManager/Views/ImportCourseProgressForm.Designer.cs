
namespace CourseManager
{
    partial class ImportCourseProgressForm
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
            this._importCourseProgressLabel = new System.Windows.Forms.Label();
            this._importCourseProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // _importCourseProgressLabel
            // 
            this._importCourseProgressLabel.AutoSize = true;
            this._importCourseProgressLabel.Location = new System.Drawing.Point(12, 38);
            this._importCourseProgressLabel.Name = "_importCourseProgressLabel";
            this._importCourseProgressLabel.Size = new System.Drawing.Size(208, 24);
            this._importCourseProgressLabel.TabIndex = 0;
            this._importCourseProgressLabel.Text = "正在匯入課程... 0%";
            // 
            // _importCourseProgressBar
            // 
            this._importCourseProgressBar.Location = new System.Drawing.Point(12, 78);
            this._importCourseProgressBar.Name = "_importCourseProgressBar";
            this._importCourseProgressBar.Size = new System.Drawing.Size(772, 80);
            this._importCourseProgressBar.TabIndex = 1;
            // 
            // ImportCourseProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 230);
            this.Controls.Add(this._importCourseProgressBar);
            this.Controls.Add(this._importCourseProgressLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ImportCourseProgressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "匯入課程";
            this.Load += new System.EventHandler(this.ImportCourseProgressFormLoad);
            this.Shown += new System.EventHandler(this.ImportCourseProgressFormShown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _importCourseProgressLabel;
        private System.Windows.Forms.ProgressBar _importCourseProgressBar;
    }
}