using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.App.ViewModels
{
    public partial class CategoriesViewModel : BaseViewModel
    {
        private readonly ICategoryService _categoryService;
        private ObservableCollection<Category> _categories = new();

        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }

        public ICommand CategoryTappedCommand { get; }

        public CategoriesViewModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            CategoryTappedCommand = new AsyncRelayCommand<Category>(OnCategoryTapped);
            LoadCategories();
        }

        private void LoadCategories()
        {
            var categories = _categoryService.GetAll();
            Categories = new ObservableCollection<Category>(categories);
        }

        private async Task OnCategoryTapped(Category? category)
        {
            if (category == null) return;

            await Shell.Current.GoToAsync($"ProductCategoriesView?categoryId={category.Id}&categoryName={category.Name}");
        }
    }
}