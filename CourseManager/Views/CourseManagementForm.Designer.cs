
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
            this._importComputerScienceCoursesButton = new System.Windows.Forms.Button();
            this._saveButton = new System.Windows.Forms.Button();
            this._courseGroupBox = new System.Windows.Forms.GroupBox();
            this._timeDataGridView = new System.Windows.Forms.DataGridView();
            this._classTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._sundayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._mondayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._tuesdayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._wednesdayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._thursdayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._fridayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._saturdayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._classComboBox = new System.Windows.Forms.ComboBox();
            this._classLabel = new System.Windows.Forms.Label();
            this._hourComboBox = new System.Windows.Forms.ComboBox();
            this._hourLabel = new System.Windows.Forms.Label();
            this._noteTextBox = new System.Windows.Forms.TextBox();
            this._noteLabel = new System.Windows.Forms.Label();
            this._languageTextBox = new System.Windows.Forms.TextBox();
            this._languageLabel = new System.Windows.Forms.Label();
            this._teachingAssistantTextBox = new System.Windows.Forms.TextBox();
            this._teachingAssistantLabel = new System.Windows.Forms.Label();
            this._courseTypeComboBox = new System.Windows.Forms.ComboBox();
            this._courseTypeLabel = new System.Windows.Forms.Label();
            this._teacherTextBox = new System.Windows.Forms.TextBox();
            this._teacherLabel = new System.Windows.Forms.Label();
            this._creditTextBox = new System.Windows.Forms.TextBox();
            this._creditLabel = new System.Windows.Forms.Label();
            this._stageTextBox = new System.Windows.Forms.TextBox();
            this._stageLabel = new System.Windows.Forms.Label();
            this._courseNameTextBox = new System.Windows.Forms.TextBox();
            this._courseNumberTextBox = new System.Windows.Forms.TextBox();
            this._courseNameLabel = new System.Windows.Forms.Label();
            this._courseNumberLabel = new System.Windows.Forms.Label();
            this._openCourseSettingsComboBox = new System.Windows.Forms.ComboBox();
            this._addCourseButton = new System.Windows.Forms.Button();
            this._courseListBox = new System.Windows.Forms.ListBox();
            this._classManagementTabPage = new System.Windows.Forms.TabPage();
            this._addButton = new System.Windows.Forms.Button();
            this._classGroupBox = new System.Windows.Forms.GroupBox();
            this._classCoursesListBox = new System.Windows.Forms.ListBox();
            this._classCoursesLabel = new System.Windows.Forms.Label();
            this._classNameTextBox = new System.Windows.Forms.TextBox();
            this._classNameLabel = new System.Windows.Forms.Label();
            this._addClassButton = new System.Windows.Forms.Button();
            this._classListBox = new System.Windows.Forms.ListBox();
            this._courseManagementTabControl.SuspendLayout();
            this._courseManagementTabPage.SuspendLayout();
            this._courseGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._timeDataGridView)).BeginInit();
            this._classManagementTabPage.SuspendLayout();
            this._classGroupBox.SuspendLayout();
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
            this._courseManagementTabControl.Size = new System.Drawing.Size(1774, 929);
            this._courseManagementTabControl.TabIndex = 0;
            // 
            // _courseManagementTabPage
            // 
            this._courseManagementTabPage.Controls.Add(this._importComputerScienceCoursesButton);
            this._courseManagementTabPage.Controls.Add(this._saveButton);
            this._courseManagementTabPage.Controls.Add(this._courseGroupBox);
            this._courseManagementTabPage.Controls.Add(this._addCourseButton);
            this._courseManagementTabPage.Controls.Add(this._courseListBox);
            this._courseManagementTabPage.Location = new System.Drawing.Point(8, 39);
            this._courseManagementTabPage.Name = "_courseManagementTabPage";
            this._courseManagementTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._courseManagementTabPage.Size = new System.Drawing.Size(1758, 882);
            this._courseManagementTabPage.TabIndex = 0;
            this._courseManagementTabPage.Text = "課程管理";
            this._courseManagementTabPage.UseVisualStyleBackColor = true;
            // 
            // _importComputerScienceCoursesButton
            // 
            this._importComputerScienceCoursesButton.Location = new System.Drawing.Point(239, 784);
            this._importComputerScienceCoursesButton.Name = "_importComputerScienceCoursesButton";
            this._importComputerScienceCoursesButton.Size = new System.Drawing.Size(244, 71);
            this._importComputerScienceCoursesButton.TabIndex = 4;
            this._importComputerScienceCoursesButton.Text = "匯入資工系全部課程";
            this._importComputerScienceCoursesButton.UseVisualStyleBackColor = true;
            this._importComputerScienceCoursesButton.Click += new System.EventHandler(this.ImportComputerScienceCoursesButtonClick);
            // 
            // _saveButton
            // 
            this._saveButton.Enabled = false;
            this._saveButton.Location = new System.Drawing.Point(1519, 784);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(206, 71);
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
            this._courseGroupBox.Controls.Add(this._noteTextBox);
            this._courseGroupBox.Controls.Add(this._noteLabel);
            this._courseGroupBox.Controls.Add(this._languageTextBox);
            this._courseGroupBox.Controls.Add(this._languageLabel);
            this._courseGroupBox.Controls.Add(this._teachingAssistantTextBox);
            this._courseGroupBox.Controls.Add(this._teachingAssistantLabel);
            this._courseGroupBox.Controls.Add(this._courseTypeComboBox);
            this._courseGroupBox.Controls.Add(this._courseTypeLabel);
            this._courseGroupBox.Controls.Add(this._teacherTextBox);
            this._courseGroupBox.Controls.Add(this._teacherLabel);
            this._courseGroupBox.Controls.Add(this._creditTextBox);
            this._courseGroupBox.Controls.Add(this._creditLabel);
            this._courseGroupBox.Controls.Add(this._stageTextBox);
            this._courseGroupBox.Controls.Add(this._stageLabel);
            this._courseGroupBox.Controls.Add(this._courseNameTextBox);
            this._courseGroupBox.Controls.Add(this._courseNumberTextBox);
            this._courseGroupBox.Controls.Add(this._courseNameLabel);
            this._courseGroupBox.Controls.Add(this._courseNumberLabel);
            this._courseGroupBox.Controls.Add(this._openCourseSettingsComboBox);
            this._courseGroupBox.Location = new System.Drawing.Point(441, 20);
            this._courseGroupBox.Name = "_courseGroupBox";
            this._courseGroupBox.Size = new System.Drawing.Size(1311, 744);
            this._courseGroupBox.TabIndex = 2;
            this._courseGroupBox.TabStop = false;
            this._courseGroupBox.Text = "編輯課程";
            // 
            // _timeDataGridView
            // 
            this._timeDataGridView.AllowUserToAddRows = false;
            this._timeDataGridView.AllowUserToDeleteRows = false;
            this._timeDataGridView.AllowUserToResizeColumns = false;
            this._timeDataGridView.AllowUserToResizeRows = false;
            this._timeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._timeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._timeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._classTimeColumn,
            this._sundayColumn,
            this._mondayColumn,
            this._tuesdayColumn,
            this._wednesdayColumn,
            this._thursdayColumn,
            this._fridayColumn,
            this._saturdayColumn});
            this._timeDataGridView.Location = new System.Drawing.Point(37, 360);
            this._timeDataGridView.Name = "_timeDataGridView";
            this._timeDataGridView.ReadOnly = true;
            this._timeDataGridView.RowHeadersVisible = false;
            this._timeDataGridView.RowHeadersWidth = 82;
            this._timeDataGridView.RowTemplate.Height = 38;
            this._timeDataGridView.Size = new System.Drawing.Size(1247, 360);
            this._timeDataGridView.TabIndex = 23;
            this._timeDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TimeDataGridViewCellClicked);
            // 
            // _classTimeColumn
            // 
            this._classTimeColumn.HeaderText = "節數";
            this._classTimeColumn.MinimumWidth = 10;
            this._classTimeColumn.Name = "_classTimeColumn";
            this._classTimeColumn.ReadOnly = true;
            // 
            // sundayColumn
            // 
            this._sundayColumn.HeaderText = "日";
            this._sundayColumn.MinimumWidth = 10;
            this._sundayColumn.Name = "sundayColumn";
            this._sundayColumn.ReadOnly = true;
            // 
            // mondayColumn
            // 
            this._mondayColumn.HeaderText = "一";
            this._mondayColumn.MinimumWidth = 10;
            this._mondayColumn.Name = "mondayColumn";
            this._mondayColumn.ReadOnly = true;
            // 
            // tuesdayColumn
            // 
            this._tuesdayColumn.HeaderText = "二";
            this._tuesdayColumn.MinimumWidth = 10;
            this._tuesdayColumn.Name = "tuesdayColumn";
            this._tuesdayColumn.ReadOnly = true;
            // 
            // wednesdayColumn
            // 
            this._wednesdayColumn.HeaderText = "三";
            this._wednesdayColumn.MinimumWidth = 10;
            this._wednesdayColumn.Name = "wednesdayColumn";
            this._wednesdayColumn.ReadOnly = true;
            // 
            // thursdayColumn
            // 
            this._thursdayColumn.HeaderText = "四";
            this._thursdayColumn.MinimumWidth = 10;
            this._thursdayColumn.Name = "thursdayColumn";
            this._thursdayColumn.ReadOnly = true;
            // 
            // fridayColumn
            // 
            this._fridayColumn.HeaderText = "五";
            this._fridayColumn.MinimumWidth = 10;
            this._fridayColumn.Name = "fridayColumn";
            this._fridayColumn.ReadOnly = true;
            // 
            // saturdayColumn
            // 
            this._saturdayColumn.HeaderText = "六";
            this._saturdayColumn.MinimumWidth = 10;
            this._saturdayColumn.Name = "saturdayColumn";
            this._saturdayColumn.ReadOnly = true;
            // 
            // _classComboBox
            // 
            this._classComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._classComboBox.FormattingEnabled = true;
            this._classComboBox.Location = new System.Drawing.Point(471, 292);
            this._classComboBox.Name = "_classComboBox";
            this._classComboBox.Size = new System.Drawing.Size(169, 32);
            this._classComboBox.TabIndex = 22;
            this._classComboBox.SelectedIndexChanged += new System.EventHandler(this.CourseInfoDataChanged);
            // 
            // _classLabel
            // 
            this._classLabel.AutoSize = true;
            this._classLabel.Location = new System.Drawing.Point(347, 295);
            this._classLabel.Name = "_classLabel";
            this._classLabel.Size = new System.Drawing.Size(85, 24);
            this._classLabel.TabIndex = 21;
            this._classLabel.Text = "班級(*)";
            // 
            // _hourComboBox
            // 
            this._hourComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._hourComboBox.FormattingEnabled = true;
            this._hourComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this._hourComboBox.Location = new System.Drawing.Point(142, 292);
            this._hourComboBox.Name = "_hourComboBox";
            this._hourComboBox.Size = new System.Drawing.Size(169, 32);
            this._hourComboBox.TabIndex = 20;
            this._hourComboBox.SelectedIndexChanged += new System.EventHandler(this.CourseInfoDataChanged);
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
            // _noteTextBox
            // 
            this._noteTextBox.Location = new System.Drawing.Point(118, 227);
            this._noteTextBox.Name = "_noteTextBox";
            this._noteTextBox.Size = new System.Drawing.Size(926, 36);
            this._noteTextBox.TabIndex = 18;
            this._noteTextBox.TextChanged += new System.EventHandler(this.CourseInfoDataChanged);
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
            // _languageTextBox
            // 
            this._languageTextBox.Location = new System.Drawing.Point(826, 168);
            this._languageTextBox.Name = "_languageTextBox";
            this._languageTextBox.Size = new System.Drawing.Size(458, 36);
            this._languageTextBox.TabIndex = 16;
            this._languageTextBox.TextChanged += new System.EventHandler(this.CourseInfoDataChanged);
            // 
            // _languageLabel
            // 
            this._languageLabel.AutoSize = true;
            this._languageLabel.Location = new System.Drawing.Point(672, 171);
            this._languageLabel.Name = "_languageLabel";
            this._languageLabel.Size = new System.Drawing.Size(106, 24);
            this._languageLabel.TabIndex = 15;
            this._languageLabel.Text = "授課語言";
            // 
            // _teachingAssistantTextBox
            // 
            this._teachingAssistantTextBox.Location = new System.Drawing.Point(171, 165);
            this._teachingAssistantTextBox.Name = "_teachingAssistantTextBox";
            this._teachingAssistantTextBox.Size = new System.Drawing.Size(450, 36);
            this._teachingAssistantTextBox.TabIndex = 14;
            this._teachingAssistantTextBox.TextChanged += new System.EventHandler(this.CourseInfoDataChanged);
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
            this._courseTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._courseTypeComboBox.FormattingEnabled = true;
            this._courseTypeComboBox.Items.AddRange(new object[] {
            "○",
            "△",
            "☆",
            "●",
            "▲",
            "★"});
            this._courseTypeComboBox.Location = new System.Drawing.Point(1105, 105);
            this._courseTypeComboBox.Name = "_courseTypeComboBox";
            this._courseTypeComboBox.Size = new System.Drawing.Size(179, 32);
            this._courseTypeComboBox.TabIndex = 12;
            // 
            // _courseTypeLabel
            // 
            this._courseTypeLabel.AutoSize = true;
            this._courseTypeLabel.Location = new System.Drawing.Point(994, 108);
            this._courseTypeLabel.Name = "_courseTypeLabel";
            this._courseTypeLabel.Size = new System.Drawing.Size(61, 24);
            this._courseTypeLabel.TabIndex = 11;
            this._courseTypeLabel.Text = "修(*)";
            // 
            // _teacherTextBox
            // 
            this._teacherTextBox.Location = new System.Drawing.Point(765, 101);
            this._teacherTextBox.Name = "_teacherTextBox";
            this._teacherTextBox.Size = new System.Drawing.Size(205, 36);
            this._teacherTextBox.TabIndex = 10;
            this._teacherTextBox.TextChanged += new System.EventHandler(this.CourseInfoDataChanged);
            // 
            // _teacherLabel
            // 
            this._teacherLabel.AutoSize = true;
            this._teacherLabel.Location = new System.Drawing.Point(631, 104);
            this._teacherLabel.Name = "_teacherLabel";
            this._teacherLabel.Size = new System.Drawing.Size(85, 24);
            this._teacherLabel.TabIndex = 9;
            this._teacherLabel.Text = "教師(*)";
            // 
            // _creditTextBox
            // 
            this._creditTextBox.Location = new System.Drawing.Point(417, 101);
            this._creditTextBox.Name = "_creditTextBox";
            this._creditTextBox.Size = new System.Drawing.Size(173, 36);
            this._creditTextBox.TabIndex = 8;
            this._creditTextBox.TextChanged += new System.EventHandler(this.CourseInfoDataChanged);
            // 
            // _creditLabel
            // 
            this._creditLabel.AutoSize = true;
            this._creditLabel.Location = new System.Drawing.Point(303, 108);
            this._creditLabel.Name = "_creditLabel";
            this._creditLabel.Size = new System.Drawing.Size(85, 24);
            this._creditLabel.TabIndex = 7;
            this._creditLabel.Text = "學分(*)";
            // 
            // _stageTextBox
            // 
            this._stageTextBox.Location = new System.Drawing.Point(142, 101);
            this._stageTextBox.Name = "_stageTextBox";
            this._stageTextBox.Size = new System.Drawing.Size(134, 36);
            this._stageTextBox.TabIndex = 6;
            this._stageTextBox.TextChanged += new System.EventHandler(this.CourseInfoDataChanged);
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
            // _courseNameTextBox
            // 
            this._courseNameTextBox.Location = new System.Drawing.Point(914, 40);
            this._courseNameTextBox.Name = "_courseNameTextBox";
            this._courseNameTextBox.Size = new System.Drawing.Size(370, 36);
            this._courseNameTextBox.TabIndex = 4;
            this._courseNameTextBox.TextChanged += new System.EventHandler(this.CourseInfoDataChanged);
            // 
            // _courseNumberTextBox
            // 
            this._courseNumberTextBox.Location = new System.Drawing.Point(417, 41);
            this._courseNumberTextBox.Name = "_courseNumberTextBox";
            this._courseNumberTextBox.Size = new System.Drawing.Size(280, 36);
            this._courseNumberTextBox.TabIndex = 3;
            this._courseNumberTextBox.TextChanged += new System.EventHandler(this.CourseInfoDataChanged);
            // 
            // _courseNameLabel
            // 
            this._courseNameLabel.AutoSize = true;
            this._courseNameLabel.Location = new System.Drawing.Point(743, 47);
            this._courseNameLabel.Name = "_courseNameLabel";
            this._courseNameLabel.Size = new System.Drawing.Size(133, 24);
            this._courseNameLabel.TabIndex = 2;
            this._courseNameLabel.Text = "課程名稱(*)";
            // 
            // _courseNumberLabel
            // 
            this._courseNumberLabel.AutoSize = true;
            this._courseNumberLabel.Location = new System.Drawing.Point(291, 47);
            this._courseNumberLabel.Name = "_courseNumberLabel";
            this._courseNumberLabel.Size = new System.Drawing.Size(85, 24);
            this._courseNumberLabel.TabIndex = 1;
            this._courseNumberLabel.Text = "課號(*)";
            // 
            // _openCourseSettingsComboBox
            // 
            this._openCourseSettingsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._openCourseSettingsComboBox.FormattingEnabled = true;
            this._openCourseSettingsComboBox.Items.AddRange(new object[] {
            "開課",
            "停開"});
            this._openCourseSettingsComboBox.Location = new System.Drawing.Point(37, 44);
            this._openCourseSettingsComboBox.Name = "_openCourseSettingsComboBox";
            this._openCourseSettingsComboBox.Size = new System.Drawing.Size(207, 32);
            this._openCourseSettingsComboBox.TabIndex = 0;
            this._openCourseSettingsComboBox.SelectedIndexChanged += new System.EventHandler(this.CourseInfoDataChanged);
            // 
            // _addCourseButton
            // 
            this._addCourseButton.Location = new System.Drawing.Point(17, 784);
            this._addCourseButton.Name = "_addCourseButton";
            this._addCourseButton.Size = new System.Drawing.Size(201, 71);
            this._addCourseButton.TabIndex = 1;
            this._addCourseButton.Text = "新增課程";
            this._addCourseButton.UseVisualStyleBackColor = true;
            this._addCourseButton.Click += new System.EventHandler(this.AddCourseButtonClick);
            // 
            // _courseListBox
            // 
            this._courseListBox.FormattingEnabled = true;
            this._courseListBox.ItemHeight = 24;
            this._courseListBox.Location = new System.Drawing.Point(17, 16);
            this._courseListBox.Name = "_courseListBox";
            this._courseListBox.Size = new System.Drawing.Size(400, 724);
            this._courseListBox.TabIndex = 0;
            this._courseListBox.SelectedIndexChanged += new System.EventHandler(this.CourseListBoxSelectedIndexChanged);
            // 
            // _classManagementTabPage
            // 
            this._classManagementTabPage.Controls.Add(this._addButton);
            this._classManagementTabPage.Controls.Add(this._classGroupBox);
            this._classManagementTabPage.Controls.Add(this._addClassButton);
            this._classManagementTabPage.Controls.Add(this._classListBox);
            this._classManagementTabPage.Location = new System.Drawing.Point(8, 39);
            this._classManagementTabPage.Name = "_classManagementTabPage";
            this._classManagementTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._classManagementTabPage.Size = new System.Drawing.Size(1758, 882);
            this._classManagementTabPage.TabIndex = 1;
            this._classManagementTabPage.Text = "班級管理";
            this._classManagementTabPage.UseVisualStyleBackColor = true;
            // 
            // _addButton
            // 
            this._addButton.Enabled = false;
            this._addButton.Location = new System.Drawing.Point(1414, 748);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(328, 110);
            this._addButton.TabIndex = 3;
            this._addButton.Text = "新增";
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this.AddButtonClick);
            // 
            // _classGroupBox
            // 
            this._classGroupBox.Controls.Add(this._classCoursesListBox);
            this._classGroupBox.Controls.Add(this._classCoursesLabel);
            this._classGroupBox.Controls.Add(this._classNameTextBox);
            this._classGroupBox.Controls.Add(this._classNameLabel);
            this._classGroupBox.Location = new System.Drawing.Point(481, 7);
            this._classGroupBox.Name = "_classGroupBox";
            this._classGroupBox.Size = new System.Drawing.Size(1261, 723);
            this._classGroupBox.TabIndex = 2;
            this._classGroupBox.TabStop = false;
            this._classGroupBox.Text = "班級";
            // 
            // _classCoursesListBox
            // 
            this._classCoursesListBox.FormattingEnabled = true;
            this._classCoursesListBox.ItemHeight = 24;
            this._classCoursesListBox.Location = new System.Drawing.Point(22, 226);
            this._classCoursesListBox.Name = "_classCoursesListBox";
            this._classCoursesListBox.Size = new System.Drawing.Size(1208, 460);
            this._classCoursesListBox.TabIndex = 4;
            // 
            // _classCoursesLabel
            // 
            this._classCoursesLabel.AutoSize = true;
            this._classCoursesLabel.Location = new System.Drawing.Point(31, 184);
            this._classCoursesLabel.Name = "_classCoursesLabel";
            this._classCoursesLabel.Size = new System.Drawing.Size(130, 24);
            this._classCoursesLabel.TabIndex = 2;
            this._classCoursesLabel.Text = "班級內課程";
            // 
            // _classNameTextBox
            // 
            this._classNameTextBox.Enabled = false;
            this._classNameTextBox.Location = new System.Drawing.Point(184, 75);
            this._classNameTextBox.Name = "_classNameTextBox";
            this._classNameTextBox.Size = new System.Drawing.Size(1046, 36);
            this._classNameTextBox.TabIndex = 1;
            this._classNameTextBox.TextChanged += new System.EventHandler(this.ClassNameTextBoxTextChanged);
            // 
            // _classNameLabel
            // 
            this._classNameLabel.AutoSize = true;
            this._classNameLabel.Location = new System.Drawing.Point(36, 81);
            this._classNameLabel.Name = "_classNameLabel";
            this._classNameLabel.Size = new System.Drawing.Size(133, 24);
            this._classNameLabel.TabIndex = 0;
            this._classNameLabel.Text = "班級名稱(*)";
            // 
            // _addClassButton
            // 
            this._addClassButton.Location = new System.Drawing.Point(19, 748);
            this._addClassButton.Name = "_addClassButton";
            this._addClassButton.Size = new System.Drawing.Size(442, 110);
            this._addClassButton.TabIndex = 1;
            this._addClassButton.Text = "新增課程";
            this._addClassButton.UseVisualStyleBackColor = true;
            this._addClassButton.Click += new System.EventHandler(this.AddClassButtonClick);
            // 
            // _classListBox
            // 
            this._classListBox.FormattingEnabled = true;
            this._classListBox.ItemHeight = 24;
            this._classListBox.Location = new System.Drawing.Point(19, 6);
            this._classListBox.Name = "_classListBox";
            this._classListBox.Size = new System.Drawing.Size(442, 724);
            this._classListBox.TabIndex = 0;
            this._classListBox.SelectedIndexChanged += new System.EventHandler(this.ClassListBoxSelectedIndexChanged);
            // 
            // CourseManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1774, 929);
            this.Controls.Add(this._courseManagementTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CourseManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "課程管理";
            this.Load += new System.EventHandler(this.CourseManagementFormLoad);
            this._courseManagementTabControl.ResumeLayout(false);
            this._courseManagementTabPage.ResumeLayout(false);
            this._courseGroupBox.ResumeLayout(false);
            this._courseGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._timeDataGridView)).EndInit();
            this._classManagementTabPage.ResumeLayout(false);
            this._classGroupBox.ResumeLayout(false);
            this._classGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox _openCourseSettingsComboBox;
        private System.Windows.Forms.Label _courseNumberLabel;
        private System.Windows.Forms.TextBox _courseNameTextBox;
        private System.Windows.Forms.Label _courseNameLabel;
        private System.Windows.Forms.TextBox _courseNumberTextBox;
        private System.Windows.Forms.Label _stageLabel;
        private System.Windows.Forms.TextBox _stageTextBox;
        private System.Windows.Forms.Label _creditLabel;
        private System.Windows.Forms.TextBox _creditTextBox;
        private System.Windows.Forms.Label _teacherLabel;
        private System.Windows.Forms.TextBox _teacherTextBox;
        private System.Windows.Forms.Label _courseTypeLabel;
        private System.Windows.Forms.ComboBox _courseTypeComboBox;
        private System.Windows.Forms.Label _teachingAssistantLabel;
        private System.Windows.Forms.TextBox _teachingAssistantTextBox;
        private System.Windows.Forms.Label _languageLabel;
        private System.Windows.Forms.TextBox _languageTextBox;
        private System.Windows.Forms.Label _noteLabel;
        private System.Windows.Forms.TextBox _noteTextBox;
        private System.Windows.Forms.Label _hourLabel;
        private System.Windows.Forms.ComboBox _hourComboBox;
        private System.Windows.Forms.Label _classLabel;
        private System.Windows.Forms.ComboBox _classComboBox;
        private System.Windows.Forms.Button _addCourseButton;
        private System.Windows.Forms.Button _saveButton;
        private System.Windows.Forms.ListBox _courseListBox;
        private System.Windows.Forms.GroupBox _courseGroupBox;
        private System.Windows.Forms.DataGridView _timeDataGridView;
        private System.Windows.Forms.TabPage _courseManagementTabPage;
        private System.Windows.Forms.TabPage _classManagementTabPage;
        private System.Windows.Forms.TabControl _courseManagementTabControl;
        private System.Windows.Forms.DataGridViewTextBoxColumn _classTimeColumn;
        private System.Windows.Forms.Button _importComputerScienceCoursesButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _sundayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _mondayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _tuesdayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _wednesdayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _thursdayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _fridayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _saturdayColumn;
        private System.Windows.Forms.ListBox _classListBox;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.GroupBox _classGroupBox;
        private System.Windows.Forms.ListBox _classCoursesListBox;
        private System.Windows.Forms.Label _classCoursesLabel;
        private System.Windows.Forms.TextBox _classNameTextBox;
        private System.Windows.Forms.Label _classNameLabel;
        private System.Windows.Forms.Button _addClassButton;
    }
}