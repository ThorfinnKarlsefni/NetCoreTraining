using System;
using Microsoft.EntityFrameworkCore;

namespace one_to_many
{
	public class MyDbContext:DbContext
	{
		public DbSet<Article> Articles { get; set; }
		public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Apply> Applies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            string str = "Server=localhost;Database=Blog;TrustServerCertificate=True;User ID=sa;Password=Sqlserver123";
            optionsBuilder.UseSqlServer(str);
            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

    }
}

