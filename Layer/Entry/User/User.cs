﻿using System;
namespace Entry.User
{
	public class User
	{
		public long Id { get; set; }
		public string? Email { get; set; }
		public string? Name { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}

