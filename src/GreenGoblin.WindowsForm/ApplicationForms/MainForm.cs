using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
            //panelButtons.DataBindings.Add(nameof(panelButtons.Enabled), _viewModel, nameof(_viewModel.NotLoading));

            //btnSave.DataBindings.Add(nameof(btnSave.Enabled), _viewModel, nameof(_viewModel.PendingChanges));
            //btnEnd.DataBindings.Add(nameof(btnEnd.Enabled), _viewModel, nameof(_viewModel.ActiveModelOpen));
            //btnBreak.DataBindings.Add(nameof(btnBreak.Enabled), _viewModel, nameof(_viewModel.ActiveModelOpen));
            //btnLunch.DataBindings.Add(nameof(btnLunch.Enabled), _viewModel, nameof(_viewModel.ActiveModelOpen));

            //btnArchive.Click += Archive_Event;
            tsmiManageArchive.Click += Archive_Event;

            //btnBreak.Click += Break_Event;
            tsmiTaskBreak.Click += Break_Event;

            //btnEnd.Click += End_Event;
            tsmiTaskEndDay.Click += End_Event;

            //btnLunch.Click += Lunch_Event;
            tsmiTaskLunch.Click += Lunch_Event;

            //btnReconcile.Click += Reconcile_Event;
            tsmiManageReconcile.Click += Reconcile_Event;

            //btnRefresh.Click += Refresh_Event;
            tsmiDataRefresh.Click += Refresh_Event;

            //btnRemoveEntry.Click += Remove_Event;
            tsmiManageDelete.Click += Remove_Event;

            //btnSave.Click += Save_Event;
            tsmiDataSave.Click += Save_Event;

            //btnStart.Click += Start_Event;
            tmsiTaskStart.Click += Start_Event;

            _worker.DoWork += Worker_DoWork;
            _worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        private void Archive_Event(object sender, EventArgs e)
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

        private void Break_Event(object sender, EventArgs e)
        {
            _viewModel.StartBreak();
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
                e.CellStyle.BackColor = Color.LightGreen;
                e.CellStyle.ForeColor = Color.Black;
            }

            if (model.OverlapWarning)
            {
                //dgv.Rows[e.RowIndex].Cells[0].Style.BackColor = Color.Red;
                //dgv.Rows[e.RowIndex+1].Cells[1].Style.BackColor = Color.Red;
                e.CellStyle.BackColor = Color.Red;
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

        private void End_Event(object sender, EventArgs e)
        {
            _viewModel.EndOfDay();
        }

        private void Lunch_Event(object sender, EventArgs e)
        {
            _viewModel.StartLunch();
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

        private void Reconcile_Event(object sender, EventArgs e)
        {
            _viewModel.Reconcile();
        }

        private void Refresh_Event(object sender, EventArgs e)
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

        private void Remove_Event(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(this, "Are you sure you want to remove the selected entries?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            _viewModel.RemoveEntry();
        }

        private void Save_Event(object sender, EventArgs e)
        {
            _viewModel.Save();
        }

        private void Start_Event(object sender, EventArgs e)
        {
            _viewModel.StartTask();
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