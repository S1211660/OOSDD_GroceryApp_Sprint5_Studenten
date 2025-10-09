using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IProductRepository _productRepository;

        public ProductCategoryService(
            IProductCategoryRepository productCategoryRepository,
            IProductRepository productRepository)
        {
            _productCategoryRepository = productCategoryRepository;
            _productRepository = productRepository;
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            var productCategories = _productCategoryRepository.GetAll()
                .Where(pc => pc.CategoryId == categoryId)
                .ToList();

            var products = new List<Product>();
            foreach (var pc in productCategories)
            {
                var product = _productRepository.Get(pc.ProductId);
                if (product != null)
                {
                    products.Add(product);
                }
            }

            return products;
        }

        public List<Product> GetProductsNotInCategory(int categoryId)
        {
            var allProducts = _productRepository.GetAll();
            var inCat = GetProductsByCategory(categoryId).Select(p => p.Id).ToHashSet();
            return allProducts.Where(p => !inCat.Contains(p.Id)).ToList();
        }

        public ProductCategory AddProductToCategory(int categoryId, int productId)
        {
            var all = _productCategoryRepository.GetAll();
            int nextId = (all.Any() ? all.Max(pc => pc.Id) : 0) + 1;
            var mapping = new ProductCategory(nextId, categoryId, productId);
            return _productCategoryRepository.Add(mapping);
        }

        public List<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }
    }
}
