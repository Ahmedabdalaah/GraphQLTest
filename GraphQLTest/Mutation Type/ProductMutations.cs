using GraphQLTest.Models;

namespace GraphQLTest.Mutation_Type
{
    public class ProductMutations
    {
        public async Task<bool> AddProductAsync([Service] IProductServices productService,Product productDetails)
        {
            return await productService.AddProductAsync(productDetails);
        }

        public async Task<bool> UpdateProductAsync([Service] IProductServices productService,Product productDetails)
        {
            return await productService.UpdateProduct(productDetails);
        }

        public async Task<bool> DeleteProductAsync([Service] IProductServices productService,Guid productId)
        {
            return await productService.DeleteProduct(productId);
        }
    }
}
