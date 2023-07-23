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
	public class Book_AuthorConfiguration : IEntityTypeConfiguration<Book_Author>
	{
		public void Configure(EntityTypeBuilder<Book_Author> builder)
		{
			builder.ToTable("Book_Author");
			builder.HasKey(c => new { c.Id_Book, c.Id_Author });

			builder.HasOne<Book>(c=>c.book).WithMany(c=>c.book_Authors).HasForeignKey(c=>c.Id_Book).OnDelete(DeleteBehavior.Restrict);
			builder.HasOne<Author>(c=>c.author).WithMany(c=>c.book_Authors).HasForeignKey(c=>c.Id_Author).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
