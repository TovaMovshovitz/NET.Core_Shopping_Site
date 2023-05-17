using entities;

namespace Repository
{
    public interface IProductRepository
    {
        Task<Product> AddProduct(Product newProduct);
        Task<List<Product>> GetAllProducts(string name, List<int> categoryIds, int? minPrice, int? maxPrice);
        Task<Product> GetProductById(int id);
    }
}