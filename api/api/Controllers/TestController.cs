using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : Controller
    {
        private readonly Calculator cal;

        public TestController(Calculator calculator)
        {
            this.cal = calculator;
        }

        /// <summary>
        /// 依赖注入
        /// 需要时注入使用[FromServices]
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Add()
        {
            return cal.Add(1, 2).ToString();
        }
    }
}

