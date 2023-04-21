using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace one_to_many
{
	public class OrgUnitConfig :IEntityTypeConfiguration<OrgUnit>
	{
        public void Configure(EntityTypeBuilder<OrgUnit> builder)
        {
            builder.ToTable("T_OrgUnits");
            builder.Property(o => o.Name).IsUnicode().IsRequired().HasMaxLength(200);

            // 跟节点没有parent,因此这个关系不能修饰为“不可为空”
            builder.HasOne<OrgUnit>(o => o.Parent).WithMany(o => o.Children).OnDelete(DeleteBehavior.NoAction);
        }
    }
}

