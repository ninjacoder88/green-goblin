using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
            txtDescription.DataBindings.Add(nameof(txtDescription.Enabled), _viewModel, nameof(_viewModel.NotLoading));
            txtDescription.TextChanged += txtDescription_TextChanged;

            txtCategory.DataBindings.Add(nameof(txtCategory.Text), _viewModel, nameof(_viewModel.TaskCategory));
            txtCategory.DataBindings.Add(nameof(txtCategory.Enabled), _viewModel, nameof(_viewModel.NotLoading));
            txtCategory.TextChanged += txtCategory_TextChanged;

            lblTaskTime.DataBindings.Add(nameof(lblTaskTime.Text), _viewModel, nameof(_viewModel.SelectedTaskTime));
            progressBar1.DataBindings.Add(nameof(progressBar1.Visible), _viewModel, nameof(_viewModel.Loading));
            panelButtons.DataBindings.Add(nameof(panelButtons.Enabled), _viewModel, nameof(_viewModel.NotLoading));

            btnSave.DataBindings.Add(nameof(btnSave.Enabled), _viewModel, nameof(_viewModel.PendingChanges));
            btnEnd.DataBindings.Add(nameof(btnEnd.Enabled), _viewModel, nameof(_viewModel.ActiveModelOpen));
            btnBreak.DataBindings.Add(nameof(btnBreak.Enabled), _viewModel, nameof(_viewModel.ActiveModelOpen));
            btnLunch.DataBindings.Add(nameof(btnLunch.Enabled), _viewModel, nameof(_viewModel.ActiveModelOpen));

            _worker.DoWork += Worker_DoWork;
            _worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            using (var form = new PromptForm())
            {
                var dialogResult = form.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    _viewModel.Archive(form.UserInput);
                }
            }
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

        private void btnReconcile_Click(object sender, EventArgs e)
        {
            _viewModel.Reconcile();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (_viewModel.PendingChanges)
            {
                var dialogResult = MessageBox.Show(this, "There are pending changes. Would you like to save?", "Pending Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    _viewModel.Save();
                }
            }

            StartLoading();
        }

        private void btnRemoveEntry_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(this, "Are you sure you want to remove the selected entries?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            _viewModel.RemoveEntry();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _viewModel.Save();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _viewModel.StartTask();
        }

        private void dgvTimeEntries_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            var row = dgv.Rows[e.RowIndex];
            var model = row.DataBoundItem as TimeEntryModel;

            bool modelUpdated = false;
            using (var form = new EditEntryForm(model))
            {
                form.ShowDialog();
                modelUpdated = form.ModelUpdated;
            }

            if (modelUpdated)
            {
                _viewModel.ModelEdited(model);
            }
        }

        private void dgvTimeEntries_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv = sender as DataGridView;
            TimeEntryModel model = dgv.Rows[e.RowIndex].DataBoundItem as TimeEntryModel;

            if (model.Reconciled)
            {
                e.CellStyle.BackColor = Color.Green;
            }

            if (model.OverlapWarning)
            {
                e.CellStyle.ForeColor = Color.Red;
            }
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            StartLoading();
        }

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

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            _viewModel.Load();
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _viewModel.FinishLoading();
        }

        private readonly GreenGoblinViewModel _viewModel;
        private readonly BackgroundWorker _worker = new BackgroundWorker();
    }
}