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
	public class Promotion_TypeConfiguration : IEntityTypeConfiguration<Promotion_Type>
	{
		public void Configure(EntityTypeBuilder<Promotion_Type> builder)
		{
			builder.ToTable(nameof(Promotion_Type));
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Name).HasColumnType("nvarchar(50)");
		}
	}
}
