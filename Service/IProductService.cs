using entities;

namespace Service
{
    public interface IProductService
    {
        Task<Product> AddProduct(Product newProduct);
        Task<List<Product>> GetAllProducts(string name, List<int> categoryIds, int minPrice,int maxPrice);
    }
}