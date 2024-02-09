using GraphQLTest.Models;

namespace GraphQLTest
{
    public interface IProductServices
    {
        public Task<List<Product>> GetProductsAsync();
        public Task<Product> GetProductById(Guid id);
        public Task<bool> AddProductAsync(Product product);
        public Task<bool> UpdateProduct(Product product);
        public Task<bool> DeleteProduct(Guid id);
    }
}
