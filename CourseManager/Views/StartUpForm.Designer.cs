
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
            this._courseSelectingSystemButton = new System.Windows.Forms.Button();
            this._courseManagementSystemButton = new System.Windows.Forms.Button();
            this._exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _courseSelectingSystemButton
            // 
            this._courseSelectingSystemButton.Dock = System.Windows.Forms.DockStyle.Top;
            this._courseSelectingSystemButton.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._courseSelectingSystemButton.Location = new System.Drawing.Point(0, 0);
            this._courseSelectingSystemButton.Name = "_courseSelectingSystemButton";
            this._courseSelectingSystemButton.Size = new System.Drawing.Size(1000, 200);
            this._courseSelectingSystemButton.TabIndex = 0;
            this._courseSelectingSystemButton.Text = "Course Selecting System";
            this._courseSelectingSystemButton.UseVisualStyleBackColor = true;
            this._courseSelectingSystemButton.Click += new System.EventHandler(this.CourseSelectingSystemButtonClick);
            // 
            // _courseManagementSystemButton
            // 
            this._courseManagementSystemButton.Dock = System.Windows.Forms.DockStyle.Top;
            this._courseManagementSystemButton.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._courseManagementSystemButton.Location = new System.Drawing.Point(0, 200);
            this._courseManagementSystemButton.Name = "_courseManagementSystemButton";
            this._courseManagementSystemButton.Size = new System.Drawing.Size(1000, 200);
            this._courseManagementSystemButton.TabIndex = 1;
            this._courseManagementSystemButton.Text = "Course Management System";
            this._courseManagementSystemButton.UseVisualStyleBackColor = true;
            this._courseManagementSystemButton.Click += new System.EventHandler(this.CourseManagementSystemButtonClick);
            // 
            // _exitButton
            // 
            this._exitButton.Font = new System.Drawing.Font("Consolas", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._exitButton.Location = new System.Drawing.Point(689, 408);
            this._exitButton.Name = "_exitButton";
            this._exitButton.Size = new System.Drawing.Size(299, 140);
            this._exitButton.TabIndex = 2;
            this._exitButton.Text = "Exit";
            this._exitButton.UseVisualStyleBackColor = true;
            this._exitButton.Click += new System.EventHandler(this.ExitButtonClick);
            // 
            // StartUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 560);
            this.Controls.Add(this._exitButton);
            this.Controls.Add(this._courseManagementSystemButton);
            this.Controls.Add(this._courseSelectingSystemButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "StartUpForm";
            this.Text = "選課系統";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _courseSelectingSystemButton;
        private System.Windows.Forms.Button _courseManagementSystemButton;
        private System.Windows.Forms.Button _exitButton;
    }
}