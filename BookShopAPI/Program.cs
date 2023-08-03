using BookShopBLL.AutoMapper;
using BookShopBLL.IService;
using BookShopBLL.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IAdminService, AdminService>();
builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddTransient<IBook_AuthorService, Book_AuthorService>();
builder.Services.AddTransient<IBook_PromotionService, Book_PromotionService>();
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<ICartService, CartService>();
builder.Services.AddTransient<ICollection_BookService, Collection_BookServive>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<ICustomer_PromotionService, Customer_PromotionService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IDelivery_AddressService, Delivery_AddressService>();
builder.Services.AddTransient<IEvaluateService, EvaluateService>();
builder.Services.AddTransient<IGenreService, GenreService>();
builder.Services.AddTransient<IImageService, ImageService>();
builder.Services.AddTransient<INewsService, NewsService>();
builder.Services.AddTransient<IOrder_BookService, Order_BookService>();
builder.Services.AddTransient<IOrder_PromotionService, Order_PromotionService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IPayment_FormService, Payment_FormService>();
builder.Services.AddTransient<IPromotion_TypeService, Promotion_TypeService>();
builder.Services.AddTransient<IPromotionService, PromotionService>();
builder.Services.AddTransient<IPublisherService, PublisherService>();
builder.Services.AddTransient<IReturnOrderService, ReturnOrderService>();
builder.Services.AddTransient<IShopService, ShopService>();
builder.Services.AddTransient<IWishListService, WishListService>();

builder.Services.AddAutoMapper(typeof(ProjectMapper).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
