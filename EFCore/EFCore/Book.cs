using System;
namespace EFCore
{
	public class Book
	{
		public long Id { get; set; }
		public string Titile { get; set; }
		public DateTime PubTime { get; set; }
		public double Price { get; set; }

		public string AuthorName { get; set; }
	}
}

