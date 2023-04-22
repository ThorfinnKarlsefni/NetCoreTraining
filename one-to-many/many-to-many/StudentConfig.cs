using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace many_to_many
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("T_Students");
            builder.Property(s => s.Name).IsUnicode().HasMaxLength(200);
            builder.HasMany<Teacher>(s => s.Teachers)
                .WithMany(t => t.Students)
                .UsingEntity(j => j.ToTable("T_Student_and_Teacher"));
        }
    }
}

