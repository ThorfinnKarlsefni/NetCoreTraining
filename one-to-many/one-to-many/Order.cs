using System;
namespace one_to_many
{
	public class Order
	{
		public long Id { get; set; }
		public string Name { get; set; }
        public Addresses Addresses { get; set; }
		public long AddressId { get; set; }
	}
}

