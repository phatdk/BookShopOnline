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
	public class ImageConfiguration : IEntityTypeConfiguration<Image>
	{
		public void Configure(EntityTypeBuilder<Image> builder)
		{
			builder.ToTable("Image");
			builder.HasKey(x => x.Id);

			builder.Property(c => c.ImageUrl).HasColumnType("nvarchar(100)");
			builder.Property(c => c.Index).IsRequired(false);

			builder.HasOne<Shop>(c=>c.shop).WithMany(c=>c.images).HasForeignKey(c=>c.Id_Parents).OnDelete(DeleteBehavior.NoAction);
			builder.HasOne<Book>(c=>c.book).WithMany(c=>c.images).HasForeignKey(c=>c.Id_Parents).OnDelete(DeleteBehavior.NoAction);
		}
	}
}
