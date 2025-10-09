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

        public List<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }
    }
}