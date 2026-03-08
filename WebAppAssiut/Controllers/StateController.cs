using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Security.Claims;

namespace WebAppAssiut.Controllers
{
    public class StateController : Controller
    {

        public IActionResult Welcome()
        {
            if (User.Identity.IsAuthenticated)
            {
                //User.IsInRole("Trainee")

                Claim idClaim= User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                Claim addClaim = User.Claims.FirstOrDefault(c => c.Type == "Address");

                return Content($"Welcome {User.Identity.Name} with id={idClaim.Value} \n {addClaim.Value}");
            }
            return Content("Welcome Gust");
        }
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
