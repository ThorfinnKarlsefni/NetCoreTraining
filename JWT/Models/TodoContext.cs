using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JWT;

public class TodoContext : IdentityDbContext<User, Role, long>
{
    public TodoContext(DbContextOptions<TodoContext> options) : base(options)
    {

    }
}