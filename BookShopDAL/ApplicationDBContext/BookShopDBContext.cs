using BookShopDAL.Configuration;
using BookShopDAL.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookShopDAL.ApplicationDBContext
{
	public class BookShopDBContext : DbContext /*IdentityDbContext<IdentityUser>*/
	{
		public BookShopDBContext() { }
		public BookShopDBContext(DbContextOptions options) : base(options) { }
		
		public virtual DbSet<Admin> Admins { get; set; }
		public virtual DbSet<Author> Authors { get; set; }
		public virtual DbSet<Book> Books { get; set; }
		public virtual DbSet<Book_Author> Book_Authors { get; set; }
		public virtual DbSet<Book_Promotion> Book_Promotions { get; set; }
		public virtual DbSet<Cart> Carts { get; set; }
		public virtual DbSet<Collection_Book> Collection_Books { get; set; }
		public virtual DbSet<Comment> Comments { get; set; }
		public virtual DbSet<Customer> Customers { get; set; }
		public virtual DbSet<Customer_Promotion> Customer_Promotions { get; set; }
		public virtual DbSet<Delivery_Address> Delivery_Addresses { get; set; }
		public virtual DbSet<Evaluate> Evaluates { get; set; }
		public virtual DbSet<Genre> Genres { get; set; }
		public virtual DbSet<Image> Images { get; set; }
		public virtual DbSet<News> News { get; set; }
		public virtual DbSet<Order> Orders { get; set; }
		public virtual DbSet<Order_Book> Order_Books { get; set; }
		public virtual DbSet<Order_Promotion> Order_Promotions { get; set; }
		public virtual DbSet<Payment_Form> Payment_Forms { get; set; }
		public virtual DbSet<Promotion> Promotions { get; set; }
		public virtual DbSet<Promotion_Type> Promotion_Types { get; set; }
		public virtual DbSet<Publisher> Publishers { get; set; }
		public virtual DbSet<ReturnOrder> ReturnOrders { get; set; }
		public virtual DbSet<Shop> Shops { get; set; }
		public virtual DbSet<WishList> WishLists { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Data Source=DESKTOP-L9TSC4C\\SQLEXPRESS;Initial Catalog=BookShop;Integrated Security=True; Encrypt = True; TrustServerCertificate = True;");
			}
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
