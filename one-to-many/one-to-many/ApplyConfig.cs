using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace one_to_many
{
    public class ApplyConfig : IEntityTypeConfiguration<Apply>
    {
        public void Configure(EntityTypeBuilder<Apply> builder)
        {
            builder.ToTable("T_Applies");
            builder.HasOne<User>(l => l.Requester).WithMany();
            builder.HasOne<User>(l => l.Approver).WithMany();
            builder.Property(l => l.Remark).HasMaxLength(200).IsUnicode();
        }
    }
}

