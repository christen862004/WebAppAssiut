using Microsoft.AspNetCore.Mvc;

namespace WebAppAssiut.Controllers
{
    public class RouteController : Controller
    {
        //Route/M1/1?age=12&name=ahmed
        //r1/12/ahme  
        //r1/22/basma  
        //r1/22
        [HttpGet("r1/{age:int}/{name?}",Name ="Route3")]//web api 
        public IActionResult M1(int age,string name)
        {
            return  Content("M1");
        }
        //r2
        public IActionResult M2()
        {
            return Content("M2");
        }
    }
}
