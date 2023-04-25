using entities;

namespace Service
{
    public interface ICategoryService
    {
        Task<Category> AddCaregory(Category newCategory);
        Task<List<Category>> GetAllCategories();
    }
}