using System;
using System.Diagnostics;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public ActionResult<LoginResult> Login(LoginRequest req)
        {
            if (req.Name == "admin" && req.Password == "123")
            {
                var processes = Process.GetProcesses().Select(p => new ProcessInfo(p.Id, p.ProcessName, p.WorkingSet64)).ToArray();

                return new LoginResult(true, processes);
            }
            return new LoginResult(false, null);
        }
    }

}

