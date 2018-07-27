using System.ComponentModel;
using System.Runtime.CompilerServices;
using GreenGoblin.WindowsFormApplication.Models;

namespace GreenGoblin.WindowsFormApplication.ViewModels
{
    public class ManageCatergoriesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public BindingList<CategoryModel> Cateorgies => _categories ?? (_categories = new BindingList<CategoryModel>());

        public bool Editing
        {
            get => _editing;
            set
            {
                _editing = value;
                OnPropertyChanged();
            }
        }

        public string NewCategoryName
        {
            get => _newCategoryName;
            set
            {
                _newCategoryName = value;
                OnPropertyChanged();
            }
        }

        public bool NotEditing => !Editing;

        public CategoryModel SelectedCategory { get; set; }

        public string SelectedCategoryName
        {
            get => SelectedCategory.Name;
            set
            {
                SelectedCategory.Name = value;
                OnPropertyChanged();
            }
        }

        public void AddCategory()
        {
            if (string.IsNullOrEmpty(NewCategoryName))
            {
                return;
            }

            Cateorgies.Add(new CategoryModel(NewCategoryName));
            NewCategoryName = string.Empty;
        }

        public void CancelEdit()
        {
            Editing = false;
        }

        public void Delete()
        {
            Editing = false;
            if (SelectedCategory == null)
            {
                return;
            }
            Cateorgies.Remove(SelectedCategory);
        }

        public void Edit()
        {
            Editing = true;
        }

        public void SaveEdit()
        {
            Editing = false;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private BindingList<CategoryModel> _categories;
        private bool _editing;
        private string _newCategoryName;
    }
}