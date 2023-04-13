namespace Logger;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");
        ServiceCollection services = new ServiceCollection();
        services.AddLogging(logBuilder => {
            logBuilder.AddConsole();
            logBuilder.SetMinimumLevel(LogLevel.Trace);
        });
        services.AddScoped<Test>();
        using (var sp = services.BuildServiceProvider())
        {
            var loggerService = sp.GetRequiredService<Test>();
            loggerService.TestConect();
        }
    }
}

