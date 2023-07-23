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
	public class CommentConfiguration : IEntityTypeConfiguration<Comment>
	{
		public void Configure(EntityTypeBuilder<Comment> builder)
		{
			builder.ToTable(nameof(Comment));
			builder.HasKey(x => x.Id);

			builder.Property(c => c.Content).HasColumnType("nvarchar(256)");

			builder.HasOne<Customer>(c=>c.customer).WithMany(c=>c.comments).HasForeignKey(c=>c.Id_Customer).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
			builder.HasOne<Book>(c=>c.book).WithMany(c=>c.comments).HasForeignKey(c=>c.Id_Book).OnDelete(DeleteBehavior.NoAction);
			builder.HasOne<Evaluate>(c=>c.evaluate).WithMany(c=>c.comments).HasForeignKey(c=>c.Id_Parents).OnDelete(DeleteBehavior.NoAction);
			builder.HasOne<Comment>(c=>c.comment).WithMany(c=>c.comments).HasForeignKey(c=>c.Id_Parents).OnDelete(DeleteBehavior.NoAction);
		}
	}
}
