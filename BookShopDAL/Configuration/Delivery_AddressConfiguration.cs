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
	public class Delivery_AddressConfiguration : IEntityTypeConfiguration<Delivery_Address>
	{
		public void Configure(EntityTypeBuilder<Delivery_Address> builder)
		{
			builder.ToTable(nameof(Delivery_Address));
			builder.HasKey(x => x.Id);

			builder.Property(c => c.Address).HasColumnType("nvarchar(100)");

			builder.HasOne<Customer>(c => c.customer).WithMany(c=>c.delivery_Addresses).HasForeignKey(c=>c.Id_Customer).OnDelete(DeleteBehavior.Cascade);
		}
	}
}
