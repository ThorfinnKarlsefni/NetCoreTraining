﻿using System;
namespace many_to_many
{
	public class Student
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public List<Teacher> Teachers { get; set; } = new List<Teacher>();
	}
}

