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
	public class GenreConfiguration : IEntityTypeConfiguration<Genre>
	{
		public void Configure(EntityTypeBuilder<Genre> builder)
		{
			builder.ToTable("Genre");
			builder.HasKey(x => x.Id);

			builder.Property(c => c.Name).HasColumnType("nvarchar(50)");
			builder.Property(c => c.Index).IsRequired(false);
			builder.Property(c => c.Description).HasColumnType("nvarchar(256)").IsRequired(false);
			builder.Property(c => c.CreatedDate).HasColumnType("datetime");
		}
	}
}
