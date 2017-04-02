using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GreenGoblin.WindowsForm
{
    public partial class MainForm : Form
    {
        public MainForm(GreenGoblinViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();

            dgvTimeEntries.DataSource = viewModel.TimeEntryModels;
            txtDescription.DataBindings.Add(nameof(txtDescription.Text), _viewModel, nameof(_viewModel.TaskDescription));
            lblTaskTime.DataBindings.Add(nameof(lblTaskTime.Text), _viewModel, nameof(_viewModel.SelectedTaskTime));
        }

        private void btnBreak_Click(object sender, EventArgs e)
        {
            _viewModel.StartBreak();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            _viewModel.EndOfDay();
        }

        private void btnLunch_Click(object sender, EventArgs e)
        {
            _viewModel.StartLunch();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _viewModel.StartTask();
        }

        private void dgvTimeEntries_SelectionChanged(object sender, EventArgs e)
        {
            var dgv = sender as DataGridView;
            var rows = dgv.SelectedRows;
            if (rows.Count < 1)
            {
                return;
            }

            List<TimeEntryModel> selectedModels = new List<TimeEntryModel>();
            foreach (var row in rows)
            {
                DataGridViewRow dgvr = row as DataGridViewRow;
                TimeEntryModel model = dgvr.DataBoundItem as TimeEntryModel;
                selectedModels.Add(model);
            }
            _viewModel.UpdateSelectedModels(selectedModels);
        }

        private readonly GreenGoblinViewModel _viewModel;
    }
}