using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository;
using Service;
using AutoMapper;
using NLog.Web;
using static System.Runtime.InteropServices.JavaScript.JSType;
using MyShop;

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

app.UseRatingMiddleware();
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();
app.MapControllers();
app.Run();

