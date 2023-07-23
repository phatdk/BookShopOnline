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
	public class Collection_BookConfiguration : IEntityTypeConfiguration<Collection_Book>
	{
		public void Configure(EntityTypeBuilder<Collection_Book> builder)
		{
			builder.ToTable(nameof(Collection_Book));
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Name).HasColumnType("nvarchar(50)");
		}
	}
}
