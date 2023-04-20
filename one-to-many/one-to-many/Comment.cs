using System;
namespace one_to_many
{
	public class Comment
	{
		public long Id { get; set; }
		public Article Article { get; set; }
        public int ArticleId { get; set; }
        public string Message { get; set; }
	}
}

