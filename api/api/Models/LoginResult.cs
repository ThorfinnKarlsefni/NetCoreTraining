using System;
namespace api.Models
{
	public record LoginResult(bool status, ProcessInfo[]? ProcessInfos);
}

