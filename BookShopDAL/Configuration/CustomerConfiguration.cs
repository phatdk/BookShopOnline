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
	public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
	{
		public void Configure(EntityTypeBuilder<Customer> builder)
		{
			builder.ToTable(nameof(Customer));
			builder.HasKey(c => c.Id);

			builder.Property(c => c.Name).HasColumnType("nvarchar(50)");
			builder.Property(c => c.Gender).IsRequired(false);
			builder.Property(c => c.Birth).IsRequired(false);
			builder.Property(c => c.Address).HasColumnType("nvarchar(100)");
			builder.Property(c => c.Phones).HasColumnType("nvarchar(13)");
			builder.Property(c => c.Email).HasColumnType("nvarchar(50)");
			builder.Property(c => c.Password).HasColumnType("nvarchar(50)");
		}
	}
}
