using System;
using Microsoft.EntityFrameworkCore;

namespace Entry
{
    public class MyDbContext : DbContext
    {
        private DbSet<User.User> users;

        public MyDbContext(DbContextOptions<MyDbContext> options):base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
       modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}

