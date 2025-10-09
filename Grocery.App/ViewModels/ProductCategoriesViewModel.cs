using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.App.ViewModels
{
    [QueryProperty(nameof(CategoryId), "categoryId")]
    [QueryProperty(nameof(CategoryName), "categoryName")]
    public partial class ProductCategoriesViewModel : BaseViewModel
    {
        private readonly IProductCategoryService _productCategoryService;
        private ObservableCollection<Product> _inCategory = new();
        private ObservableCollection<Product> _available = new();
        private ObservableCollection<Product> _filteredAvailable = new();
        private string _categoryName = string.Empty;
        private int _categoryId;
        private string _searchText = string.Empty;

        public int CategoryId
        {
            get => _categoryId;
            set
            {
                _categoryId = value;
                OnPropertyChanged();
                LoadProducts();
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

        public ObservableCollection<Product> InCategory
        {
            get => _inCategory;
            set
            {
                _inCategory = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Product> Available
        {
            get => _available;
            set
            {
                _available = value;
                OnPropertyChanged();
                ApplyFilter();
            }
        }

        public ObservableCollection<Product> FilteredAvailable
        {
            get => _filteredAvailable;
            set
            {
                _filteredAvailable = value;
                OnPropertyChanged();
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                ApplyFilter();
            }
        }

        public ProductCategoriesViewModel(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        private void LoadProducts()
        {
            var inCat = _productCategoryService.GetProductsByCategory(CategoryId);
            InCategory = new ObservableCollection<Product>(inCat);

            var notInCat = _productCategoryService.GetProductsNotInCategory(CategoryId);
            Available = new ObservableCollection<Product>(notInCat);
        }

        private void ApplyFilter()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                FilteredAvailable = new ObservableCollection<Product>(Available);
            }
            else
            {
                var q = SearchText.Trim().ToLowerInvariant();
                FilteredAvailable = new ObservableCollection<Product>(
                    Available.Where(p => p.Name.ToLowerInvariant().Contains(q))
                );
            }
        }

        [RelayCommand]
        private void AddToCategory(Product? product)
        {
            if (product == null) return;

            _productCategoryService.AddProductToCategory(CategoryId, product.Id);
            Available.Remove(product);
            InCategory.Add(product);
            ApplyFilter();
        }
    }
}
