
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
            this._courseDataGridView = new System.Windows.Forms.DataGridView();
            this.courseTabControl = new System.Windows.Forms.TabControl();
            this.computerScience3TabPage = new System.Windows.Forms.TabPage();
            this.electronicEngineering3ATabPage = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this._courseDataGridView)).BeginInit();
            this.courseTabControl.SuspendLayout();
            this.computerScience3TabPage.SuspendLayout();
            this.electronicEngineering3ATabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            // _courseDataGridView
            // 
            this._courseDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this._courseDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this._courseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._courseDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._courseDataGridView.Location = new System.Drawing.Point(3, 3);
            this._courseDataGridView.Name = "_courseDataGridView";
            this._courseDataGridView.ReadOnly = true;
            this._courseDataGridView.RowHeadersVisible = false;
            this._courseDataGridView.RowHeadersWidth = 100;
            this._courseDataGridView.RowTemplate.Height = 20;
            this._courseDataGridView.Size = new System.Drawing.Size(1552, 537);
            this._courseDataGridView.TabIndex = 2;
            this._courseDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CourseDataGridViewCellClicked);
            this._courseDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CourseDataGridViewCellValueChanged);
            this._courseDataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.CourseDataGridViewCurrentCellDirtyStateChanged);
            // 
            // courseTabControl
            // 
            this.courseTabControl.Controls.Add(this.computerScience3TabPage);
            this.courseTabControl.Controls.Add(this.electronicEngineering3ATabPage);
            this.courseTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.courseTabControl.Location = new System.Drawing.Point(0, 0);
            this.courseTabControl.Name = "courseTabControl";
            this.courseTabControl.SelectedIndex = 0;
            this.courseTabControl.Size = new System.Drawing.Size(1574, 590);
            this.courseTabControl.TabIndex = 3;
            // 
            // computerScience3TabPage
            // 
            this.computerScience3TabPage.Controls.Add(this._courseDataGridView);
            this.computerScience3TabPage.Location = new System.Drawing.Point(8, 39);
            this.computerScience3TabPage.Name = "computerScience3TabPage";
            this.computerScience3TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.computerScience3TabPage.Size = new System.Drawing.Size(1558, 543);
            this.computerScience3TabPage.TabIndex = 0;
            this.computerScience3TabPage.Text = "資工三";
            this.computerScience3TabPage.UseVisualStyleBackColor = true;
            // 
            // electronicEngineering3ATabPage
            // 
            this.electronicEngineering3ATabPage.Controls.Add(this.dataGridView1);
            this.electronicEngineering3ATabPage.Location = new System.Drawing.Point(8, 39);
            this.electronicEngineering3ATabPage.Name = "electronicEngineering3ATabPage";
            this.electronicEngineering3ATabPage.Padding = new System.Windows.Forms.Padding(3);
            this.electronicEngineering3ATabPage.Size = new System.Drawing.Size(1558, 543);
            this.electronicEngineering3ATabPage.TabIndex = 1;
            this.electronicEngineering3ATabPage.Text = "電子三甲";
            this.electronicEngineering3ATabPage.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 100;
            this.dataGridView1.RowTemplate.Height = 20;
            this.dataGridView1.Size = new System.Drawing.Size(1552, 537);
            this.dataGridView1.TabIndex = 3;
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
            ((System.ComponentModel.ISupportInitialize)(this._courseDataGridView)).EndInit();
            this.courseTabControl.ResumeLayout(false);
            this.computerScience3TabPage.ResumeLayout(false);
            this.electronicEngineering3ATabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _exploreCourseButton;
        private System.Windows.Forms.Button _submitButton;
        private System.Windows.Forms.DataGridView _courseDataGridView;
        private System.Windows.Forms.TabControl courseTabControl;
        private System.Windows.Forms.TabPage computerScience3TabPage;
        private System.Windows.Forms.TabPage electronicEngineering3ATabPage;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

