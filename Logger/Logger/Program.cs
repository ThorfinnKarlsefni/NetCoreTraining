namespace Logger;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Serilog;
using Test2;
class Program
{
    static void Main(string[] args)
    {

        // log categories
        //Console.WriteLine("Hello, World!");
        ServiceCollection services = new ServiceCollection();
        //services.AddLogging(logBuilder =>
        //{
        //    logBuilder.AddConsole();
        //    //logBuilder.AddNLog();
        //    logBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Warning);
        //});


        // serilog


        Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Information()
           .WriteTo.Console()
           .WriteTo.File("/Users/cheung/Code/net/logger/log.txt",
               rollingInterval: RollingInterval.Day,
               rollOnFileSizeLimit: true)
           .CreateLogger();

        //services.AddScoped<Test>();
        services.AddScoped<Test2>();
        using (var sp = services.BuildServiceProvider())
        {
            //var loggerService = sp.GetRequiredService<Test>();
            
            //loggerService.TestConect();

            var Test2 = sp.GetRequiredService<Test2>();
            Test2.Test();
        }
    }
}

