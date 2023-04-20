using System;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
	public class MyDbContext:DbContext
	{
        public DbSet<Rabbit> rabbits { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<Person> Person { get; set; }
        public DbSet<Song> Songs { get; set; }
        //public DbSet<Brid> Brids { get; set; }
        //public DbSet<Test> tests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            // select query log

            //optionsBuilder.LogTo(msg =>
            //{
            //    Console.WriteLine(msg);
            //});

            base.OnConfiguring(optionsBuilder);
        // database = DemoDb
        // Initial Catalog=Demodb
      optionsBuilder.UseSqlServer("Server=localhost;Database=Demo;TrustServerCertificate=True;User ID=sa;Password=Sqlserver123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //从当前程序集加载所有的IEntityTypeConcfiguration;

            // Rather than specifying the schema for each table, you can also define the default schema at the model level with the fluent API:
            // modelBuilder.HasDefaultSchema("demo");

modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}

