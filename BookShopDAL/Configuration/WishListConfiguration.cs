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
	public class WishListConfiguration : IEntityTypeConfiguration<WishList>
	{
		public void Configure(EntityTypeBuilder<WishList> builder)
		{
			builder.ToTable(nameof(WishList));
			builder.HasKey(c=> new {c.Id_Customer, c.Id_Book});

			builder.HasOne<Customer>(c=>c.customer).WithMany(c=>c.wishLists).HasForeignKey(c=>c.Id_Customer).OnDelete(DeleteBehavior.Cascade);
			builder.HasOne<Book>(c=>c.book).WithMany(c=>c.wishLists).HasForeignKey(c=>c.Id_Book).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
