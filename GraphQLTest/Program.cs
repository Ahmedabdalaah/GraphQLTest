using GraphQLTest;
using GraphQLTest.Data;
using GraphQLTest.graphQl;
using GraphQLTest.Mutation_Type;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Register Service
builder.Services.AddScoped<IProductServices, ProductServices>();
//InMemory Database
builder.Services.AddDbContext<APPDBContext>(o => o.UseInMemoryDatabase("dbATest"));
//GraphQL Config
builder.Services.AddGraphQLServer().AddQueryType<ProductQueryTypes>().AddMutationType<ProductMutations>();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//GraphQL
app.MapGraphQL();

app.Run();
