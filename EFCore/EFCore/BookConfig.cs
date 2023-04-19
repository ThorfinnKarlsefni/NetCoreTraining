using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("T_books");

            builder.Property(b => b.AuthorName).HasMaxLength(50).IsRequired();
            builder.Property(b => b.Titile).HasMaxLength(255).IsRequired();
        }
    }
}

