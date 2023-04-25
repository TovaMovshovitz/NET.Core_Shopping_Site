using System.Text.Json;
using entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        MyShop213354335Context _MyShopContext;

        public CategoryRepository(MyShop213354335Context myShopContext)=>_MyShopContext = myShopContext;
       
        public async Task<Category> AddCaregory(Category newCategory)
        {
            await _MyShopContext.Categories.AddAsync(newCategory);
            await _MyShopContext.SaveChangesAsync();
            return newCategory;
        }

        public async Task<List<Category>> GetAllCategories()=>await _MyShopContext.Categories.ToListAsync();




    }
}
