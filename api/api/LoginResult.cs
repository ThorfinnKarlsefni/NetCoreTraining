using System;
namespace api
{
	public record LoginResult(bool status, ProcessInfo[]? ProcessInfos);
}

