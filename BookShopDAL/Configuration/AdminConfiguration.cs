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
	public class AdminConfiguration : IEntityTypeConfiguration<Admin>
	{
		public void Configure(EntityTypeBuilder<Admin> builder)
		{
			builder.ToTable("Admin");
			builder.HasKey(x => x.Id);

			builder.Property(c => c.Email).HasColumnType("varchar(50)");
			builder.Property(c => c.Password).HasColumnType("varchar(50)");
		}
	}
}
