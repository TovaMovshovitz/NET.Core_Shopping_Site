using Microsoft.EntityFrameworkCore;
using Repository;
using Service;
using NLog.Web;
using MyShop.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseNLog();
// Add services to the container.
builder.Services.AddTransient<IUsersRepository, UserRepositorySql>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IRatingRepository, RatingRepository>();

builder.Services.AddTransient<IUsersService, UsersService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IRatingService, RatingService>();
builder.Services.AddTransient<IPasswordStrengthService, PasswordStrengthService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();              
builder.Services.AddDbContext<MyShop213354335Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Ikea")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHandleErrorMiddleware();
app.UseRatingMiddleware();
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();
app.MapControllers();

app.Use(async (context, next) =>
{
    await next(context);
    if (context.Response.StatusCode == 404)
    {
        context.Response.ContentType = "text/html";
        await context.Response.SendFileAsync("./wwwroot/404Page.html");
    }
});

app.Run();

