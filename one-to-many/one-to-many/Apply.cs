using System;
namespace one_to_many
{
	public class Apply
	{
		public long Id { get; set; }
		public User Requester { get; set; }
		public User? Approver { get; set; }
		public string Remark { get; set; }
		public DateTime From { get; set; }
		public DateTime To { get; set; }
		public int Status { get; set; }
	}
}

