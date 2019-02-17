using System.Windows.Forms;
using GreenGoblin.WindowsFormApplication.Models;
using GreenGoblin.WindowsFormApplication.ViewModels;

namespace GreenGoblin.WindowsFormApplication.ApplicationForms
{
    public partial class ManageCategoriesForm : Form
    {
        public ManageCategoriesForm(ManageCategoriesViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();

            dgvCategories.DataSource = _viewModel.Categories;

            btnEdit.DataBindings.Add(nameof(btnEdit.Enabled), _viewModel, nameof(_viewModel.NotEditing));
            btnSaveEdit.DataBindings.Add(nameof(btnSaveEdit.Enabled), _viewModel, nameof(_viewModel.Editing));
            btnCancelEdit.DataBindings.Add(nameof(btnCancelEdit.Enabled), _viewModel, nameof(_viewModel.Editing));

            btnAdd.DataBindings.Add(nameof(btnAdd.Enabled), _viewModel, nameof(_viewModel.NotEditing));
            btnDelete.DataBindings.Add(nameof(btnDelete.Enabled), _viewModel, nameof(_viewModel.NotEditing));

            textCategoryName.DataBindings.Add(nameof(textCategoryName.Text), _viewModel, nameof(_viewModel.CategoryName));

            dgvCategories.SelectionChanged += DgvCategories_SelectionChanged;
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            _viewModel.AddCategory();
        }

        private void btnCancelChanges_Click(object sender, System.EventArgs e)
        {
        }

        private void btnCancelEdit_Click(object sender, System.EventArgs e)
        {
            _viewModel.CancelEdit();
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            _viewModel.Delete();
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            _viewModel.Edit();
        }

        private void btnSaveChanges_Click(object sender, System.EventArgs e)
        {
        }

        private void btnSaveEdit_Click(object sender, System.EventArgs e)
        {
            _viewModel.SaveEdit();
        }

        private void DgvCategories_SelectionChanged(object sender, System.EventArgs e)
        {
            var dataGridView = sender as DataGridView;
            var selectedRows = dataGridView.SelectedRows;

            if (selectedRows.Count != 1)
            {
                return;
            }

            var selectedRow = selectedRows[0];
            var categoryModel = selectedRow.DataBoundItem as CategoryModel;

            _viewModel.SelectedCategory = categoryModel;
        }

        private readonly ManageCategoriesViewModel _viewModel;
    }
}