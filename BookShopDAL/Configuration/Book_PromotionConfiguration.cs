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
    public class Book_PromotionConfiguration : IEntityTypeConfiguration<Book_Promotion>
    {
        public void Configure(EntityTypeBuilder<Book_Promotion> builder)
        {
            builder.ToTable(nameof(Book_Promotion));
            builder.HasKey(c => new { c.Id_Promotion, c.Id_Book });

            builder.Property(c=>c.Index).IsRequired(false);

            builder.HasOne(c => c.book).WithMany(c => c.book_Promotions).HasForeignKey(c => c.Id_Book).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.promotion).WithMany(c => c.book_Promotions).HasForeignKey(c => c.Id_Promotion).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
