﻿using System;
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
            lblTaskTime.DataBindings.Add(nameof(lblTaskTime.Text), _viewModel, nameof(_viewModel.SelectedTaskTime));
            btnSave.DataBindings.Add(nameof(btnSave.Enabled), _viewModel, nameof(_viewModel.PendingChanges));
            progressBar1.DataBindings.Add(nameof(progressBar1.Visible), _viewModel, nameof(_viewModel.Loading));
            btnSave.EnabledChanged += btnSave_EnabledChanged;
            //progressBar1.Visible = true;

            _worker.DoWork += Worker_DoWork;
            _worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
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
            _viewModel.Refresh();
        }

        private void btnRemoveEntry_Click(object sender, EventArgs e)
        {
            _viewModel.RemoveEntry();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _viewModel.Save();
        }

        private void btnSave_EnabledChanged(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (!button.Enabled)
            {
                button.BackColor = Color.MediumAquamarine;
            }
            else
            {
                button.BackColor = Color.LightGreen;
            }
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

            using (var form = new EditEntryForm(model))
            {
                form.ShowDialog();
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            _viewModel.BeginLoading();
            _worker.RunWorkerAsync();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            _viewModel.LoadData();
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _viewModel.LoadModels();
        }

        private readonly GreenGoblinViewModel _viewModel;
        private readonly BackgroundWorker _worker = new BackgroundWorker();
    }
}