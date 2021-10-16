﻿
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
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Teacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassTime0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassTime1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassTime2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassTime3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassTime4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassTime5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassTime6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Classroom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfStudents = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfDropStudents = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeachingAssistant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Language = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Outline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Audit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Experiment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.courseTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.courseDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // courseSelectionResultButton
            // 
            this.courseSelectionResultButton.Location = new System.Drawing.Point(1248, 596);
            this.courseSelectionResultButton.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.courseSelectionResultButton.Name = "courseSelectionResultButton";
            this.courseSelectionResultButton.Size = new System.Drawing.Size(321, 120);
            this.courseSelectionResultButton.TabIndex = 0;
            this.courseSelectionResultButton.Text = "查看選課結果";
            this.courseSelectionResultButton.UseVisualStyleBackColor = true;
            this.courseSelectionResultButton.Click += new System.EventHandler(this.CourseSelectionResultButtonClick);
            // 
            // submitButton
            // 
            this.submitButton.Enabled = false;
            this.submitButton.Location = new System.Drawing.Point(923, 596);
            this.submitButton.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(321, 120);
            this.submitButton.TabIndex = 1;
            this.submitButton.Text = "確認送出";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.SubmitButtonClick);
            // 
            // courseTabControl
            // 
            this.courseTabControl.Controls.Add(this.tabPage1);
            this.courseTabControl.Controls.Add(this.tabPage2);
            this.courseTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.courseTabControl.Location = new System.Drawing.Point(0, 0);
            this.courseTabControl.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.courseTabControl.Name = "courseTabControl";
            this.courseTabControl.Padding = new System.Drawing.Point(3, 3);
            this.courseTabControl.SelectedIndex = 0;
            this.courseTabControl.Size = new System.Drawing.Size(1573, 590);
            this.courseTabControl.TabIndex = 3;
            this.courseTabControl.SelectedIndexChanged += new System.EventHandler(this.CourseTabControlSelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.courseDataGridView);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1557, 543);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // courseDataGridView
            // 
            this.courseDataGridView.AllowUserToAddRows = false;
            this.courseDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.courseDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.courseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.courseDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.Number,
            this.Name,
            this.Stage,
            this.Credit,
            this.Hour,
            this.CourseType,
            this.Teacher,
            this.ClassTime0,
            this.ClassTime1,
            this.ClassTime2,
            this.ClassTime3,
            this.ClassTime4,
            this.ClassTime5,
            this.ClassTime6,
            this.Classroom,
            this.NumberOfStudents,
            this.NumberOfDropStudents,
            this.TeachingAssistant,
            this.Language,
            this.Outline,
            this.Note,
            this.Audit,
            this.Experiment});
            this.courseDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.courseDataGridView.Location = new System.Drawing.Point(0, 0);
            this.courseDataGridView.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.courseDataGridView.Name = "courseDataGridView";
            this.courseDataGridView.ReadOnly = true;
            this.courseDataGridView.RowHeadersVisible = false;
            this.courseDataGridView.RowHeadersWidth = 100;
            this.courseDataGridView.RowTemplate.Height = 20;
            this.courseDataGridView.Size = new System.Drawing.Size(1557, 543);
            this.courseDataGridView.TabIndex = 0;
            this.courseDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CourseDataGridViewCellClicked);
            this.courseDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CourseDataGridViewCellValueChanged);
            this.courseDataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.CourseDataGridViewCurrentCellDirtyStateChanged);
            // 
            // Select
            // 
            this.Select.HeaderText = "選";
            this.Select.MinimumWidth = 10;
            this.Select.Name = "Select";
            this.Select.ReadOnly = true;
            this.Select.Width = 40;
            // 
            // Number
            // 
            this.Number.HeaderText = "課號";
            this.Number.MinimumWidth = 10;
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.Width = 103;
            // 
            // Name
            // 
            this.Name.HeaderText = "課程名稱";
            this.Name.MinimumWidth = 10;
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            this.Name.Width = 151;
            // 
            // Stage
            // 
            this.Stage.HeaderText = "階段";
            this.Stage.MinimumWidth = 10;
            this.Stage.Name = "Stage";
            this.Stage.ReadOnly = true;
            this.Stage.Width = 103;
            // 
            // Credit
            // 
            this.Credit.HeaderText = "學分";
            this.Credit.MinimumWidth = 10;
            this.Credit.Name = "Credit";
            this.Credit.ReadOnly = true;
            this.Credit.Width = 103;
            // 
            // Hour
            // 
            this.Hour.HeaderText = "時數";
            this.Hour.MinimumWidth = 10;
            this.Hour.Name = "Hour";
            this.Hour.ReadOnly = true;
            this.Hour.Width = 103;
            // 
            // CourseType
            // 
            this.CourseType.HeaderText = "修";
            this.CourseType.MinimumWidth = 10;
            this.CourseType.Name = "CourseType";
            this.CourseType.ReadOnly = true;
            this.CourseType.Width = 79;
            // 
            // Teacher
            // 
            this.Teacher.HeaderText = "教師";
            this.Teacher.MinimumWidth = 10;
            this.Teacher.Name = "Teacher";
            this.Teacher.ReadOnly = true;
            this.Teacher.Width = 103;
            // 
            // ClassTime0
            // 
            this.ClassTime0.HeaderText = "日";
            this.ClassTime0.MinimumWidth = 10;
            this.ClassTime0.Name = "ClassTime0";
            this.ClassTime0.ReadOnly = true;
            this.ClassTime0.Width = 79;
            // 
            // ClassTime1
            // 
            this.ClassTime1.HeaderText = "一";
            this.ClassTime1.MinimumWidth = 10;
            this.ClassTime1.Name = "ClassTime1";
            this.ClassTime1.ReadOnly = true;
            this.ClassTime1.Width = 79;
            // 
            // ClassTime2
            // 
            this.ClassTime2.HeaderText = "二";
            this.ClassTime2.MinimumWidth = 10;
            this.ClassTime2.Name = "ClassTime2";
            this.ClassTime2.ReadOnly = true;
            this.ClassTime2.Width = 79;
            // 
            // ClassTime3
            // 
            this.ClassTime3.HeaderText = "三";
            this.ClassTime3.MinimumWidth = 10;
            this.ClassTime3.Name = "ClassTime3";
            this.ClassTime3.ReadOnly = true;
            this.ClassTime3.Width = 79;
            // 
            // ClassTime4
            // 
            this.ClassTime4.HeaderText = "四";
            this.ClassTime4.MinimumWidth = 10;
            this.ClassTime4.Name = "ClassTime4";
            this.ClassTime4.ReadOnly = true;
            this.ClassTime4.Width = 79;
            // 
            // ClassTime5
            // 
            this.ClassTime5.HeaderText = "五";
            this.ClassTime5.MinimumWidth = 10;
            this.ClassTime5.Name = "ClassTime5";
            this.ClassTime5.ReadOnly = true;
            this.ClassTime5.Width = 79;
            // 
            // ClassTime6
            // 
            this.ClassTime6.HeaderText = "六";
            this.ClassTime6.MinimumWidth = 10;
            this.ClassTime6.Name = "ClassTime6";
            this.ClassTime6.ReadOnly = true;
            this.ClassTime6.Width = 79;
            // 
            // Classroom
            // 
            this.Classroom.HeaderText = "教室";
            this.Classroom.MinimumWidth = 10;
            this.Classroom.Name = "Classroom";
            this.Classroom.ReadOnly = true;
            this.Classroom.Width = 103;
            // 
            // NumberOfStudents
            // 
            this.NumberOfStudents.HeaderText = "人";
            this.NumberOfStudents.MinimumWidth = 10;
            this.NumberOfStudents.Name = "NumberOfStudents";
            this.NumberOfStudents.ReadOnly = true;
            this.NumberOfStudents.Width = 79;
            // 
            // NumberOfDropStudents
            // 
            this.NumberOfDropStudents.HeaderText = "撤";
            this.NumberOfDropStudents.MinimumWidth = 10;
            this.NumberOfDropStudents.Name = "NumberOfDropStudents";
            this.NumberOfDropStudents.ReadOnly = true;
            this.NumberOfDropStudents.Width = 79;
            // 
            // TeachingAssistant
            // 
            this.TeachingAssistant.HeaderText = "教學助理";
            this.TeachingAssistant.MinimumWidth = 10;
            this.TeachingAssistant.Name = "TeachingAssistant";
            this.TeachingAssistant.ReadOnly = true;
            this.TeachingAssistant.Width = 151;
            // 
            // Language
            // 
            this.Language.HeaderText = "授課語言";
            this.Language.MinimumWidth = 10;
            this.Language.Name = "Language";
            this.Language.ReadOnly = true;
            this.Language.Width = 151;
            // 
            // Outline
            // 
            this.Outline.HeaderText = "教學大綱";
            this.Outline.MinimumWidth = 10;
            this.Outline.Name = "Outline";
            this.Outline.ReadOnly = true;
            this.Outline.Width = 151;
            // 
            // Note
            // 
            this.Note.HeaderText = "備註";
            this.Note.MinimumWidth = 10;
            this.Note.Name = "Note";
            this.Note.ReadOnly = true;
            this.Note.Width = 103;
            // 
            // Audit
            // 
            this.Audit.HeaderText = "隨班附讀";
            this.Audit.MinimumWidth = 10;
            this.Audit.Name = "Audit";
            this.Audit.ReadOnly = true;
            this.Audit.Width = 151;
            // 
            // Experiment
            // 
            this.Experiment.HeaderText = "實驗實習";
            this.Experiment.MinimumWidth = 10;
            this.Experiment.Name = "Experiment";
            this.Experiment.ReadOnly = true;
            this.Experiment.Width = 151;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1557, 543);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // CourseSelectingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1573, 728);
            this.Controls.Add(this.courseTabControl);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.courseSelectionResultButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            //this.Name = "CourseSelectingForm";
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hour;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Teacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassTime0;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassTime1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassTime2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassTime3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassTime4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassTime5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassTime6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Classroom;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfStudents;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfDropStudents;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeachingAssistant;
        private System.Windows.Forms.DataGridViewTextBoxColumn Language;
        private System.Windows.Forms.DataGridViewTextBoxColumn Outline;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note;
        private System.Windows.Forms.DataGridViewTextBoxColumn Audit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Experiment;
    }
}

