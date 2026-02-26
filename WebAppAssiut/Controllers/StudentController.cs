using Microsoft.AspNetCore.Mvc;
using WebAppAssiut.Models;

namespace WebAppAssiut.Controllers
{
    public class StudentController : Controller
    {
        StudentBL studentBl = new StudentBL();
        
        //Student/All endpoint
        public IActionResult All()
        {
            //ask model - get 
            List<Student> stdList= studentBl.GetAll();

            //sent View
            return View("ShowAll",stdList);//view Ahow all with Lsit<Student>
        }
        public IActionResult Details(int id)
        {
            Student stdModel= studentBl.GetById(id);
            return View("Details",stdModel); //View DEtails with Model Student
        }
    }
}
