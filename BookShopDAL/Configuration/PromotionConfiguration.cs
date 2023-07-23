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
	public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
	{
		public void Configure(EntityTypeBuilder<Promotion> builder)
		{
			builder.ToTable(nameof(Promotion));
			builder.HasKey(x => x.Id);

			builder.Property(c => c.Name).HasColumnType("nvarchar(50)");
			builder.Property(c => c.Code).HasColumnType("nvarchar(13)");
			builder.Property(c => c.Condition).IsRequired(false);
			builder.Property(c => c.ReduceAmount).IsRequired(false);
			builder.Property(c => c.ReduceRate).IsRequired(false);
			builder.Property(c => c.EndDate).IsRequired(false);
			builder.Property(c => c.Description).HasColumnType("nvarchar(256)").IsRequired(false);

			builder.HasOne<Promotion_Type>(c=>c.promotion_Type).WithMany(c=>c.promotions).HasForeignKey(c=>c.Id_PromotionType).OnDelete(DeleteBehavior.Cascade);
		}
	}
}
