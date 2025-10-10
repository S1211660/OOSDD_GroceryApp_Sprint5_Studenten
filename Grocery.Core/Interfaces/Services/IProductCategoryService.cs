using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Services
{
    public interface IProductCategoryService
    {
        public List<Product> GetProductsByCategory(int categoryId);
        public List<Product> GetProductsNotInCategory(int categoryId);
        public ProductCategory AddProductToCategory(int categoryId, int productId);
        public List<ProductCategory> GetAll();
    }
}
