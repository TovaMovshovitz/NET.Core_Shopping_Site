using System.Text.Json;
using entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        MyShop213354335Context _MyShopContext;

        public ProductRepository(MyShop213354335Context myShopContext)=> _MyShopContext = myShopContext;
        
        public async Task<Product> AddProduct(Product newProduct)
        {
            await _MyShopContext.Products.AddAsync(newProduct);
            await _MyShopContext.SaveChangesAsync();
            return newProduct;
        } 

        public async Task<List<Product>> GetAllProducts(string name, List<int> categoryIds, int? minPrice, int? maxPrice)
        {
            var query = _MyShopContext.Products.Include(product=>product.Category).Where(product =>
            
                (minPrice == null || product.Price >= minPrice) &&
                (maxPrice == null || product.Price <= maxPrice) &&
                (name == null || product.Name.Contains(name)|| product.Description.Contains(name)) &&
                (categoryIds.Count ==0 || categoryIds.Contains(product.CategoryId))
 
            ).OrderBy(product=>product.Name);
            return await query.ToListAsync();
            
        }

    }
}
