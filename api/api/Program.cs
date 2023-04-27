using api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<Calculator>();
// register memory
builder.Services.AddMemoryCache();

string[] urls = new[] { "http://localhost:5173" };

builder.Services.AddCors(
    options => options.AddDefaultPolicy(
        builder => builder.WithOrigins(urls).AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

// 启用服务器缓存 设置注意
// 确保app.MapControllers之前加上app.UseResponseCaching
// 确保在app.UseCors(); 之后
// 相应200的GET和HEADER 才可能会被缓存 POST请求响应不能被缓存
// 报文头authorization set-cookie等
// 服务器响应缓存鸡肋 不推荐使用
 
// app.UseResponseCaching
app.UseResponseCaching();

// app.MapControllers
app.MapControllers();

app.Run();

