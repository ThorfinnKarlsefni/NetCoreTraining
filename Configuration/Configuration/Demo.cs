using System.Runtime;
using Microsoft.Extensions.Options;

namespace Configuration
{
    public class Demo
	{
        // Monitor 及时更新
        // Snapshot 在一个范围内 一次http请求
        // 建议使用 IOptionsSnashot
        private readonly IOptionsSnapshot<DbSettings> optDbSettings;
        private readonly IOptionsSnapshot<SmtpSettings> optSmtpSettings;
        public Demo(IOptionsSnapshot<DbSettings> optDbSettings,
            IOptionsSnapshot<SmtpSettings> optSmtpSettings)
        {
            this.optDbSettings = optDbSettings;
            this.optSmtpSettings = optSmtpSettings;
        }
        public void Test()
        {
            var db = optDbSettings.Value;
            Console.WriteLine($"数据库：{db.DbType},{db.ConnectionString}");
            var smtp = optSmtpSettings.Value;
            Console.WriteLine($"Smtp：{smtp.Server},{smtp.UserName},{smtp.Password}");
        }
    }
	
}
 