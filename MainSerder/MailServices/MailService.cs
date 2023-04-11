using System;
using LogServices;
using ConfigServices;
namespace MailServices
{
	public class MailService :IMailService
	{
		// 如无必要 勿增实体
		private readonly ILogProvider log;
		//private readonly IConfigService config;
		private readonly IConfigReader config;

		public MailService(ILogProvider log,IConfigReader config)
		{
			this.log = log;
			this.config = config;
		}
		
		public void Send(string title,string to,string body)
		{
			this.log.LogInfo("ready!send mail");
			string smtpServer = this.config.GetValue("SmtpServer");
			string username = this.config.GetValue("UserName");
			string password = this.config.GetValue("Password");

			Console.WriteLine($"mail address {smtpServer},{username},{password}");

			Console.WriteLine($"send mail {title} to {to},content:{body}");
			this.log.LogInfo("send mail.success");
		}
	}
}
