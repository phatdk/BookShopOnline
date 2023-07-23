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
	public class BrandConfiguration : IEntityTypeConfiguration<Brand>
	{
		public void Configure(EntityTypeBuilder<Brand> builder)
		{
			builder.ToTable("Brand");
			builder.HasKey(c => c.Id);

			builder.Property(c => c.Name).HasColumnType("nvarchar(50)");
			builder.Property(c => c.Description).HasColumnType("nvarchar(256)").IsRequired(false);
		}
	}
}
