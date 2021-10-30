using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseManager
{
    public partial class CourseSelectingForm : Form
    {
        Form _courseSelectionResultForm;
        private readonly CourseSelectingFormViewModel _viewModel;

        public CourseSelectingForm(CourseSelectingFormViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.ViewModelChanged += LoadCourseDataGridView;

            _courseSelectionResultForm = new CourseSelectionResultForm(new CourseSelectionResultFormViewModel(_viewModel.Model));
            _courseSelectionResultForm.FormClosing += new FormClosingEventHandler(CourseSelectionResultFormClosing);

            InitializeComponent();
            SetBindingProperties();
        }

        // load select course form
        private void CourseSelectingFormLoad(object sender, EventArgs e)
        {
            List<CourseTabPageInfo> courseTabPageInfos = _viewModel.GetCourseTabPageInfos();
            int tabCount = courseTabPageInfos.Count;
            for (int index = 0; index < tabCount; index++)
            {
                CourseTabPageInfo tabPageInfo = courseTabPageInfos[index];
                _courseTabControl.Controls[index].Name = tabPageInfo.TabName;
                _courseTabControl.Controls[index].Text = tabPageInfo.TabText;
            }

            LoadCourseDataGridView();
        }

        // add data binding properties
        private void SetBindingProperties()
        {
            _courseTabControl.DataBindings.Add(nameof(_courseTabControl.Enabled), _viewModel, nameof(_viewModel.CourseTabControlEnabled));
            _courseSelectionResultButton.DataBindings.Add(nameof(_courseSelectionResultButton.Enabled), _viewModel, nameof(_viewModel.CourseSelectionResultButtonEnabled));
            _submitButton.DataBindings.Add(nameof(_submitButton.Enabled), _viewModel, nameof(_viewModel.SubmitButtonEnabled));
            _courseTabControl.DataBindings.Add(nameof(_courseTabControl.SelectedIndex), _viewModel, nameof(_viewModel.CurrentTabIndex));
        }

        // setup datagridview
        private void LoadCourseDataGridView()
        {
            _courseDataGridView.Rows.Clear();
            foreach (int index in _viewModel.CurrentShowingIndexes)
            {
                _courseDataGridView.Rows.Add(CreateSelectingCourseRow(_viewModel.CurrentCourseInfos[index]));
            }
            _courseDataGridView.Refresh();
        }

        // create datagridview row
        private DataGridViewRow CreateSelectingCourseRow(CourseInfo courseInfo)
        {
            DataGridViewRow row = new DataGridViewRow();
            foreach (string cellValue in courseInfo.GetCourseInfoStrings())
            {
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = cellValue
                });
            }
            row.Cells.Insert(0, new DataGridViewCheckBoxCell());
            return row;
        }

        // triggers when checkboxes in datagridview has value change 
        private void CourseDataGridViewCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            HandleSubmitButtonEnabled();
        }

        // change checkbox cell value when clicked
        private void CourseDataGridViewCellClicked(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;
            if (rowIndex >= 0 && columnIndex == 0)
            {
                if (Convert.ToBoolean(_courseDataGridView.Rows[rowIndex].Cells[0].Value))
                {
                    _courseDataGridView.Rows[rowIndex].Cells[columnIndex].Value = false;
                }
                else
                {
                    _courseDataGridView.Rows[rowIndex].Cells[columnIndex].Value = true;
                }
            }
            HandleSubmitButtonEnabled();
        }

        // handle button state when event occurs
        private void HandleSubmitButtonEnabled()
        {
            int selectedCourses = 0;
            foreach (DataGridViewRow row in _courseDataGridView.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    selectedCourses++;
                }
            }

            _viewModel.SubmitButtonEnabled = selectedCourses > 0;
        }

        // handle dirty state change
        private void CourseDataGridViewCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (_courseDataGridView.IsCurrentCellDirty)
            {
                _courseDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // add datagridview to selected tab index
        private void CourseTabControlSelectedIndexChanged(object sender, EventArgs e)
        {
            _viewModel.CurrentTabIndex = _courseTabControl.SelectedIndex;
            _courseTabControl.SelectedTab.Controls.Add(_courseDataGridView);
        }

        // show course result form
        private void CourseSelectionResultButtonClick(object sender, EventArgs e)
        {
            _courseSelectionResultForm.Show();
            _viewModel.CourseTabControlEnabled = false;
            _viewModel.CourseSelectionResultButtonEnabled = false;
            _viewModel.SubmitButtonEnabled = false;
        }

        // submit courses
        private void SubmitButtonClick(object sender, EventArgs e)
        {
            int tabIndex = _courseTabControl.SelectedIndex;
            int count = _courseDataGridView.Rows.Count;
            List<int> selectedIndexes = new List<int>();

            for (int index = 0; index < count; index++)
            {
                if (Convert.ToBoolean(_courseDataGridView.Rows[index].Cells[0].Value))
                {
                    selectedIndexes.Add(_viewModel.CurrentShowingIndexes[index]);
                }
            }

            string message = _viewModel.SelectCoursesAndGetMessage(tabIndex, selectedIndexes);
            MessageBox.Show(message);
            _courseDataGridView.ClearSelection();
            _viewModel.SubmitButtonEnabled = false;
        }

        // handle course selection form closing event
        private void CourseSelectionResultFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                _courseSelectionResultForm.Hide();
                _viewModel.CourseTabControlEnabled = true;
                _viewModel.CourseSelectionResultButtonEnabled = true;
                _viewModel.SubmitButtonEnabled = false;
            }
        }
    }
}
