using Microsoft.Extensions.Logging;

namespace SystemServices
{
	public class Test2
	{

        private readonly ILogger<Test2> logger;

        public Test2(ILogger<Test2> logger)
        {
            this.logger = logger;
        }


        public void Test()
        {
            logger.LogDebug("start conect");
            logger.LogWarning("conect mysql");
            logger.LogWarning("select database");
            logger.LogError("life's little bit messy.we all make mistake");
        }
       
    }
}

