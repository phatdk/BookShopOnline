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
	public class Customer_PromotionConfiguration : IEntityTypeConfiguration<Customer_Promotion>
	{
		public void Configure(EntityTypeBuilder<Customer_Promotion> builder)
		{
			builder.ToTable(nameof(Customer_Promotion));
			builder.HasKey(c => new { c.Id_Customer, c.Id_Promotion });

			builder.Property(c=>c.EndDate).IsRequired(false);

			builder.HasOne<Customer>(c => c.customer).WithMany(c => c.customer_Promotions).HasForeignKey(c=>c.Id_Customer).OnDelete(DeleteBehavior.Cascade);
			builder.HasOne<Promotion>(c => c.promotion).WithMany(c => c.customer_Promotions).HasForeignKey(c=>c.Id_Promotion).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
