using System.ComponentModel;
using System.Runtime.CompilerServices;
using GreenGoblin.WindowsFormApplication.Models;

namespace GreenGoblin.WindowsFormApplication.ViewModels
{
    public class ManageCategoriesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public BindingList<CategoryModel> Categories => _categories ?? (_categories = new BindingList<CategoryModel>());

        public bool Editing
        {
            get => _editing;
            set
            {
                _editing = value;
                OnPropertyChanged();
            }
        }

        public string CategoryName
        {
            get => _categoryName;
            set
            {
                _categoryName = value;
                OnPropertyChanged();
            }
        }

        public bool NotEditing => !Editing;

        public CategoryModel SelectedCategory { get; set; }

        public bool PendingChanges { get; set; }

        public void AddCategory()
        {
            if (string.IsNullOrEmpty(CategoryName))
            {
                return;
            }

            Categories.Add(new CategoryModel(CategoryName));
            CategoryName = string.Empty;
            PendingChanges = true;
        }

        public void CancelEdit()
        {
            Editing = false;
            CategoryName = string.Empty;
        }

        public void Delete()
        {
            if (SelectedCategory == null)
            {
                return;
            }

            Categories.Remove(SelectedCategory);
            PendingChanges = true;
        }

        public void Edit()
        {
            Editing = true;
            if (SelectedCategory == null)
            {
                return;
            }

            CategoryName = SelectedCategory.Name;
        }

        public void SaveEdit()
        {
            Editing = false;
            SelectedCategory.Name = CategoryName;
            CategoryName = string.Empty;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private BindingList<CategoryModel> _categories;
        private bool _editing;
        private string _categoryName;
    }
}