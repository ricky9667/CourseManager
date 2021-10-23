
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
            this._courseManagementTabControl = new System.Windows.Forms.TabControl();
            this._courseManagementTabPage = new System.Windows.Forms.TabPage();
            this._saveButton = new System.Windows.Forms.Button();
            this._courseGroupBox = new System.Windows.Forms.GroupBox();
            this._timeDataGridView = new System.Windows.Forms.DataGridView();
            this.classTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sundayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mondayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tuesdayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.wednesdayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.thursdayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fridayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.saturdayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._classComboBox = new System.Windows.Forms.ComboBox();
            this._classLabel = new System.Windows.Forms.Label();
            this._hourComboBox = new System.Windows.Forms.ComboBox();
            this._hourLabel = new System.Windows.Forms.Label();
            this._noteTextbox = new System.Windows.Forms.TextBox();
            this._noteLabel = new System.Windows.Forms.Label();
            this._languageTextbox = new System.Windows.Forms.TextBox();
            this._languageLabel = new System.Windows.Forms.Label();
            this._teachingAssistantTextbox = new System.Windows.Forms.TextBox();
            this._teachingAssistantLabel = new System.Windows.Forms.Label();
            this._courseTypeComboBox = new System.Windows.Forms.ComboBox();
            this._courseTypeLabel = new System.Windows.Forms.Label();
            this._teacherTextbox = new System.Windows.Forms.TextBox();
            this._teacherLabel = new System.Windows.Forms.Label();
            this._creditTextbox = new System.Windows.Forms.TextBox();
            this._creditLabel = new System.Windows.Forms.Label();
            this._stageTextbox = new System.Windows.Forms.TextBox();
            this._stageLabel = new System.Windows.Forms.Label();
            this._courseNameTextbox = new System.Windows.Forms.TextBox();
            this._courseNumberTextbox = new System.Windows.Forms.TextBox();
            this._courseNameLabel = new System.Windows.Forms.Label();
            this._courseNumberLabel = new System.Windows.Forms.Label();
            this._startCourseSettingsComboBox = new System.Windows.Forms.ComboBox();
            this._addCourseButton = new System.Windows.Forms.Button();
            this._courseListBox = new System.Windows.Forms.ListBox();
            this._classManagementTabPage = new System.Windows.Forms.TabPage();
            this._courseManagementTabControl.SuspendLayout();
            this._courseManagementTabPage.SuspendLayout();
            this._courseGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._timeDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _courseManagementTabControl
            // 
            this._courseManagementTabControl.Controls.Add(this._courseManagementTabPage);
            this._courseManagementTabControl.Controls.Add(this._classManagementTabPage);
            this._courseManagementTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._courseManagementTabControl.Location = new System.Drawing.Point(0, 0);
            this._courseManagementTabControl.Name = "_courseManagementTabControl";
            this._courseManagementTabControl.SelectedIndex = 0;
            this._courseManagementTabControl.Size = new System.Drawing.Size(1474, 829);
            this._courseManagementTabControl.TabIndex = 0;
            // 
            // _courseManagementTabPage
            // 
            this._courseManagementTabPage.Controls.Add(this._saveButton);
            this._courseManagementTabPage.Controls.Add(this._courseGroupBox);
            this._courseManagementTabPage.Controls.Add(this._addCourseButton);
            this._courseManagementTabPage.Controls.Add(this._courseListBox);
            this._courseManagementTabPage.Location = new System.Drawing.Point(8, 39);
            this._courseManagementTabPage.Name = "_courseManagementTabPage";
            this._courseManagementTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._courseManagementTabPage.Size = new System.Drawing.Size(1458, 782);
            this._courseManagementTabPage.TabIndex = 0;
            this._courseManagementTabPage.Text = "課程管理";
            this._courseManagementTabPage.UseVisualStyleBackColor = true;
            // 
            // _saveButton
            // 
            this._saveButton.Enabled = false;
            this._saveButton.Location = new System.Drawing.Point(1119, 681);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(323, 95);
            this._saveButton.TabIndex = 3;
            this._saveButton.Text = "儲存";
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // _courseGroupBox
            // 
            this._courseGroupBox.Controls.Add(this._timeDataGridView);
            this._courseGroupBox.Controls.Add(this._classComboBox);
            this._courseGroupBox.Controls.Add(this._classLabel);
            this._courseGroupBox.Controls.Add(this._hourComboBox);
            this._courseGroupBox.Controls.Add(this._hourLabel);
            this._courseGroupBox.Controls.Add(this._noteTextbox);
            this._courseGroupBox.Controls.Add(this._noteLabel);
            this._courseGroupBox.Controls.Add(this._languageTextbox);
            this._courseGroupBox.Controls.Add(this._languageLabel);
            this._courseGroupBox.Controls.Add(this._teachingAssistantTextbox);
            this._courseGroupBox.Controls.Add(this._teachingAssistantLabel);
            this._courseGroupBox.Controls.Add(this._courseTypeComboBox);
            this._courseGroupBox.Controls.Add(this._courseTypeLabel);
            this._courseGroupBox.Controls.Add(this._teacherTextbox);
            this._courseGroupBox.Controls.Add(this._teacherLabel);
            this._courseGroupBox.Controls.Add(this._creditTextbox);
            this._courseGroupBox.Controls.Add(this._creditLabel);
            this._courseGroupBox.Controls.Add(this._stageTextbox);
            this._courseGroupBox.Controls.Add(this._stageLabel);
            this._courseGroupBox.Controls.Add(this._courseNameTextbox);
            this._courseGroupBox.Controls.Add(this._courseNumberTextbox);
            this._courseGroupBox.Controls.Add(this._courseNameLabel);
            this._courseGroupBox.Controls.Add(this._courseNumberLabel);
            this._courseGroupBox.Controls.Add(this._startCourseSettingsComboBox);
            this._courseGroupBox.Location = new System.Drawing.Point(441, 20);
            this._courseGroupBox.Name = "_courseGroupBox";
            this._courseGroupBox.Size = new System.Drawing.Size(1000, 648);
            this._courseGroupBox.TabIndex = 2;
            this._courseGroupBox.TabStop = false;
            this._courseGroupBox.Text = "編輯課程";
            // 
            // _timeDataGridView
            // 
            this._timeDataGridView.AllowUserToAddRows = false;
            this._timeDataGridView.AllowUserToDeleteRows = false;
            this._timeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._timeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._timeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.classTimeColumn,
            this.sundayColumn,
            this.mondayColumn,
            this.tuesdayColumn,
            this.wednesdayColumn,
            this.thursdayColumn,
            this.fridayColumn,
            this.saturdayColumn});
            this._timeDataGridView.Location = new System.Drawing.Point(37, 345);
            this._timeDataGridView.Name = "_timeDataGridView";
            this._timeDataGridView.ReadOnly = true;
            this._timeDataGridView.RowHeadersVisible = false;
            this._timeDataGridView.RowHeadersWidth = 82;
            this._timeDataGridView.RowTemplate.Height = 38;
            this._timeDataGridView.Size = new System.Drawing.Size(933, 278);
            this._timeDataGridView.TabIndex = 23;
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
            // _classComboBox
            // 
            this._classComboBox.FormattingEnabled = true;
            this._classComboBox.Location = new System.Drawing.Point(417, 292);
            this._classComboBox.Name = "_classComboBox";
            this._classComboBox.Size = new System.Drawing.Size(169, 32);
            this._classComboBox.TabIndex = 22;
            // 
            // _classLabel
            // 
            this._classLabel.AutoSize = true;
            this._classLabel.Location = new System.Drawing.Point(303, 295);
            this._classLabel.Name = "_classLabel";
            this._classLabel.Size = new System.Drawing.Size(85, 24);
            this._classLabel.TabIndex = 21;
            this._classLabel.Text = "班級(*)";
            // 
            // _hourComboBox
            // 
            this._hourComboBox.FormattingEnabled = true;
            this._hourComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this._hourComboBox.Location = new System.Drawing.Point(142, 292);
            this._hourComboBox.Name = "_hourComboBox";
            this._hourComboBox.Size = new System.Drawing.Size(121, 32);
            this._hourComboBox.TabIndex = 20;
            // 
            // _hourLabel
            // 
            this._hourLabel.AutoSize = true;
            this._hourLabel.Location = new System.Drawing.Point(33, 295);
            this._hourLabel.Name = "_hourLabel";
            this._hourLabel.Size = new System.Drawing.Size(85, 24);
            this._hourLabel.TabIndex = 19;
            this._hourLabel.Text = "時數(*)";
            // 
            // _noteTextbox
            // 
            this._noteTextbox.Location = new System.Drawing.Point(118, 227);
            this._noteTextbox.Name = "_noteTextbox";
            this._noteTextbox.Size = new System.Drawing.Size(852, 36);
            this._noteTextbox.TabIndex = 18;
            // 
            // _noteLabel
            // 
            this._noteLabel.AutoSize = true;
            this._noteLabel.Location = new System.Drawing.Point(33, 233);
            this._noteLabel.Name = "_noteLabel";
            this._noteLabel.Size = new System.Drawing.Size(58, 24);
            this._noteLabel.TabIndex = 17;
            this._noteLabel.Text = "備註";
            // 
            // _languageTextbox
            // 
            this._languageTextbox.Location = new System.Drawing.Point(654, 165);
            this._languageTextbox.Name = "_languageTextbox";
            this._languageTextbox.Size = new System.Drawing.Size(316, 36);
            this._languageTextbox.TabIndex = 16;
            // 
            // _languageLabel
            // 
            this._languageLabel.AutoSize = true;
            this._languageLabel.Location = new System.Drawing.Point(516, 171);
            this._languageLabel.Name = "_languageLabel";
            this._languageLabel.Size = new System.Drawing.Size(106, 24);
            this._languageLabel.TabIndex = 15;
            this._languageLabel.Text = "授課語言";
            // 
            // _teachingAssistantTextbox
            // 
            this._teachingAssistantTextbox.Location = new System.Drawing.Point(171, 165);
            this._teachingAssistantTextbox.Name = "_teachingAssistantTextbox";
            this._teachingAssistantTextbox.Size = new System.Drawing.Size(316, 36);
            this._teachingAssistantTextbox.TabIndex = 14;
            // 
            // _teachingAssistantLabel
            // 
            this._teachingAssistantLabel.AutoSize = true;
            this._teachingAssistantLabel.Location = new System.Drawing.Point(33, 171);
            this._teachingAssistantLabel.Name = "_teachingAssistantLabel";
            this._teachingAssistantLabel.Size = new System.Drawing.Size(106, 24);
            this._teachingAssistantLabel.TabIndex = 13;
            this._teachingAssistantLabel.Text = "教學助理";
            // 
            // _courseTypeComboBox
            // 
            this._courseTypeComboBox.FormattingEnabled = true;
            this._courseTypeComboBox.Items.AddRange(new object[] {
            "○",
            "△",
            "☆",
            "●",
            "▲",
            "★"});
            this._courseTypeComboBox.Location = new System.Drawing.Point(849, 105);
            this._courseTypeComboBox.Name = "_courseTypeComboBox";
            this._courseTypeComboBox.Size = new System.Drawing.Size(121, 32);
            this._courseTypeComboBox.TabIndex = 12;
            // 
            // _courseTypeLabel
            // 
            this._courseTypeLabel.AutoSize = true;
            this._courseTypeLabel.Location = new System.Drawing.Point(759, 108);
            this._courseTypeLabel.Name = "_courseTypeLabel";
            this._courseTypeLabel.Size = new System.Drawing.Size(61, 24);
            this._courseTypeLabel.TabIndex = 11;
            this._courseTypeLabel.Text = "修(*)";
            // 
            // _teacherTextbox
            // 
            this._teacherTextbox.Location = new System.Drawing.Point(623, 101);
            this._teacherTextbox.Name = "_teacherTextbox";
            this._teacherTextbox.Size = new System.Drawing.Size(109, 36);
            this._teacherTextbox.TabIndex = 10;
            this._teacherTextbox.TextChanged += new System.EventHandler(this.TextBoxDataChanged);
            // 
            // _teacherLabel
            // 
            this._teacherLabel.AutoSize = true;
            this._teacherLabel.Location = new System.Drawing.Point(511, 108);
            this._teacherLabel.Name = "_teacherLabel";
            this._teacherLabel.Size = new System.Drawing.Size(85, 24);
            this._teacherLabel.TabIndex = 9;
            this._teacherLabel.Text = "教師(*)";
            // 
            // _creditTextbox
            // 
            this._creditTextbox.Location = new System.Drawing.Point(378, 101);
            this._creditTextbox.Name = "_creditTextbox";
            this._creditTextbox.Size = new System.Drawing.Size(109, 36);
            this._creditTextbox.TabIndex = 8;
            this._creditTextbox.TextChanged += new System.EventHandler(this.TextBoxDataChanged);
            // 
            // _creditLabel
            // 
            this._creditLabel.AutoSize = true;
            this._creditLabel.Location = new System.Drawing.Point(271, 108);
            this._creditLabel.Name = "_creditLabel";
            this._creditLabel.Size = new System.Drawing.Size(85, 24);
            this._creditLabel.TabIndex = 7;
            this._creditLabel.Text = "學分(*)";
            // 
            // _stageTextbox
            // 
            this._stageTextbox.Location = new System.Drawing.Point(142, 101);
            this._stageTextbox.Name = "_stageTextbox";
            this._stageTextbox.Size = new System.Drawing.Size(102, 36);
            this._stageTextbox.TabIndex = 6;
            this._stageTextbox.TextChanged += new System.EventHandler(this.TextBoxDataChanged);
            // 
            // _stageLabel
            // 
            this._stageLabel.AutoSize = true;
            this._stageLabel.Location = new System.Drawing.Point(33, 108);
            this._stageLabel.Name = "_stageLabel";
            this._stageLabel.Size = new System.Drawing.Size(85, 24);
            this._stageLabel.TabIndex = 5;
            this._stageLabel.Text = "階段(*)";
            // 
            // _courseNameTextbox
            // 
            this._courseNameTextbox.Location = new System.Drawing.Point(686, 46);
            this._courseNameTextbox.Name = "_courseNameTextbox";
            this._courseNameTextbox.Size = new System.Drawing.Size(284, 36);
            this._courseNameTextbox.TabIndex = 4;
            this._courseNameTextbox.TextChanged += new System.EventHandler(this.TextBoxDataChanged);
            // 
            // _courseNumberTextbox
            // 
            this._courseNumberTextbox.Location = new System.Drawing.Point(327, 46);
            this._courseNumberTextbox.Name = "_courseNumberTextbox";
            this._courseNumberTextbox.Size = new System.Drawing.Size(160, 36);
            this._courseNumberTextbox.TabIndex = 3;
            this._courseNumberTextbox.TextChanged += new System.EventHandler(this.TextBoxDataChanged);
            // 
            // _courseNameLabel
            // 
            this._courseNameLabel.AutoSize = true;
            this._courseNameLabel.Location = new System.Drawing.Point(521, 53);
            this._courseNameLabel.Name = "_courseNameLabel";
            this._courseNameLabel.Size = new System.Drawing.Size(133, 24);
            this._courseNameLabel.TabIndex = 2;
            this._courseNameLabel.Text = "課程名稱(*)";
            // 
            // _courseNumberLabel
            // 
            this._courseNumberLabel.AutoSize = true;
            this._courseNumberLabel.Location = new System.Drawing.Point(203, 53);
            this._courseNumberLabel.Name = "_courseNumberLabel";
            this._courseNumberLabel.Size = new System.Drawing.Size(85, 24);
            this._courseNumberLabel.TabIndex = 1;
            this._courseNumberLabel.Text = "課號(*)";
            // 
            // _startCourseSettingsComboBox
            // 
            this._startCourseSettingsComboBox.FormattingEnabled = true;
            this._startCourseSettingsComboBox.Items.AddRange(new object[] {
            "開課",
            "停開"});
            this._startCourseSettingsComboBox.Location = new System.Drawing.Point(37, 44);
            this._startCourseSettingsComboBox.Name = "_startCourseSettingsComboBox";
            this._startCourseSettingsComboBox.Size = new System.Drawing.Size(121, 32);
            this._startCourseSettingsComboBox.TabIndex = 0;
            // 
            // _addCourseButton
            // 
            this._addCourseButton.Location = new System.Drawing.Point(17, 681);
            this._addCourseButton.Name = "_addCourseButton";
            this._addCourseButton.Size = new System.Drawing.Size(401, 95);
            this._addCourseButton.TabIndex = 1;
            this._addCourseButton.Text = "新增課程";
            this._addCourseButton.UseVisualStyleBackColor = true;
            // 
            // _courseListBox
            // 
            this._courseListBox.FormattingEnabled = true;
            this._courseListBox.ItemHeight = 24;
            this._courseListBox.Location = new System.Drawing.Point(17, 16);
            this._courseListBox.Name = "_courseListBox";
            this._courseListBox.Size = new System.Drawing.Size(400, 652);
            this._courseListBox.TabIndex = 0;
            this._courseListBox.SelectedIndexChanged += new System.EventHandler(this.CourseListBoxSelectedIndexChanged);
            // 
            // _classManagementTabPage
            // 
            this._classManagementTabPage.Location = new System.Drawing.Point(8, 39);
            this._classManagementTabPage.Name = "_classManagementTabPage";
            this._classManagementTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._classManagementTabPage.Size = new System.Drawing.Size(1458, 782);
            this._classManagementTabPage.TabIndex = 1;
            this._classManagementTabPage.Text = "班級管理";
            this._classManagementTabPage.UseVisualStyleBackColor = true;
            // 
            // CourseManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1474, 829);
            this.Controls.Add(this._courseManagementTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CourseManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CourseManagementForm";
            this.Load += new System.EventHandler(this.CourseManagementFormLoad);
            this._courseManagementTabControl.ResumeLayout(false);
            this._courseManagementTabPage.ResumeLayout(false);
            this._courseGroupBox.ResumeLayout(false);
            this._courseGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._timeDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox _startCourseSettingsComboBox;
        private System.Windows.Forms.Label _courseNumberLabel;
        private System.Windows.Forms.TextBox _courseNameTextbox;
        private System.Windows.Forms.Label _courseNameLabel;
        private System.Windows.Forms.TextBox _courseNumberTextbox;
        private System.Windows.Forms.Label _stageLabel;
        private System.Windows.Forms.TextBox _stageTextbox;
        private System.Windows.Forms.Label _creditLabel;
        private System.Windows.Forms.TextBox _creditTextbox;
        private System.Windows.Forms.Label _teacherLabel;
        private System.Windows.Forms.TextBox _teacherTextbox;
        private System.Windows.Forms.Label _courseTypeLabel;
        private System.Windows.Forms.ComboBox _courseTypeComboBox;
        private System.Windows.Forms.Label _teachingAssistantLabel;
        private System.Windows.Forms.TextBox _teachingAssistantTextbox;
        private System.Windows.Forms.Label _languageLabel;
        private System.Windows.Forms.TextBox _languageTextbox;
        private System.Windows.Forms.Label _noteLabel;
        private System.Windows.Forms.TextBox _noteTextbox;
        private System.Windows.Forms.Label _hourLabel;
        private System.Windows.Forms.ComboBox _hourComboBox;
        private System.Windows.Forms.Label _classLabel;
        private System.Windows.Forms.ComboBox _classComboBox;
        private System.Windows.Forms.Button _addCourseButton;
        private System.Windows.Forms.Button _saveButton;
        private System.Windows.Forms.ListBox _courseListBox;
        private System.Windows.Forms.GroupBox _courseGroupBox;
        private System.Windows.Forms.DataGridView _timeDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn _classTimeColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _sundayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _mondayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _tuesdayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _wednesdayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _thursdayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _fridayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _saturdayColumn;
        private System.Windows.Forms.TabPage _courseManagementTabPage;
        private System.Windows.Forms.TabPage _classManagementTabPage;
        private System.Windows.Forms.TabControl _courseManagementTabControl;
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