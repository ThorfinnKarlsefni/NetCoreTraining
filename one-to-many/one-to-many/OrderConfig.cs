using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace one_to_many
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("T_Orders");
            builder.HasOne<Addresses>(a => a.Addresses)
                .WithOne(o => o.Order)
                .HasForeignKey<Order>(o => o.AddressId);
        }
    }
}

