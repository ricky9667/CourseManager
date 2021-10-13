
namespace CourseManager
{
    partial class CourseSelectingForm
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
            this._exploreCourseButton = new System.Windows.Forms.Button();
            this._submitButton = new System.Windows.Forms.Button();
            this.courseTabControl = new System.Windows.Forms.TabControl();
            this.courseTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // _exploreCourseButton
            // 
            this._exploreCourseButton.Location = new System.Drawing.Point(1249, 596);
            this._exploreCourseButton.Name = "_exploreCourseButton";
            this._exploreCourseButton.Size = new System.Drawing.Size(320, 120);
            this._exploreCourseButton.TabIndex = 0;
            this._exploreCourseButton.Text = "查看選課結果";
            this._exploreCourseButton.UseVisualStyleBackColor = true;
            // 
            // _submitButton
            // 
            this._submitButton.Enabled = false;
            this._submitButton.Location = new System.Drawing.Point(923, 596);
            this._submitButton.Name = "_submitButton";
            this._submitButton.Size = new System.Drawing.Size(320, 120);
            this._submitButton.TabIndex = 1;
            this._submitButton.Text = "確認送出";
            this._submitButton.UseVisualStyleBackColor = true;
            // 
            // courseTabControl
            // 
            this.courseTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.courseTabControl.Location = new System.Drawing.Point(0, 0);
            this.courseTabControl.Name = "courseTabControl";
            this.courseTabControl.SelectedIndex = 0;
            this.courseTabControl.Size = new System.Drawing.Size(1574, 590);
            this.courseTabControl.TabIndex = 3;
            // 
            // CourseSelectingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1574, 729);
            this.Controls.Add(this.courseTabControl);
            this.Controls.Add(this._submitButton);
            this.Controls.Add(this._exploreCourseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CourseSelectingForm";
            this.Text = "選課";
            this.Load += new System.EventHandler(this.SelectCourseFormLoad);
            this.courseTabControl.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button _exploreCourseButton;
        private System.Windows.Forms.Button _submitButton;
        private System.Windows.Forms.TabControl courseTabControl;
    }
}

