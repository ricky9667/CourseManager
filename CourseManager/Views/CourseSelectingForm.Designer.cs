
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
            this._courseSelectionResultButton = new System.Windows.Forms.Button();
            this._submitButton = new System.Windows.Forms.Button();
            this._courseTabControl = new System.Windows.Forms.TabControl();
            this._tabPage1 = new System.Windows.Forms.TabPage();
            this._courseDataGridView = new System.Windows.Forms.DataGridView();
            this._select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._stage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._hour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._courseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._teacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._classTime0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._classTime1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._classTime2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._classTime3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._classTime4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._classTime5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._classTime6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._classroom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._numberOfStudents = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._numberOfDropStudents = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._teachingAssistant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._language = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._outline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._audit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._experiment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._tabPage2 = new System.Windows.Forms.TabPage();
            this._courseTabControl.SuspendLayout();
            this._tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._courseDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // courseSelectionResultButton
            // 
            this._courseSelectionResultButton.Location = new System.Drawing.Point(1248, 596);
            this._courseSelectionResultButton.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this._courseSelectionResultButton.Name = "courseSelectionResultButton";
            this._courseSelectionResultButton.Size = new System.Drawing.Size(321, 120);
            this._courseSelectionResultButton.TabIndex = 0;
            this._courseSelectionResultButton.Text = "查看選課結果";
            this._courseSelectionResultButton.UseVisualStyleBackColor = true;
            this._courseSelectionResultButton.Click += new System.EventHandler(this.CourseSelectionResultButtonClick);
            // 
            // submitButton
            // 
            this._submitButton.Enabled = false;
            this._submitButton.Location = new System.Drawing.Point(923, 596);
            this._submitButton.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this._submitButton.Name = "submitButton";
            this._submitButton.Size = new System.Drawing.Size(321, 120);
            this._submitButton.TabIndex = 1;
            this._submitButton.Text = "確認送出";
            this._submitButton.UseVisualStyleBackColor = true;
            this._submitButton.Click += new System.EventHandler(this.SubmitButtonClick);
            // 
            // courseTabControl
            // 
            this._courseTabControl.Controls.Add(this._tabPage1);
            this._courseTabControl.Controls.Add(this._tabPage2);
            this._courseTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this._courseTabControl.Location = new System.Drawing.Point(0, 0);
            this._courseTabControl.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this._courseTabControl.Name = "courseTabControl";
            this._courseTabControl.Padding = new System.Drawing.Point(3, 3);
            this._courseTabControl.SelectedIndex = 0;
            this._courseTabControl.Size = new System.Drawing.Size(1573, 590);
            this._courseTabControl.TabIndex = 3;
            this._courseTabControl.SelectedIndexChanged += new System.EventHandler(this.CourseTabControlSelectedIndexChanged);
            // 
            // tabPage1
            // 
            this._tabPage1.Controls.Add(this._courseDataGridView);
            this._tabPage1.Location = new System.Drawing.Point(8, 39);
            this._tabPage1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this._tabPage1.Name = "tabPage1";
            this._tabPage1.Size = new System.Drawing.Size(1557, 543);
            this._tabPage1.TabIndex = 0;
            this._tabPage1.Text = "tabPage1";
            this._tabPage1.UseVisualStyleBackColor = true;
            // 
            // courseDataGridView
            // 
            this._courseDataGridView.AllowUserToAddRows = false;
            this._courseDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this._courseDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this._courseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._courseDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._select,
            this._number,
            this._name,
            this._stage,
            this._credit,
            this._hour,
            this._courseType,
            this._teacher,
            this._classTime0,
            this._classTime1,
            this._classTime2,
            this._classTime3,
            this._classTime4,
            this._classTime5,
            this._classTime6,
            this._classroom,
            this._numberOfStudents,
            this._numberOfDropStudents,
            this._teachingAssistant,
            this._language,
            this._outline,
            this._note,
            this._audit,
            this._experiment});
            this._courseDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._courseDataGridView.Location = new System.Drawing.Point(0, 0);
            this._courseDataGridView.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this._courseDataGridView.Name = "courseDataGridView";
            this._courseDataGridView.ReadOnly = true;
            this._courseDataGridView.RowHeadersVisible = false;
            this._courseDataGridView.RowHeadersWidth = 100;
            this._courseDataGridView.RowTemplate.Height = 20;
            this._courseDataGridView.Size = new System.Drawing.Size(1557, 543);
            this._courseDataGridView.TabIndex = 0;
            this._courseDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CourseDataGridViewCellClicked);
            this._courseDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CourseDataGridViewCellValueChanged);
            this._courseDataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.CourseDataGridViewCurrentCellDirtyStateChanged);
            // 
            // Select
            // 
            this._select.HeaderText = "選";
            this._select.MinimumWidth = 10;
            this._select.Name = "Select";
            this._select.ReadOnly = true;
            this._select.Width = 40;
            // 
            // Number
            // 
            this._number.HeaderText = "課號";
            this._number.MinimumWidth = 10;
            this._number.Name = "Number";
            this._number.ReadOnly = true;
            this._number.Width = 103;
            // 
            // Name
            // 
            this._name.HeaderText = "課程名稱";
            this._name.MinimumWidth = 10;
            this._name.Name = "Name";
            this._name.ReadOnly = true;
            this._name.Width = 151;
            // 
            // Stage
            // 
            this._stage.HeaderText = "階段";
            this._stage.MinimumWidth = 10;
            this._stage.Name = "Stage";
            this._stage.ReadOnly = true;
            this._stage.Width = 103;
            // 
            // Credit
            // 
            this._credit.HeaderText = "學分";
            this._credit.MinimumWidth = 10;
            this._credit.Name = "Credit";
            this._credit.ReadOnly = true;
            this._credit.Width = 103;
            // 
            // Hour
            // 
            this._hour.HeaderText = "時數";
            this._hour.MinimumWidth = 10;
            this._hour.Name = "Hour";
            this._hour.ReadOnly = true;
            this._hour.Width = 103;
            // 
            // CourseType
            // 
            this._courseType.HeaderText = "修";
            this._courseType.MinimumWidth = 10;
            this._courseType.Name = "CourseType";
            this._courseType.ReadOnly = true;
            this._courseType.Width = 79;
            // 
            // Teacher
            // 
            this._teacher.HeaderText = "教師";
            this._teacher.MinimumWidth = 10;
            this._teacher.Name = "Teacher";
            this._teacher.ReadOnly = true;
            this._teacher.Width = 103;
            // 
            // ClassTime0
            // 
            this._classTime0.HeaderText = "日";
            this._classTime0.MinimumWidth = 10;
            this._classTime0.Name = "ClassTime0";
            this._classTime0.ReadOnly = true;
            this._classTime0.Width = 79;
            // 
            // ClassTime1
            // 
            this._classTime1.HeaderText = "一";
            this._classTime1.MinimumWidth = 10;
            this._classTime1.Name = "ClassTime1";
            this._classTime1.ReadOnly = true;
            this._classTime1.Width = 79;
            // 
            // ClassTime2
            // 
            this._classTime2.HeaderText = "二";
            this._classTime2.MinimumWidth = 10;
            this._classTime2.Name = "ClassTime2";
            this._classTime2.ReadOnly = true;
            this._classTime2.Width = 79;
            // 
            // ClassTime3
            // 
            this._classTime3.HeaderText = "三";
            this._classTime3.MinimumWidth = 10;
            this._classTime3.Name = "ClassTime3";
            this._classTime3.ReadOnly = true;
            this._classTime3.Width = 79;
            // 
            // ClassTime4
            // 
            this._classTime4.HeaderText = "四";
            this._classTime4.MinimumWidth = 10;
            this._classTime4.Name = "ClassTime4";
            this._classTime4.ReadOnly = true;
            this._classTime4.Width = 79;
            // 
            // ClassTime5
            // 
            this._classTime5.HeaderText = "五";
            this._classTime5.MinimumWidth = 10;
            this._classTime5.Name = "ClassTime5";
            this._classTime5.ReadOnly = true;
            this._classTime5.Width = 79;
            // 
            // ClassTime6
            // 
            this._classTime6.HeaderText = "六";
            this._classTime6.MinimumWidth = 10;
            this._classTime6.Name = "ClassTime6";
            this._classTime6.ReadOnly = true;
            this._classTime6.Width = 79;
            // 
            // Classroom
            // 
            this._classroom.HeaderText = "教室";
            this._classroom.MinimumWidth = 10;
            this._classroom.Name = "Classroom";
            this._classroom.ReadOnly = true;
            this._classroom.Width = 103;
            // 
            // NumberOfStudents
            // 
            this._numberOfStudents.HeaderText = "人";
            this._numberOfStudents.MinimumWidth = 10;
            this._numberOfStudents.Name = "NumberOfStudents";
            this._numberOfStudents.ReadOnly = true;
            this._numberOfStudents.Width = 79;
            // 
            // NumberOfDropStudents
            // 
            this._numberOfDropStudents.HeaderText = "撤";
            this._numberOfDropStudents.MinimumWidth = 10;
            this._numberOfDropStudents.Name = "NumberOfDropStudents";
            this._numberOfDropStudents.ReadOnly = true;
            this._numberOfDropStudents.Width = 79;
            // 
            // TeachingAssistant
            // 
            this._teachingAssistant.HeaderText = "教學助理";
            this._teachingAssistant.MinimumWidth = 10;
            this._teachingAssistant.Name = "TeachingAssistant";
            this._teachingAssistant.ReadOnly = true;
            this._teachingAssistant.Width = 151;
            // 
            // Language
            // 
            this._language.HeaderText = "授課語言";
            this._language.MinimumWidth = 10;
            this._language.Name = "Language";
            this._language.ReadOnly = true;
            this._language.Width = 151;
            // 
            // Outline
            // 
            this._outline.HeaderText = "教學大綱";
            this._outline.MinimumWidth = 10;
            this._outline.Name = "Outline";
            this._outline.ReadOnly = true;
            this._outline.Width = 151;
            // 
            // Note
            // 
            this._note.HeaderText = "備註";
            this._note.MinimumWidth = 10;
            this._note.Name = "Note";
            this._note.ReadOnly = true;
            this._note.Width = 103;
            // 
            // Audit
            // 
            this._audit.HeaderText = "隨班附讀";
            this._audit.MinimumWidth = 10;
            this._audit.Name = "Audit";
            this._audit.ReadOnly = true;
            this._audit.Width = 151;
            // 
            // Experiment
            // 
            this._experiment.HeaderText = "實驗實習";
            this._experiment.MinimumWidth = 10;
            this._experiment.Name = "Experiment";
            this._experiment.ReadOnly = true;
            this._experiment.Width = 151;
            // 
            // tabPage2
            // 
            this._tabPage2.Location = new System.Drawing.Point(8, 39);
            this._tabPage2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this._tabPage2.Name = "tabPage2";
            this._tabPage2.Size = new System.Drawing.Size(1557, 543);
            this._tabPage2.TabIndex = 1;
            this._tabPage2.Text = "tabPage2";
            this._tabPage2.UseVisualStyleBackColor = true;
            // 
            // CourseSelectingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1573, 728);
            this.Controls.Add(this._courseTabControl);
            this.Controls.Add(this._submitButton);
            this.Controls.Add(this._courseSelectionResultButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "CourseSelectingForm";
            this.Text = "選課";
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CourseSelectingFormLoad);
            this._courseTabControl.ResumeLayout(false);
            this._tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._courseDataGridView)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button _courseSelectionResultButton;
        private System.Windows.Forms.Button _submitButton;
        private System.Windows.Forms.TabControl _courseTabControl;
        private System.Windows.Forms.TabPage _tabPage1;
        private System.Windows.Forms.TabPage _tabPage2;
        private System.Windows.Forms.DataGridView _courseDataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _select;
        private System.Windows.Forms.DataGridViewTextBoxColumn _number;
        private System.Windows.Forms.DataGridViewTextBoxColumn _name;
        private System.Windows.Forms.DataGridViewTextBoxColumn _stage;
        private System.Windows.Forms.DataGridViewTextBoxColumn _credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn _hour;
        private System.Windows.Forms.DataGridViewTextBoxColumn _courseType;
        private System.Windows.Forms.DataGridViewTextBoxColumn _teacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn _classTime0;
        private System.Windows.Forms.DataGridViewTextBoxColumn _classTime1;
        private System.Windows.Forms.DataGridViewTextBoxColumn _classTime2;
        private System.Windows.Forms.DataGridViewTextBoxColumn _classTime3;
        private System.Windows.Forms.DataGridViewTextBoxColumn _classTime4;
        private System.Windows.Forms.DataGridViewTextBoxColumn _classTime5;
        private System.Windows.Forms.DataGridViewTextBoxColumn _classTime6;
        private System.Windows.Forms.DataGridViewTextBoxColumn _classroom;
        private System.Windows.Forms.DataGridViewTextBoxColumn _numberOfStudents;
        private System.Windows.Forms.DataGridViewTextBoxColumn _numberOfDropStudents;
        private System.Windows.Forms.DataGridViewTextBoxColumn _teachingAssistant;
        private System.Windows.Forms.DataGridViewTextBoxColumn _language;
        private System.Windows.Forms.DataGridViewTextBoxColumn _outline;
        private System.Windows.Forms.DataGridViewTextBoxColumn _note;
        private System.Windows.Forms.DataGridViewTextBoxColumn _audit;
        private System.Windows.Forms.DataGridViewTextBoxColumn _experiment;
    }
}

