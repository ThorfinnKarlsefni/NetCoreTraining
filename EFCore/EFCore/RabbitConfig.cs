using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore
{
	public class RabbitConfig:IEntityTypeConfiguration<Rabbit>
    {
        public void Configure(EntityTypeBuilder<Rabbit> builder)
        {
            builder.ToTable("T_rabbits");
        }
    }
}

