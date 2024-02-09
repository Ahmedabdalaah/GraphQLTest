using GraphQLTest.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLTest.Data
{
    public class APPDBContext : DbContext
    {
        public APPDBContext(DbContextOptions<APPDBContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Connetion.source);
        }
        public DbSet<Product> products { get; set; }
    }
}
