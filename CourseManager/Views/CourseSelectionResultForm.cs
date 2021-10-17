﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseManager
{
    public partial class CourseSelectionResultForm : Form
    {
        CourseSelectionResultFormViewModel _viewModel;
        public CourseSelectionResultForm(CourseSelectionResultFormViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
        }

        // load select course form
        private void CourseSelectionResultFormLoad(object sender, EventArgs e)
        {
            LoadSelectedCourseDataGridView();
        }

        // setup datagridview
        private void LoadSelectedCourseDataGridView()
        {
            List<CourseInfo> selectedCourseInfos = _viewModel.GetSelectedCourseInfos();
            selectedCourseDataGridView.Rows.Clear();

            foreach (CourseInfo info in selectedCourseInfos)
            {
                DataGridViewRow row = new DataGridViewRow();
                foreach (string cellValue in info.GetCourseInfoStrings())
                {
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = cellValue });
                }

                row.Cells.Insert(0, new DataGridViewButtonCell { Value = "退選", });
                selectedCourseDataGridView.Rows.Add(row);
            }

            selectedCourseDataGridView.Refresh();
        }

        // handle drop out button
        private void SelectedCourseDataGridViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                _viewModel.RemoveCourse(e.RowIndex);
            }

            LoadSelectedCourseDataGridView();
        }
    }
}
