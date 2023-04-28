using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Entry
{
	public class MyDesignTimeDbContextFactory:IDesignTimeDbContextFactory<MyDbContext>
	{
        //  分层需要重新构建
        //  EF开发环境分层 (需要我不懂为什么要这么麻烦)
        public MyDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<MyDbContext> builder = new();
            //string conStr = Environment.GetEnvironmentVariable("ConnectionStrings:DatabaseContext");

            builder.UseSqlServer("Server=localhost;Database=Test;TrustServerCertificate=True;User ID=sa;Password=Sqlserver123");
            return new MyDbContext(builder.Options);
        }
    }
}

