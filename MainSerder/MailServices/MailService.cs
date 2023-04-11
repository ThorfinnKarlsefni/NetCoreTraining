using System;
using LogServices;
using ConfigServices;
namespace MailServices
{
	public class MailService :IMailService
	{
		private readonly ILogProvider log;
		private readonly IConfigService config;

		public MailService(ILogProvider log,IConfigService config)
		{
			this.log = log;
			this.config = config;
		}
		
		public void Send(string title,string to,string body)
		{
			this.log.LogInfo("ready!send mail");
			string smtpServer = this.config.GetValue("SmtpServer");
			string username = this.config.GetValue("UserNmae");
			string password = this.config.GetValue("Passwordd");

			Console.WriteLine($"mail address {smtpServer},{username},{password}");

			Console.WriteLine($"send mail {title} to {to},content:{body}");
			this.log.LogInfo("send mail.success");
		}
	}
}
