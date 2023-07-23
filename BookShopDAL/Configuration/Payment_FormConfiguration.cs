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
	public class Payment_FormConfiguration : IEntityTypeConfiguration<Payment_Form>
	{
		public void Configure(EntityTypeBuilder<Payment_Form> builder)
		{
			builder.ToTable(nameof(Payment_Form));
			builder.HasKey(p => p.Id);

			builder.Property(p => p.Name).HasColumnType("nvarchar(50)");
		}
	}
}
