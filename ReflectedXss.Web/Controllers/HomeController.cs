using Microsoft.AspNetCore.Mvc;
using ReflectedXss.Web.Models;
using System.Diagnostics;

namespace ReflectedXss.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult CommantAdd()
        {
            HttpContext.Response.Cookies.Append("email", "barisasd@gmail.com");
            HttpContext.Response.Cookies.Append("password", "barisasd");
            return View();
        }
        [HttpPost]
        public IActionResult CommantAdd(string name, string comment)
        {
            //< script >
            //alert(document.cookie)
            //</ script >  bunu texboxda çalısıtırırsan cookideki email ve password'u alert olarak alabilirsin.

            //burada html içindeki zararlı kodlar temizlenmeli kütüphane kullanılabilir.(HTMLSANITIZER)
            //https://github.com/mganss/HtmlSanitizer
            ViewBag.name = name;
            //ViewBag.email = email;
            ViewBag.comment = comment;
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}