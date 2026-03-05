using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace WebAppAssiut.Controllers
{
    public class StateController : Controller
    {
        public IActionResult SetSession(int age,string name)
        {
            //logic
            HttpContext.Session.SetString("UserName", name);
            HttpContext.Session.SetInt32("Age", age);
            return Content("Session Save Suceess");
        }
        public IActionResult getSession()
        {
            //logic
            string n= HttpContext.Session.GetString("UserName");
            int? a = HttpContext.Session.GetInt32("Age");
            return Content($"Session {n}\n {a}");


        }
        public IActionResult SetCookie(int age,string name)
        {
            //Persisitent  Cookie
            CookieOptions options = new CookieOptions();
            options.Expires = DateTimeOffset.Now.AddDays(1);
            HttpContext.Response.Cookies.Append("Name", name,options);
            //session Cookie
            HttpContext.Response.Cookies.Append("Age", age.ToString());
            return Content("Cookie Save Suceess");

        }

        public IActionResult getCookie()
        {
            string name = HttpContext.Request.Cookies["Name"];

            
            string a = HttpContext.Request.Cookies["Age"];
            return Content($"cookie {name}\t{a}");

        }

    }
}
