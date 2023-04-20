using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace one_to_many
{
	public class CommentConfig :IEntityTypeConfiguration<Comment>
	{
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("T_Comments");
            builder.Property(a => a.Message).IsRequired().HasMaxLength(100);

            builder.HasOne<Article>(c => c.Article).WithMany(c => c.Comments).IsRequired().HasForeignKey(c => c.ArticleId);
        }
    }
}

