using System.Collections.Generic;
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
        }

        private void btnManageCategories_Click(object sender, System.EventArgs e)
        {
            var viewModel = new ManageCatergoriesViewModel();
            using (var form = new ManageCategoriesForm(viewModel))
            {
                form.ShowDialog(this);
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
    }
}