using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Services
{
    public interface ICategoryService
    {
        public Category? Get(int id);
        public List<Category> GetAll();
    }
}