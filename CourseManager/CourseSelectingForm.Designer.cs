
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
            this.courseSelectionResultButton = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.courseTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.courseDataGridView = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.courseTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.courseDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // courseSelectionResultButton
            // 
            this.courseSelectionResultButton.Location = new System.Drawing.Point(1249, 596);
            this.courseSelectionResultButton.Name = "courseSelectionResultButton";
            this.courseSelectionResultButton.Size = new System.Drawing.Size(320, 120);
            this.courseSelectionResultButton.TabIndex = 0;
            this.courseSelectionResultButton.Text = "查看選課結果";
            this.courseSelectionResultButton.UseVisualStyleBackColor = true;
            this.courseSelectionResultButton.Click += new System.EventHandler(this.CourseSelectionResultButtonClick);
            // 
            // _submitButton
            // 
            this.submitButton.Enabled = false;
            this.submitButton.Location = new System.Drawing.Point(923, 596);
            this.submitButton.Name = "_submitButton";
            this.submitButton.Size = new System.Drawing.Size(320, 120);
            this.submitButton.TabIndex = 1;
            this.submitButton.Text = "確認送出";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButtonClick);
            // 
            // courseTabControl
            // 
            this.courseTabControl.Controls.Add(this.tabPage1);
            this.courseTabControl.Controls.Add(this.tabPage2);
            this.courseTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.courseTabControl.Location = new System.Drawing.Point(0, 0);
            this.courseTabControl.Name = "courseTabControl";
            this.courseTabControl.Padding = new System.Drawing.Point(3, 3);
            this.courseTabControl.SelectedIndex = 0;
            this.courseTabControl.Size = new System.Drawing.Size(1574, 590);
            this.courseTabControl.TabIndex = 3;
            this.courseTabControl.SelectedIndexChanged += new System.EventHandler(this.CourseTabControlSelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.courseDataGridView);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1558, 543);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // courseDataGridView
            // 
            this.courseDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.courseDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.courseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.courseDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.courseDataGridView.Location = new System.Drawing.Point(0, 0);
            this.courseDataGridView.Name = "courseDataGridView";
            this.courseDataGridView.ReadOnly = true;
            this.courseDataGridView.RowHeadersVisible = false;
            this.courseDataGridView.RowHeadersWidth = 100;
            this.courseDataGridView.RowTemplate.Height = 20;
            this.courseDataGridView.Size = new System.Drawing.Size(1558, 543);
            this.courseDataGridView.TabIndex = 0;
            this.courseDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CourseDataGridViewCellClicked);
            this.courseDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CourseDataGridViewCellValueChanged);
            this.courseDataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.CourseDataGridViewCurrentCellDirtyStateChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1558, 543);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // CourseSelectingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1574, 729);
            this.Controls.Add(this.courseTabControl);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.courseSelectionResultButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CourseSelectingForm";
            this.Text = "選課";
            this.Load += new System.EventHandler(this.CourseSelectingFormLoad);
            this.courseTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.courseDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button courseSelectionResultButton;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.TabControl courseTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView courseDataGridView;
    }
}

