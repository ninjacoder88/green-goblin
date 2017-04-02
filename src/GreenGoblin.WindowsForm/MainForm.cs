using System;
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
            txtDescription.DataBindings.Add(nameof(txtDescription.Name), viewModel, nameof(viewModel.TaskDescription));
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

        private readonly GreenGoblinViewModel _viewModel;
    }
}