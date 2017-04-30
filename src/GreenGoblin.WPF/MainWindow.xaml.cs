using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace GreenGoblin.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new GreenGoblinViewModel();

            _worker.DoWork += Worker_DoWork;
            _worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

            //DataContext = _viewModel;
        }

        public GreenGoblinViewModel ViewModel => _viewModel;

        private void BtnBreak_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.StartBreak();
        }

        private void BtnEndDay_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.EndDay();
        }

        private void BtnLunch_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.StartLunch();
        }

        private void BtnReconcile_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Reconcile();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            StartLoading();
        }

        private void BtnRemoveEntry_Click(object sender, RoutedEventArgs e)
        {
            var dialogResult = MessageBox.Show(this, "Are you sure you want to remove the selected entries?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (dialogResult != MessageBoxResult.Yes)
            {
                return;
            }

            _viewModel.RemoveEntry();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Save();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.StartTask();
        }

        private void StartLoading()
        {
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

        private readonly BackgroundWorker _worker = new BackgroundWorker();
        private readonly GreenGoblinViewModel _viewModel;
    }
}