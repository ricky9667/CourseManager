
namespace CourseManager
{
    partial class CourseSelectionResultForm
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
            this._selectedCourseDataGridView = new System.Windows.Forms.DataGridView();
            this._dropOutButton = new System.Windows.Forms.DataGridViewButtonColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this._selectedCourseDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // selectedCourseDataGridView
            // 
            this._selectedCourseDataGridView.AllowUserToAddRows = false;
            this._selectedCourseDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this._selectedCourseDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this._selectedCourseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._selectedCourseDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._dropOutButton,
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
            this._selectedCourseDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._selectedCourseDataGridView.Location = new System.Drawing.Point(0, 0);
            this._selectedCourseDataGridView.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this._selectedCourseDataGridView.Name = "selectedCourseDataGridView";
            this._selectedCourseDataGridView.ReadOnly = true;
            this._selectedCourseDataGridView.RowHeadersVisible = false;
            this._selectedCourseDataGridView.RowHeadersWidth = 100;
            this._selectedCourseDataGridView.RowTemplate.Height = 20;
            this._selectedCourseDataGridView.Size = new System.Drawing.Size(1574, 729);
            this._selectedCourseDataGridView.TabIndex = 1;
            this._selectedCourseDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SelectedCourseDataGridViewCellContentClick);
            // 
            // DropOutButton
            // 
            this._dropOutButton.HeaderText = "退";
            this._dropOutButton.MinimumWidth = 10;
            this._dropOutButton.Name = "DropOutButton";
            this._dropOutButton.ReadOnly = true;
            this._dropOutButton.Width = 40;
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
            // CourseSelectionResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1574, 729);
            this.Controls.Add(this._selectedCourseDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CourseSelectionResultForm";
            this.Text = "選課結果";
            this.MaximizeBox = false;
            this.Load += new System.EventHandler(this.CourseSelectionResultFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this._selectedCourseDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _selectedCourseDataGridView;
        private System.Windows.Forms.DataGridViewButtonColumn _dropOutButton;
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