using BookShop.Web.Blazor.Authentication;
using BookShop.Web.Blazor.Data;
using BookShop.Web.Blazor.Service;
using BookShopBLL.AutoMapper;
//using BookShopBLL.IService;
//using BookShopBLL.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthenticationCore();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
//test
builder.Services.AddSingleton<UserService>();

builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
// sevice
builder.Services.AddScoped<AdminService>();
builder.Services.AddScoped<AuthorService>();
builder.Services.AddScoped<Book_AuthorService>();
builder.Services.AddScoped<Book_PromotionService>();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<BrandService>();
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<Collection_BookService>();
builder.Services.AddScoped<CommentService>();
builder.Services.AddScoped<Customer_PromotionService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<Delivery_AddresService>();
builder.Services.AddScoped<EvaluateService>();
builder.Services.AddScoped<GenreService>();
builder.Services.AddScoped<ImageService>();
builder.Services.AddScoped<NewsService>();
builder.Services.AddScoped<Order_BookService>();
builder.Services.AddScoped<Order_PromotionService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<Payment_FormService>();
builder.Services.AddScoped<Promotion_TypeService>();
builder.Services.AddScoped<PromotionService>();
builder.Services.AddScoped<PublisherService>();
builder.Services.AddScoped<ReturnOrderService>();
builder.Services.AddScoped<ShopService>();
builder.Services.AddScoped<WishListService>();

builder.Services.AddAutoMapper(typeof(ProjectMapper).Assembly);
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
