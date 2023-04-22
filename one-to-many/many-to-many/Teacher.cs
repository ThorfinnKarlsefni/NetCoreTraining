using System;
namespace many_to_many
{
	public class Teacher
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public List<Student> Students { get; set; } = new List<Student>();
	}
}

