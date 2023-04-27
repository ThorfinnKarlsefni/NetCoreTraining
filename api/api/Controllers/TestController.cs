using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : Controller
    {
        private readonly Calculator cal;
        private readonly IMemoryCache memoryCahce;
        private readonly ILogger<TestController> logger;
        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <returns></returns>
        public TestController(Calculator calculator,IMemoryCache memory,ILogger<TestController> log)
        {
            this.cal = calculator;
            this.memoryCahce = memory;
            this.logger = log;
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

        [HttpPost]
        public async Task<ActionResult<Book?>> GetBook(int id)
        {
            // 1.从缓存中取数据
            // 2.从数据源取数据 并且返回给调用者及保存到缓存
            Console.WriteLine("开始执行 getbook");
            var book  = await memoryCahce.GetOrCreateAsync("book_" + id, async (e) =>
            {
                Console.WriteLine("从数据库中读取数据");
                return await GetByIdAsync(id);
            });

            if (book == null)
            {
                return NotFound("not found");
            }
            Console.WriteLine("把数据返回给调用者");
            return book;
        }

        public static Task<Book?> GetByIdAsync(int id)
        {
            var res = GetByBookId(id);
            return Task.FromResult(res);
        }

        //[HttpGet]
        public static Book? GetByBookId(int arg)
        {
            switch (arg)
            {
                case 1:
                    return new Book { Id = 1, Name = "CS144"};
                case 2:
                    return new Book { Id = 2, Name = "MS685"};
                default:
                    return null;
            }
        }
    }
}

