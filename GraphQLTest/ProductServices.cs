using GraphQLTest.Data;
using GraphQLTest.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLTest
{
    public class ProductServices : IProductServices
    {
        private readonly IWebHostEnvironment _env;
        private readonly APPDBContext dbContextClass;
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGraphQLServer()
            // You can change _env.IsDevelopment() to whatever condition you want.
            // If the condition evaluates to true, the server will expose it's exceptions details
            // within the reponse.
            .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = _env.IsDevelopment());
        }
        public ProductServices(APPDBContext dbContextClass)
        {
            this.dbContextClass = dbContextClass;
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            await dbContextClass.products.AddAsync(product);
            var result = await dbContextClass.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            var findProductData = dbContextClass.products.Where(x => x.Id.Equals(id)).FirstOrDefault();
            if (findProductData != null)
            {
                dbContextClass.products.Remove(findProductData);
                var result = await dbContextClass.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<Product> GetProductById(Guid id)
        {
            return await dbContextClass.products.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await dbContextClass.products.ToListAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var isProduct = ProductDetailsExists(product.Id);
            if (isProduct)
            {
                dbContextClass.products.Update(product);
                var result = await dbContextClass.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
    }

        private bool ProductDetailsExists(int id)
        {
            return dbContextClass.products.Any(e => e.Id == id);

        }
    }
 
}
