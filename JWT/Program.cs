using JWT;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TodoContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Database"))
);

builder.Services.AddIdentityCore<User>(
    opt =>
    {
        opt.Password.RequiredLength = 6;
        opt.Password.RequireDigit = true;
        opt.Password.RequireUppercase = false;
        opt.Password.RequireLowercase = false;
        opt.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
        opt.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
    }
);
builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<TodoContext>().AddDefaultTokenProviders().AddUserManager<UserManager<User>>().AddRoleManager<RoleManager<Role>>();


// IdentityBuilder identityBuilder = new IdentityBuilder(typeof(User), typeof(Role), builder.Services);

// identityBuilder.AddEntityFrameworkStores<TodoContext>().AddDefaultTokenProviders().AddUserManager<UserManager<User>>().AddRoleManager<RoleManager<Role>>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
