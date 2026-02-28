using Microsoft.AspNetCore.Mvc;

namespace WebAppAssiut.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext context = new ITIContext();
        public IActionResult Index()
        {
            List<Department> DeptList = context.Departments.ToList();
            return View("Index",DeptList);
        }

        #region New
        public IActionResult New()
        {
            return View("New");
        }
        //Support Get  Post
        //Department/SaveNew?Name=&ManagerName=
        [HttpPost]
        public IActionResult SaveNew(Department deptFromReq)//1)Create object 2) start Bind PRoperty
        {
            //if (Request.Method == "POST") { }
            if (deptFromReq.Name != null)
            {
                context.Departments.Add(deptFromReq);
                context.SaveChanges();//throw exception
                //DRY
                return RedirectToAction("Index", "Department");
            }
            return View("New",deptFromReq);

        }
        #endregion
    }
}
