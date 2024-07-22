
global using CurrieTechnologies.Razor.SweetAlert2;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using PRN221.Tools;
using Repository.Repository;
using Repository.Repository.Interface;
using Service;
using Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<PRNDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDB"));
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddAutoMapper(typeof(Mapper));

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IOrderXProductRepository, OrderXProductRepository>();
builder.Services.AddScoped<IOrderXProductService, OrderXProductService>();

builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IBlogService, BlogService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddScoped<IVoucherRepository, VoucherRepository>();
builder.Services.AddScoped<IVoucherService, VoucherService>();


builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
builder.Services.AddScoped<IProductTypeService, ProductTypeService>();

builder.Services.AddScoped<IStatisticsService, StatisticsService>();
builder.Services.AddScoped<IStatisticsRepository, StatisticsRepository>();

// Add session services
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


builder.Services.AddScoped<IOrderXProductRepository, OrderXProductRepository>();
builder.Services.AddScoped<IOrderXProductService, OrderXProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

//Chuyển hướng đến Index.cshtml hoặc trang cụ thể khác
app.MapGet("/", context =>
{
    context.Response.Redirect("/AuthsPages/Login");
    return Task.CompletedTask;
});

//app.MapGet("/", context =>
//{
//    context.Response.Redirect("/Home");
//    return Task.CompletedTask;
//});


app.Run();
