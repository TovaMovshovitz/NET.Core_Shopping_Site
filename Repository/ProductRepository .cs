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

        public async Task<List<Product>> GetAllProducts(string name, List<int> categoryIds, int minPrice, int maxPrice)
        {
            return await _MyShopContext.Products.Include(product=> product.Category).ToListAsync();
        }

    }
}
