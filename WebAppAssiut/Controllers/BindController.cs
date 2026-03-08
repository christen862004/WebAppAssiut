using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppAssiut.Filtters;

namespace WebAppAssiut.Controllers
{
    // [ErrorHandel]
    public class BindController : Controller
    {
        /*public non static -- no ovverload*/
        //Get Bind/m1
        //[HttpGet]
        [ErrorHandel]
        
        public IActionResult m1()
        {
            ApplicationUser user;
            
            throw new Exception("MEtho1 throw exception");
            return Content("M1");
        }
        //[HttpPost]

        //post Bind/m1
        public IActionResult m2(int no)
        {
            throw new Exception("MEtho1 throw exception");

            return Content("M1 overloadd");
        }
        /**
         <form action="/Bind/TestPrimitive" method="get">
                <input name="age">
                <input name="name">
                <input name="id">
                <input name="color[1]">
                <input name="PhoneBook[Ahmed]">
                <input name="PhoneBook[Mohamed]">
         </form>
         */
        //Test Primitive 
        //Get /Bind/TestPrimitive?age=12&name=ahmed&id=1
        //Get /Bind/TestPrimitive/1?age=12&name=ahmed
        public IActionResult TestPrimitive(int id,int age,string name,string[] color)
        {
            return Content($"{name}");
        }

        //Test Collection
        //Bind/TestDic?name=christen&PhoneBook[ahmed]=123&PhoneBook[monahmedd]=456
        public IActionResult TestDic(string name ,Dictionary<string,string> PhoneBook) { 
            return Content($"{name}");
        }

        //Test Custom Object
        //Bind/TestObj?id=1&Name=sd&ManagerName=ahmed& Employees[0].name=asd
        //public IActionResult TestObj(int Id, string Name, string? ManagerName, List<Employee> Employees)
        public IActionResult TestObj(Department dept)
        {
            return Ok();
        }

    }
}
