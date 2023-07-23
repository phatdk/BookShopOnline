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
	public class Order_PromotionConfiguration : IEntityTypeConfiguration<Order_Promotion>
	{
		public void Configure(EntityTypeBuilder<Order_Promotion> builder)
		{
			builder.ToTable(nameof(Order_Promotion));
			builder.HasKey(c => new { c.Id_Order, c.Id_Promotion });

			builder.HasOne<Order>(c=>c.order).WithMany(c=>c.order_Promotions).HasForeignKey(c=>c.Id_Order).OnDelete(DeleteBehavior.Cascade);
			builder.HasOne<Promotion>(c=>c.promotion).WithMany(c=>c.order_Promotions).HasForeignKey(c=>c.Id_Promotion).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
