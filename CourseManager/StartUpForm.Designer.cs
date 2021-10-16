
namespace CourseManager
{
    partial class StartUpForm
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
            this.courseSelectingSystemButton = new System.Windows.Forms.Button();
            this.courseManagementSystemButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // courseSelectingSystemButton
            // 
            this.courseSelectingSystemButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.courseSelectingSystemButton.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.courseSelectingSystemButton.Location = new System.Drawing.Point(0, 0);
            this.courseSelectingSystemButton.Name = "courseSelectingSystemButton";
            this.courseSelectingSystemButton.Size = new System.Drawing.Size(1000, 200);
            this.courseSelectingSystemButton.TabIndex = 0;
            this.courseSelectingSystemButton.Text = "Course Selecting System";
            this.courseSelectingSystemButton.UseVisualStyleBackColor = true;
            this.courseSelectingSystemButton.Click += new System.EventHandler(this.CourseSelectingSystemButtonClick);
            // 
            // courseManagementSystemButton
            // 
            this.courseManagementSystemButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.courseManagementSystemButton.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.courseManagementSystemButton.Location = new System.Drawing.Point(0, 200);
            this.courseManagementSystemButton.Name = "courseManagementSystemButton";
            this.courseManagementSystemButton.Size = new System.Drawing.Size(1000, 200);
            this.courseManagementSystemButton.TabIndex = 1;
            this.courseManagementSystemButton.Text = "Course Management System";
            this.courseManagementSystemButton.UseVisualStyleBackColor = true;
            this.courseManagementSystemButton.Click += new System.EventHandler(this.CourseManagementSystemButtonClick);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Consolas", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(689, 408);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(299, 140);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButtonClick);
            // 
            // StartUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 560);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.courseManagementSystemButton);
            this.Controls.Add(this.courseSelectingSystemButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "StartUpForm";
            this.Text = "StartUpForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button courseSelectingSystemButton;
        private System.Windows.Forms.Button courseManagementSystemButton;
        private System.Windows.Forms.Button exitButton;
    }
}