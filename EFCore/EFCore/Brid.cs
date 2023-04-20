using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore
{
    //[Table("T_brids", Schema = "demo")]
    public class Brid
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		[Required]
		public DateTime CreateAt { get; set; }
	}
}

