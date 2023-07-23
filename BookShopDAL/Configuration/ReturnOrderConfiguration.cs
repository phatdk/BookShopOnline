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
	public class ReturnOrderConfiguration : IEntityTypeConfiguration<ReturnOrder>
	{
		public void Configure(EntityTypeBuilder<ReturnOrder> builder)
		{
			builder.ToTable(nameof(ReturnOrderConfiguration));
			builder.HasKey(c => c.Id);

			builder.Property(c => c.Notes).HasColumnType("nvarchar(256)");

			builder.HasOne<Order>(c=>c.order).WithMany(c=>c.returnOrders).HasForeignKey(c=>c.Id_Order).OnDelete(DeleteBehavior.Cascade);
		}
	}
}
