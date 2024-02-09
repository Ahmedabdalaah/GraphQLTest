using GraphQLTest.Models;

namespace GraphQLTest.graphQl
{
    public class ProductQueryTypes
    {
        public async Task<List<Product>> GetProductListAsync([Service] IProductServices productService)
        {
            return await productService.GetProductsAsync();
        }

        public async Task<Product> GetProductDetailsByIdAsync([Service] IProductServices productService, Guid productId)
        {
            return await productService.GetProductById(productId);
        }
    }
}
