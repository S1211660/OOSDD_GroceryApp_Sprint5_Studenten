using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Services
{
    public interface IProductCategoryService
    {
        public List<Product> GetProductsByCategory(int categoryId);
        public List<ProductCategory> GetAll();
    }
}