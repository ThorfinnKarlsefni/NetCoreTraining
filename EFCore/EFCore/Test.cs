using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore
{
	[Table("T_test")]
	public class Test
	{
		public long Id { get; set; }
		[Required]
		public string Name { get; set; }
	}
}

