using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseManager
{
    public partial class CourseSelectionResultForm : Form
    {
        CourseModel _courseModel;
        public CourseSelectionResultForm(CourseModel courseModel)
        {
            _courseModel = courseModel;
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
            List<CourseInfo> selectedCourseInfos = _courseModel.GetSelectedCourseInfos();

            selectedCourseDataGridView.Rows.Clear();
            // Fix: still has one blank row left

            foreach (CourseInfo info in selectedCourseInfos)
            {
                DataGridViewRow row = new DataGridViewRow();
                foreach (string cellValue in info.GetCourseInfoStrings())
                {
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = cellValue });
                }

                row.Cells.Insert(0, new DataGridViewButtonCell
                {
                    Value = "退選",
                });

                selectedCourseDataGridView.Rows.Add(row);
            }

            selectedCourseDataGridView.Refresh();
        }

        // handle drop out button
        private void SelectedCourseDataGridViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                _courseModel.RemoveCourse(e.RowIndex);
            }

            MessageBox.Show("退選成功");
            LoadSelectedCourseDataGridView();
        }
    }
}
