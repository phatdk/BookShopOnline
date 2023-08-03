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
	partial class BookConfiguration : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{
			builder.ToTable("Book");
			builder.HasKey(x => x.Id);

			builder.Property(c => c.ISBN).HasColumnType("varchar(50)").IsRequired(false);
			builder.Property(c => c.Title).HasColumnType("nvarchar(100)");
			builder.Property(c => c.Reader).HasColumnType("nvarchar(50)");
			builder.Property(c => c.PublicationDate).HasColumnType("datetime");
			builder.Property(c => c.PageSize).HasColumnType("varchar(20)");
			builder.Property(c => c.Cover).HasColumnType("nvarchar(20)");
			builder.Property(c => c.Description).HasColumnType("nvarchar(256)").IsRequired(false);

			builder.HasOne<Publisher>(c => c.publisher).WithMany(c => c.books).HasForeignKey(c => c.Id_Publisher).OnDelete(DeleteBehavior.Restrict);
			builder.HasOne<Genre>(c => c.genre).WithMany(c => c.books).HasForeignKey(c => c.Id_Genre).OnDelete(DeleteBehavior.Restrict);
			builder.HasOne<Collection_Book>(c=>c.collection_Book).WithMany(c=>c.books).HasForeignKey(c=>c.Id_Collection).OnDelete(DeleteBehavior.Restrict).IsRequired(false);
		}
	}
}
