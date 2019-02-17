using System.Windows.Forms;
using GreenGoblin.WindowsFormApplication.Models;
using GreenGoblin.WindowsFormApplication.ViewModels;

namespace GreenGoblin.WindowsFormApplication.ApplicationForms
{
    public partial class ManageCategoriesForm : Form
    {
        public ManageCategoriesForm(ManageCatergoriesViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();

            dgvCategories.DataSource = _viewModel.Categories;

            btnEdit.DataBindings.Add(nameof(btnEdit.Enabled), _viewModel, nameof(_viewModel.NotEditing));
            btnSaveEdit.DataBindings.Add(nameof(btnSaveEdit.Enabled), _viewModel, nameof(_viewModel.Editing));
            btnCancelEdit.DataBindings.Add(nameof(btnCancelEdit.Enabled), _viewModel, nameof(_viewModel.Editing));
            btnDelete.DataBindings.Add(nameof(btnDelete.Enabled), _viewModel, nameof(_viewModel.Editing));
            textCategoryName.DataBindings.Add(nameof(textCategoryName.Text), _viewModel, nameof(_viewModel.NewCategoryName));
            textEditCategory.DataBindings.Add(nameof(textEditCategory.Enabled), _viewModel, nameof(_viewModel.Editing));

            dgvCategories.SelectionChanged += DgvCategories_SelectionChanged;
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            _viewModel.AddCategory();
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
                //_viewModel.SelectedCategory = null;
                return;
            }

            var selectedRow = selectedRows[0];
            var categoryModel = selectedRow.DataBoundItem as CategoryModel;

            _viewModel.SelectedCategory = categoryModel;
        }

        private readonly ManageCatergoriesViewModel _viewModel;
    }
}