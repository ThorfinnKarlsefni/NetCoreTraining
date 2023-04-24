using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc
{
	public class TestController : Controller
	{
		// view 不能使用数字
		public IActionResult Demo(int a)
		{
			var model = new Person("Chueng", true, new DateTime(2018, 3, 23));
			Console.WriteLine(123123);
			return View(model);
		}

		public IActionResult Demo2()
		{
			var model = new Person("jimmy", true, new DateTime(2019, 2, 18));
			return View(model);
		}
	}

	//public class TestController : Controller
 //   {
 //       public IActionResult Demo1(int a)
 //       {
 //           var model = new Person("Zack", true, new DateTime(1999, 9, 9));
 //           return View(model);
 //       }
 //       public IActionResult Demo2()
 //       {
 //           var model = new Person("Zack", true, new DateTime(1999, 9, 9));
 //           return View(model);
 //       }
 //   }
}

