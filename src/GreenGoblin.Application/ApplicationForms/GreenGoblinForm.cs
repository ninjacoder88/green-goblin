using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using GreenGoblin.WindowsFormApplication.ApplicationForms;
using GreenGoblin.WindowsFormApplication.Models;
using GreenGoblin.WindowsFormApplication.ViewModels;

namespace GreenGoblin.WindowsFormApplication.ApplicationForms
{
    public partial class GreenGoblinForm : Form
    {
        public GreenGoblinForm(GreenGoblinViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();

            dgvWorkDays.DataSource = _viewModel.WorkDays;
            dgvTasks.DataSource = _viewModel.WorkDayTasks;
            comboCategories.DataSource = _viewModel.Categories;
            textTaskName.DataBindings.Add(nameof(textTaskName.Text), _viewModel, nameof(_viewModel.TaskName));

            dgvWorkDays.SelectionChanged += DgvWorkDays_SelectionChanged;
            dgvTasks.SelectionChanged += DgvTasks_SelectionChanged;
            comboCategories.SelectedIndexChanged += ComboCategories_SelectedIndexChanged;

            _worker.DoWork += Worker_DoWork;
            _worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        private readonly BackgroundWorker _worker = new BackgroundWorker();

        private void StartLoading()
        {
            if (_viewModel.CheckBackupFile())
            {
                var dialogResult = MessageBox.Show(this, "A backup file exists. Would you like to load from the backup file?", "Load Backup File", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _viewModel.LoadBackupFile = true;
                }
            }

            _viewModel.StartLoading();
            _worker.RunWorkerAsync();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            _viewModel.Load();
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _viewModel.FinishLoading();
        }

        private void btnManageCategories_Click(object sender, System.EventArgs e)
        {
            var viewModel = new ManageCategoriesViewModel();
            using (var form = new ManageCategoriesForm(viewModel))
            {
                form.ShowDialog(this);

                if (form.DialogResult == DialogResult.OK)
                {
                    _viewModel.Categories.Clear();
                    foreach (var viewModelCategory in viewModel.Categories)
                    {
                        _viewModel.Categories.Add(viewModelCategory);
                    }

                    _viewModel.SaveCategories();
                }
            }
        }

        private void ComboCategories_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var selectedItem = comboCategories.SelectedItem;
            if (selectedItem == null)
            {
                _viewModel.SelectedCategory = null;
                return;
            }

            var categoryModel = selectedItem as CategoryModel;
            if (categoryModel == null)
            {
                _viewModel.SelectedCategory = null;
                return;
            }

            _viewModel.SelectedCategory = categoryModel;
        }

        private void DgvTasks_SelectionChanged(object sender, System.EventArgs e)
        {
            var dataGridView = sender as DataGridView;
            var selectedRows = dataGridView.SelectedRows;

            var taskModels = new List<TaskModel>();
            foreach (var row in selectedRows)
            {
                DataGridViewRow dgvr = row as DataGridViewRow;
                TaskModel model = dgvr.DataBoundItem as TaskModel;
                taskModels.Add(model);
            }

            _viewModel.UpdateSelectedTasks(taskModels);
        }

        private void DgvWorkDays_SelectionChanged(object sender, System.EventArgs e)
        {
            var dataGridView = sender as DataGridView;
            var selectedRows = dataGridView.SelectedRows;

            var workDayModels = new List<WorkDayModel>();
            foreach (var row in selectedRows)
            {
                DataGridViewRow dgvr = row as DataGridViewRow;
                WorkDayModel model = dgvr.DataBoundItem as WorkDayModel;
                workDayModels.Add(model);
            }

            _viewModel.UpdateSelectedWorkDays(workDayModels);
        }

        private readonly GreenGoblinViewModel _viewModel;

        private void btnStartTask_Click(object sender, System.EventArgs e)
        {
            _viewModel.StartTask();
        }

        private void btnEndTask_Click(object sender, System.EventArgs e)
        {
            _viewModel.EndTask();
        }

        private void GreenGoblinForm_Load(object sender, System.EventArgs e)
        {
            StartLoading();
        }

        private void GreenGoblinForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_viewModel.PendingChanges)
            {
                return;
            }

            var dialogResult = MessageBox.Show(this, "There are pending changes. Would you like to save?", "Pending Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            _viewModel.Save();
        }
    }
}