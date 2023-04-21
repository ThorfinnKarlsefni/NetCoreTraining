using System;
namespace one_to_many
{
	public class OrgUnit
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public OrgUnit? Parent { get; set; }
		public List<OrgUnit> Children = new List<OrgUnit>();
	}
}

