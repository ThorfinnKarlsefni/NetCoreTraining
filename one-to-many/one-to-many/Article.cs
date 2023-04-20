﻿using System;
namespace one_to_many
{
	public class Article
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public List<Comment> Comments { get; set; } = new List<Comment>();
	}
}

