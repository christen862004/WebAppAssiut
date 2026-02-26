using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppAssiut.Models;

namespace WebAppAssiut.Controllers
{
    /*
     1) class name  end with Controller
     2) inherit from class Contoller 
     */
    public class HomeController : Controller
    {
        /* Method==> action 
         1) Must Be Public
         2) Cant Be Static
         3) Cant Be OverLoad (only in one case)
         */
        //Home/ShowMsg call endpoint
        public ContentResult ShowMsg()
        {
            //Logic
            //DEcalre
            ContentResult result = new ContentResult();
            //Set
            result.Content = "Hello";
            //REsturn
            return result;
        }
        public ViewResult ShowView()
        {
            //logic
            //DEcalre
            ViewResult result = new ViewResult();
            //set
            result.ViewName = "View1";
            //Views/Home/View1.cshtml
            //Views/Shared/View1.cshtml
            //throw exception
            //REsturn
            return result;
        }

        //Home/ShowMix?id=1&name=ahmedd
        //Home/ShowMix/11?name=ahmedd

        public IActionResult ShowMix(int id,string name)
        {
            if (id == 13)
            {
                return Content("Not Available");
            }
            else{
                return View("View1");
            }
        }
        //Dry
        //public ViewResult View(string name)
        //{
        //    ViewResult result = new ViewResult();
        //    //set
        //    result.ViewName = name;
        //    //REsturn
        //    return result;
        //}
        /*
         1) content   =>ContentResult  ==> Content()
         2) View      =>ViewREsult     ==>View ()
         3) Json      =>JsonResult     ==>Json (obj)
         4) NotFoundd =>NotFoundResult =>NotFound()
         5) UnAutho.  =>UnAuthorizeResult
        ......
         */















        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
