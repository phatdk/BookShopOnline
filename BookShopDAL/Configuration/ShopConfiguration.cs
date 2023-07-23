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
	public class ShopConfiguration : IEntityTypeConfiguration<Shop>
	{
		public void Configure(EntityTypeBuilder<Shop> builder)
		{
			builder.ToTable("Shop");
			builder.HasKey(x => x.Id);

			builder.Property(c => c.ShopName).HasColumnType("nvarchar(50)");
			builder.Property(c => c.EmailAddress).HasColumnType("varchar(100)");
			builder.Property(c => c.Phones).HasColumnType("varchar(13)");
			builder.Property(c => c.Address).HasColumnType("nvarchar(100)");
			builder.Property(c => c.CreatedDate).HasColumnType("datetime");
		}
	}
}
