namespace Logger;
using SystemServices;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

class Program
{
    static void Main(string[] args)
    {


        //Console.WriteLine("Hello, World!");
        ServiceCollection services = new ServiceCollection();
        services.AddLogging(logBuilder => {
            logBuilder.AddConsole();
            logBuilder.AddNLog();
          logBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Warning);
        });
        // log categories

        
        services.AddScoped<Test>();
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

