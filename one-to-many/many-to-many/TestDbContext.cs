using System;
using Microsoft.EntityFrameworkCore;

namespace many_to_many
{
	public class TestDbContext :DbContext
	{
		public DbSet<Student> Students { get; set; }
		public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Blog;TrustServerCertificate=True;User ID=sa;Password=Sqlserver123");
            //optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}

