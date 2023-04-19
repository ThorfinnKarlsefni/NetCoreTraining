using System;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
	public class MyDbContext:DbContext
	{
		public DbSet<Book> Books { get; set; }
		public DbSet<Person> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        // database = DemoDb
        // Initial Catalog=Demodb
         optionsBuilder.UseSqlServer("Server=localhost;Database=demo;TrustServerCertificate=True;User ID=sa;Password=Sqlserver123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //从当前程序集加载所有的IEntityTypeConcfiguration;
             modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}

