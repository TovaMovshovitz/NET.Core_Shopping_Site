using entities;
using Repository;
using Zxcvbn;


namespace Service
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)=>_categoryRepository = categoryRepository;
       

        public async Task<Category> AddCaregory(Category newCategory)=>await _categoryRepository.AddCaregory(newCategory);


        public async Task<List<Category>> GetAllCategories() => await _categoryRepository.GetAllCategories();


    }
}
