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
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.ToTable(nameof(Order));
			builder.HasKey(c => c.Id);

			builder.Property(c => c.Code).HasColumnType("varchar(13)");
			builder.Property(c => c.Receiver).HasColumnType("nvarchar(50)");
			builder.Property(c => c.Phones).HasColumnType("varchar(13)");
			builder.Property(c => c.AcceptDate).IsRequired(false);
			builder.Property(c => c.DeliveryDate).IsRequired(false);
			builder.Property(c => c.ReceiveDate).IsRequired(false);
			builder.Property(c => c.PaymentDate).IsRequired(false);
			builder.Property(c => c.CompleteDate).IsRequired(false);
			builder.Property(c => c.ModifyDate).IsRequired(false);
			builder.Property(c => c.ModifyNotes).HasColumnType("nvarchar(256)").IsRequired(false);

			builder.HasOne<Delivery_Address>(c => c.delivery_address).WithMany(c => c.orders).HasForeignKey(c => c.Id_Address).OnDelete(DeleteBehavior.NoAction);
			builder.HasOne<Customer>(c => c.customer).WithMany(c => c.orders).HasForeignKey(c => c.Id_Customer).OnDelete(DeleteBehavior.NoAction);
			builder.HasOne<Payment_Form>(c => c.payment_Form).WithMany(c => c.orders).HasForeignKey(c => c.Id_PaymentForm).OnDelete(DeleteBehavior.NoAction);
		}
	}
}
