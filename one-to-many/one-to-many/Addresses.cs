using System;
namespace one_to_many
{
	public class Addresses
	{
		public long Id { get; set; }
		public string Address { get; set; }
		public Order? Order { get; set; }
	}
}

