﻿
namespace CourseManager
{
    partial class CourseManagementForm
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
            this.comingSoonLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comingSoonLabel
            // 
            this.comingSoonLabel.BackColor = System.Drawing.SystemColors.Control;
            this.comingSoonLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comingSoonLabel.Font = new System.Drawing.Font("Consolas", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comingSoonLabel.Location = new System.Drawing.Point(0, 0);
            this.comingSoonLabel.Name = "comingSoonLabel";
            this.comingSoonLabel.Size = new System.Drawing.Size(800, 450);
            this.comingSoonLabel.TabIndex = 0;
            this.comingSoonLabel.Text = "Coming Soon";
            this.comingSoonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CourseManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comingSoonLabel);
            this.Name = "CourseManagementForm";
            this.Text = "CourseManagementForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label comingSoonLabel;
    }
}