using Microsoft.Extensions.Logging;
using Serilog;

namespace Test2
{
	public class Test2
	{

        //private readonly ILogger<Test2> logger;

        //public Test2(ILogger<Test2> logger)
        //{
        //    this.logger = logger;
        //}

        public void Test()
        {
            Log.Information("start conect");
            Log.Information("conect mysql");
            Log.Information("select database");
            Log.Information("life's little bit messy.we all make mistake");
            User user = new User { Name="jimmy", Age= "18", Message ="life's little bit messy.we all make mistake" };
            Log.Information("processed {@Position}",user);
            //Log.CloseAndFlush();
        }
       
    }

    class User
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Message { get; set; }
    }
}

