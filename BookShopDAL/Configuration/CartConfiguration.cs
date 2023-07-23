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
	public class CartConfiguration : IEntityTypeConfiguration<Cart>
	{
		public void Configure(EntityTypeBuilder<Cart> builder)
		{
			builder.ToTable(nameof(Cart));
			builder.HasKey(c=> new {c.Id_Customer, c.Id_Book});

			builder.HasOne<Customer>(c=>c.customer).WithMany(c=>c.carts).HasForeignKey(c=>c.Id_Customer).OnDelete(DeleteBehavior.Cascade);
			builder.HasOne<Book>(c=>c.book).WithMany(c=>c.carts).HasForeignKey(c=>c.Id_Book).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
