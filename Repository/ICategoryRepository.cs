using entities;

namespace Repository
{
    public interface ICategoryRepository
    {
        Task<Category> AddCaregory(Category newCategory);
        Task<List<Category>> GetAllCategories();
    }
}