using BookShopDAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopDAL.Configuration
{
	public class Order_BookConfiguration : IEntityTypeConfiguration<Order_Book>
	{
		public void Configure(EntityTypeBuilder<Order_Book> builder)
		{
			builder.ToTable(nameof(Order_Book));
			builder.HasKey(c => new { c.Id_Order, c.Id_Book });

			builder.HasOne<Order>(c => c.order).WithMany(c=>c.order_Books).HasForeignKey(c=>c.Id_Order).OnDelete(DeleteBehavior.Cascade);
			builder.HasOne<Book>(c => c.book).WithMany(c=>c.order_Books).HasForeignKey(c=>c.Id_Book).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
