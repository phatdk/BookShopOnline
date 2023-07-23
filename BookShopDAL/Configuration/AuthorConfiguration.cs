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
	public class AuthorConfiguration : IEntityTypeConfiguration<Author>
	{
		public void Configure(EntityTypeBuilder<Author> builder)
		{
			builder.ToTable("Author");
			builder.HasKey(x => x.Id);

			builder.Property(c => c.Name).HasColumnType("nvarchar(50)");
			builder.Property(c => c.Index).IsRequired(false);
			builder.Property(c => c.Gender).IsRequired(false);
			builder.Property(c => c.Birth).HasColumnType("varchar(13)").IsRequired(false);
			builder.Property(c => c.Address).HasColumnType("nvarchar(100)").IsRequired(false);
		}
	}
}
