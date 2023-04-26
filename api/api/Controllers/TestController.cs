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

        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <returns></returns>
        public TestController(Calculator calculator)
        {
            this.cal = calculator;
        }

        /// <summary>
        /// 缓存 60S 在header设置cache-control:max-age-60
        /// 遵循RFC7324协议
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 60)]
        [HttpGet]
        public string Add()
        {
            // 调用依赖注入
            return cal.Add(1, 2).ToString();
        }
        [ResponseCache(Duration = 60)]
        [HttpGet]
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}

