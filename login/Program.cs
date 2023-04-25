using Microsoft.EntityFrameworkCore;
using Repository;
using Service;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IUsersRepository, UserRepositorySql>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddTransient<IUsersService, UsersService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddControllers();
builder.Services.AddDbContext<MyShop213354335Context>(options => options.UseSqlServer("SRV2\\PUPILS;Initial Catalog=My_Shop_213354335;Integrated Security=True"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();
app.MapControllers();
app.Run();

//{
//    "date": "2023-04-16T14:55:41.423Z",
//  "sum": 966,
//  "userId": 9,
//  "orderItems":[
//{
//        "prouctId":1,
//"quantity": 15},
//{
//        "prouctId":1,
//"quantity": 46}

//]
//}

