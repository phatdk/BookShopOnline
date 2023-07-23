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
	public class EvaluateConfiguration : IEntityTypeConfiguration<Evaluate>
	{
		public void Configure(EntityTypeBuilder<Evaluate> builder)
		{
			builder.ToTable(nameof(Evaluate));
			builder.HasKey(x => x.Id);

			builder.Property(c=>c.Content).HasColumnType("nvarchar(256)").IsRequired(false);

			builder.HasOne<Customer>(c=>c.customer).WithMany(c=>c.evaluates).HasForeignKey(c=>c.Id_Customer).OnDelete(DeleteBehavior.NoAction);
			builder.HasOne<Book>(c=>c.book).WithMany(c=>c.evaluates).HasForeignKey(c=>c.Id_Book).OnDelete(DeleteBehavior.Cascade);
		}
	}
}
