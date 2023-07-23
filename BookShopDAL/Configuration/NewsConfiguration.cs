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
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.ToTable(nameof(News));
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Title).HasColumnType("nvarchar(100)");
            builder.Property(c => c.Content).HasColumnType("nvarchar(max)");
            builder.Property(c => c.Description).HasColumnType("nvarchar(256)").IsRequired(false);
        }
    }
}
