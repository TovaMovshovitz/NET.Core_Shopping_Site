using entities;
using Repository;
using Zxcvbn;


namespace Service
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository) => _productRepository = productRepository;


        public async Task<Product> AddProduct(Product newProduct)
        {
            return await _productRepository.AddProduct(newProduct);
        }

        public async Task<List<Product>> GetAllProducts(string name, List<int> categoryIds, int? minPrice, int? maxPrice)
        {
            return await _productRepository.GetAllProducts(name, categoryIds, minPrice, maxPrice);
        }

    }
}
