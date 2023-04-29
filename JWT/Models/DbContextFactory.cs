using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace JWT;

public class DbContextFactory : IDesignTimeDbContextFactory<TodoContext>
{
    // Unable to create an object of type 'TodoContext'
    public TodoContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<TodoContext> builder = new DbContextOptionsBuilder<TodoContext>();

        builder.UseSqlServer("Server=49.235.117.63;Database=Blog;TrustServerCertificate=True;User ID=sa;Password=zzm11.21");

        return new TodoContext(builder
        .Options);
    }
}