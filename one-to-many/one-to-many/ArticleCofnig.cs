using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace one_to_many
{
	public class ArticleCofnig:IEntityTypeConfiguration<Article>
	{
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("T_Articles");
            builder.Property(a => a.Title).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Content).HasMaxLength(500).IsRequired();
        }
    }
}

