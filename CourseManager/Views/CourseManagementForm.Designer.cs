
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
            this.courseManageTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.saveButton = new System.Windows.Forms.Button();
            this.courseGroupBox = new System.Windows.Forms.GroupBox();
            this.timeDataGridView = new System.Windows.Forms.DataGridView();
            this.classTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sundayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mondayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tuesdayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.wednesdayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.thursdayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fridayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.saturdayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.classComboBox = new System.Windows.Forms.ComboBox();
            this.classLabel = new System.Windows.Forms.Label();
            this.hourComboBox = new System.Windows.Forms.ComboBox();
            this.hourLabel = new System.Windows.Forms.Label();
            this.noteTextbox = new System.Windows.Forms.TextBox();
            this.noteLabel = new System.Windows.Forms.Label();
            this.languageTextbox = new System.Windows.Forms.TextBox();
            this.languageLabel = new System.Windows.Forms.Label();
            this.teachingAssistantTextbox = new System.Windows.Forms.TextBox();
            this.teachingAssistantLabel = new System.Windows.Forms.Label();
            this.courseTypeComboBox = new System.Windows.Forms.ComboBox();
            this.courseTypeLabel = new System.Windows.Forms.Label();
            this.teacherTextbox = new System.Windows.Forms.TextBox();
            this.teacher = new System.Windows.Forms.Label();
            this.creditTextbox = new System.Windows.Forms.TextBox();
            this.creditLabel = new System.Windows.Forms.Label();
            this.stageTextbox = new System.Windows.Forms.TextBox();
            this.stageLabel = new System.Windows.Forms.Label();
            this.courseNameTextbox = new System.Windows.Forms.TextBox();
            this.courseNumberTextbox = new System.Windows.Forms.TextBox();
            this.courseNameLabel = new System.Windows.Forms.Label();
            this.courseNumberLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.addCourseButton = new System.Windows.Forms.Button();
            this.courseListBox = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.courseManageTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.courseGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // courseManageTabControl
            // 
            this.courseManageTabControl.Controls.Add(this.tabPage1);
            this.courseManageTabControl.Controls.Add(this.tabPage2);
            this.courseManageTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.courseManageTabControl.Location = new System.Drawing.Point(0, 0);
            this.courseManageTabControl.Name = "courseManageTabControl";
            this.courseManageTabControl.SelectedIndex = 0;
            this.courseManageTabControl.Size = new System.Drawing.Size(1474, 829);
            this.courseManageTabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.saveButton);
            this.tabPage1.Controls.Add(this.courseGroupBox);
            this.tabPage1.Controls.Add(this.addCourseButton);
            this.tabPage1.Controls.Add(this.courseListBox);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1458, 782);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(1119, 681);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(323, 95);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "儲存";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // courseGroupBox
            // 
            this.courseGroupBox.Controls.Add(this.timeDataGridView);
            this.courseGroupBox.Controls.Add(this.classComboBox);
            this.courseGroupBox.Controls.Add(this.classLabel);
            this.courseGroupBox.Controls.Add(this.hourComboBox);
            this.courseGroupBox.Controls.Add(this.hourLabel);
            this.courseGroupBox.Controls.Add(this.noteTextbox);
            this.courseGroupBox.Controls.Add(this.noteLabel);
            this.courseGroupBox.Controls.Add(this.languageTextbox);
            this.courseGroupBox.Controls.Add(this.languageLabel);
            this.courseGroupBox.Controls.Add(this.teachingAssistantTextbox);
            this.courseGroupBox.Controls.Add(this.teachingAssistantLabel);
            this.courseGroupBox.Controls.Add(this.courseTypeComboBox);
            this.courseGroupBox.Controls.Add(this.courseTypeLabel);
            this.courseGroupBox.Controls.Add(this.teacherTextbox);
            this.courseGroupBox.Controls.Add(this.teacher);
            this.courseGroupBox.Controls.Add(this.creditTextbox);
            this.courseGroupBox.Controls.Add(this.creditLabel);
            this.courseGroupBox.Controls.Add(this.stageTextbox);
            this.courseGroupBox.Controls.Add(this.stageLabel);
            this.courseGroupBox.Controls.Add(this.courseNameTextbox);
            this.courseGroupBox.Controls.Add(this.courseNumberTextbox);
            this.courseGroupBox.Controls.Add(this.courseNameLabel);
            this.courseGroupBox.Controls.Add(this.courseNumberLabel);
            this.courseGroupBox.Controls.Add(this.comboBox1);
            this.courseGroupBox.Location = new System.Drawing.Point(441, 20);
            this.courseGroupBox.Name = "courseGroupBox";
            this.courseGroupBox.Size = new System.Drawing.Size(1000, 648);
            this.courseGroupBox.TabIndex = 2;
            this.courseGroupBox.TabStop = false;
            this.courseGroupBox.Text = "編輯課程";
            // 
            // timeDataGridView
            // 
            this.timeDataGridView.AllowUserToAddRows = false;
            this.timeDataGridView.AllowUserToDeleteRows = false;
            this.timeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.timeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.timeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.classTimeColumn,
            this.sundayColumn,
            this.mondayColumn,
            this.tuesdayColumn,
            this.wednesdayColumn,
            this.thursdayColumn,
            this.fridayColumn,
            this.saturdayColumn});
            this.timeDataGridView.Location = new System.Drawing.Point(37, 345);
            this.timeDataGridView.Name = "timeDataGridView";
            this.timeDataGridView.ReadOnly = true;
            this.timeDataGridView.RowHeadersVisible = false;
            this.timeDataGridView.RowHeadersWidth = 82;
            this.timeDataGridView.RowTemplate.Height = 38;
            this.timeDataGridView.Size = new System.Drawing.Size(933, 278);
            this.timeDataGridView.TabIndex = 23;
            // 
            // classTimeColumn
            // 
            this.classTimeColumn.HeaderText = "節數";
            this.classTimeColumn.MinimumWidth = 10;
            this.classTimeColumn.Name = "classTimeColumn";
            this.classTimeColumn.ReadOnly = true;
            // 
            // sundayColumn
            // 
            this.sundayColumn.HeaderText = "日";
            this.sundayColumn.MinimumWidth = 10;
            this.sundayColumn.Name = "sundayColumn";
            this.sundayColumn.ReadOnly = true;
            // 
            // mondayColumn
            // 
            this.mondayColumn.HeaderText = "一";
            this.mondayColumn.MinimumWidth = 10;
            this.mondayColumn.Name = "mondayColumn";
            this.mondayColumn.ReadOnly = true;
            // 
            // tuesdayColumn
            // 
            this.tuesdayColumn.HeaderText = "二";
            this.tuesdayColumn.MinimumWidth = 10;
            this.tuesdayColumn.Name = "tuesdayColumn";
            this.tuesdayColumn.ReadOnly = true;
            // 
            // wednesdayColumn
            // 
            this.wednesdayColumn.HeaderText = "三";
            this.wednesdayColumn.MinimumWidth = 10;
            this.wednesdayColumn.Name = "wednesdayColumn";
            this.wednesdayColumn.ReadOnly = true;
            // 
            // thursdayColumn
            // 
            this.thursdayColumn.HeaderText = "四";
            this.thursdayColumn.MinimumWidth = 10;
            this.thursdayColumn.Name = "thursdayColumn";
            this.thursdayColumn.ReadOnly = true;
            // 
            // fridayColumn
            // 
            this.fridayColumn.HeaderText = "五";
            this.fridayColumn.MinimumWidth = 10;
            this.fridayColumn.Name = "fridayColumn";
            this.fridayColumn.ReadOnly = true;
            // 
            // saturdayColumn
            // 
            this.saturdayColumn.HeaderText = "六";
            this.saturdayColumn.MinimumWidth = 10;
            this.saturdayColumn.Name = "saturdayColumn";
            this.saturdayColumn.ReadOnly = true;
            // 
            // classComboBox
            // 
            this.classComboBox.FormattingEnabled = true;
            this.classComboBox.Location = new System.Drawing.Point(417, 292);
            this.classComboBox.Name = "classComboBox";
            this.classComboBox.Size = new System.Drawing.Size(121, 32);
            this.classComboBox.TabIndex = 22;
            // 
            // classLabel
            // 
            this.classLabel.AutoSize = true;
            this.classLabel.Location = new System.Drawing.Point(303, 295);
            this.classLabel.Name = "classLabel";
            this.classLabel.Size = new System.Drawing.Size(85, 24);
            this.classLabel.TabIndex = 21;
            this.classLabel.Text = "班級(*)";
            // 
            // hourComboBox
            // 
            this.hourComboBox.FormattingEnabled = true;
            this.hourComboBox.Location = new System.Drawing.Point(142, 292);
            this.hourComboBox.Name = "hourComboBox";
            this.hourComboBox.Size = new System.Drawing.Size(121, 32);
            this.hourComboBox.TabIndex = 20;
            // 
            // hourLabel
            // 
            this.hourLabel.AutoSize = true;
            this.hourLabel.Location = new System.Drawing.Point(33, 295);
            this.hourLabel.Name = "hourLabel";
            this.hourLabel.Size = new System.Drawing.Size(85, 24);
            this.hourLabel.TabIndex = 19;
            this.hourLabel.Text = "時數(*)";
            // 
            // noteTextbox
            // 
            this.noteTextbox.Location = new System.Drawing.Point(118, 227);
            this.noteTextbox.Name = "noteTextbox";
            this.noteTextbox.Size = new System.Drawing.Size(852, 36);
            this.noteTextbox.TabIndex = 18;
            // 
            // noteLabel
            // 
            this.noteLabel.AutoSize = true;
            this.noteLabel.Location = new System.Drawing.Point(33, 233);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(58, 24);
            this.noteLabel.TabIndex = 17;
            this.noteLabel.Text = "備註";
            // 
            // languageTextbox
            // 
            this.languageTextbox.Location = new System.Drawing.Point(654, 165);
            this.languageTextbox.Name = "languageTextbox";
            this.languageTextbox.Size = new System.Drawing.Size(316, 36);
            this.languageTextbox.TabIndex = 16;
            // 
            // languageLabel
            // 
            this.languageLabel.AutoSize = true;
            this.languageLabel.Location = new System.Drawing.Point(516, 171);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(106, 24);
            this.languageLabel.TabIndex = 15;
            this.languageLabel.Text = "授課語言";
            // 
            // teachingAssistantTextbox
            // 
            this.teachingAssistantTextbox.Location = new System.Drawing.Point(171, 165);
            this.teachingAssistantTextbox.Name = "teachingAssistantTextbox";
            this.teachingAssistantTextbox.Size = new System.Drawing.Size(316, 36);
            this.teachingAssistantTextbox.TabIndex = 14;
            // 
            // teachingAssistantLabel
            // 
            this.teachingAssistantLabel.AutoSize = true;
            this.teachingAssistantLabel.Location = new System.Drawing.Point(33, 171);
            this.teachingAssistantLabel.Name = "teachingAssistantLabel";
            this.teachingAssistantLabel.Size = new System.Drawing.Size(106, 24);
            this.teachingAssistantLabel.TabIndex = 13;
            this.teachingAssistantLabel.Text = "教學助理";
            // 
            // courseTypeComboBox
            // 
            this.courseTypeComboBox.FormattingEnabled = true;
            this.courseTypeComboBox.Location = new System.Drawing.Point(849, 105);
            this.courseTypeComboBox.Name = "courseTypeComboBox";
            this.courseTypeComboBox.Size = new System.Drawing.Size(121, 32);
            this.courseTypeComboBox.TabIndex = 12;
            // 
            // courseTypeLabel
            // 
            this.courseTypeLabel.AutoSize = true;
            this.courseTypeLabel.Location = new System.Drawing.Point(759, 108);
            this.courseTypeLabel.Name = "courseTypeLabel";
            this.courseTypeLabel.Size = new System.Drawing.Size(61, 24);
            this.courseTypeLabel.TabIndex = 11;
            this.courseTypeLabel.Text = "修(*)";
            // 
            // teacherTextbox
            // 
            this.teacherTextbox.Location = new System.Drawing.Point(623, 101);
            this.teacherTextbox.Name = "teacherTextbox";
            this.teacherTextbox.Size = new System.Drawing.Size(109, 36);
            this.teacherTextbox.TabIndex = 10;
            // 
            // teacher
            // 
            this.teacher.AutoSize = true;
            this.teacher.Location = new System.Drawing.Point(511, 108);
            this.teacher.Name = "teacher";
            this.teacher.Size = new System.Drawing.Size(85, 24);
            this.teacher.TabIndex = 9;
            this.teacher.Text = "教師(*)";
            // 
            // creditTextbox
            // 
            this.creditTextbox.Location = new System.Drawing.Point(378, 101);
            this.creditTextbox.Name = "creditTextbox";
            this.creditTextbox.Size = new System.Drawing.Size(109, 36);
            this.creditTextbox.TabIndex = 8;
            // 
            // creditLabel
            // 
            this.creditLabel.AutoSize = true;
            this.creditLabel.Location = new System.Drawing.Point(271, 108);
            this.creditLabel.Name = "creditLabel";
            this.creditLabel.Size = new System.Drawing.Size(85, 24);
            this.creditLabel.TabIndex = 7;
            this.creditLabel.Text = "學分(*)";
            // 
            // stageTextbox
            // 
            this.stageTextbox.Location = new System.Drawing.Point(142, 101);
            this.stageTextbox.Name = "stageTextbox";
            this.stageTextbox.Size = new System.Drawing.Size(102, 36);
            this.stageTextbox.TabIndex = 6;
            // 
            // stageLabel
            // 
            this.stageLabel.AutoSize = true;
            this.stageLabel.Location = new System.Drawing.Point(33, 108);
            this.stageLabel.Name = "stageLabel";
            this.stageLabel.Size = new System.Drawing.Size(85, 24);
            this.stageLabel.TabIndex = 5;
            this.stageLabel.Text = "階段(*)";
            // 
            // courseNameTextbox
            // 
            this.courseNameTextbox.Location = new System.Drawing.Point(686, 46);
            this.courseNameTextbox.Name = "courseNameTextbox";
            this.courseNameTextbox.Size = new System.Drawing.Size(284, 36);
            this.courseNameTextbox.TabIndex = 4;
            // 
            // courseNumberTextbox
            // 
            this.courseNumberTextbox.Location = new System.Drawing.Point(327, 46);
            this.courseNumberTextbox.Name = "courseNumberTextbox";
            this.courseNumberTextbox.Size = new System.Drawing.Size(160, 36);
            this.courseNumberTextbox.TabIndex = 3;
            // 
            // courseNameLabel
            // 
            this.courseNameLabel.AutoSize = true;
            this.courseNameLabel.Location = new System.Drawing.Point(521, 53);
            this.courseNameLabel.Name = "courseNameLabel";
            this.courseNameLabel.Size = new System.Drawing.Size(133, 24);
            this.courseNameLabel.TabIndex = 2;
            this.courseNameLabel.Text = "課程名稱(*)";
            // 
            // courseNumberLabel
            // 
            this.courseNumberLabel.AutoSize = true;
            this.courseNumberLabel.Location = new System.Drawing.Point(203, 53);
            this.courseNumberLabel.Name = "courseNumberLabel";
            this.courseNumberLabel.Size = new System.Drawing.Size(85, 24);
            this.courseNumberLabel.TabIndex = 1;
            this.courseNumberLabel.Text = "課號(*)";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(37, 44);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 32);
            this.comboBox1.TabIndex = 0;
            // 
            // addCourseButton
            // 
            this.addCourseButton.Location = new System.Drawing.Point(17, 681);
            this.addCourseButton.Name = "addCourseButton";
            this.addCourseButton.Size = new System.Drawing.Size(401, 95);
            this.addCourseButton.TabIndex = 1;
            this.addCourseButton.Text = "新增課程";
            this.addCourseButton.UseVisualStyleBackColor = true;
            // 
            // courseListBox
            // 
            this.courseListBox.FormattingEnabled = true;
            this.courseListBox.ItemHeight = 24;
            this.courseListBox.Location = new System.Drawing.Point(17, 16);
            this.courseListBox.Name = "courseListBox";
            this.courseListBox.Size = new System.Drawing.Size(400, 652);
            this.courseListBox.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1458, 782);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // CourseManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1474, 829);
            this.Controls.Add(this.courseManageTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CourseManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CourseManagementForm";
            this.courseManageTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.courseGroupBox.ResumeLayout(false);
            this.courseGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl courseManageTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox courseListBox;
        private System.Windows.Forms.Button addCourseButton;
        private System.Windows.Forms.GroupBox courseGroupBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label stageLabel;
        private System.Windows.Forms.TextBox courseNameTextbox;
        private System.Windows.Forms.TextBox courseNumberTextbox;
        private System.Windows.Forms.Label courseNameLabel;
        private System.Windows.Forms.Label courseNumberLabel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox stageTextbox;
        private System.Windows.Forms.TextBox creditTextbox;
        private System.Windows.Forms.Label creditLabel;
        private System.Windows.Forms.Label courseTypeLabel;
        private System.Windows.Forms.TextBox teacherTextbox;
        private System.Windows.Forms.Label teacher;
        private System.Windows.Forms.ComboBox courseTypeComboBox;
        private System.Windows.Forms.TextBox languageTextbox;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.TextBox teachingAssistantTextbox;
        private System.Windows.Forms.Label teachingAssistantLabel;
        private System.Windows.Forms.Label noteLabel;
        private System.Windows.Forms.TextBox noteTextbox;
        private System.Windows.Forms.ComboBox classComboBox;
        private System.Windows.Forms.Label classLabel;
        private System.Windows.Forms.ComboBox hourComboBox;
        private System.Windows.Forms.Label hourLabel;
        private System.Windows.Forms.DataGridView timeDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn classTimeColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn sundayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn mondayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tuesdayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn wednesdayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn thursdayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn fridayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn saturdayColumn;
    }
}