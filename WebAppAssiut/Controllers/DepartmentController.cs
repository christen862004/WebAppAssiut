using Microsoft.AspNetCore.Mvc;
using WebAppAssiut.Repository;

namespace WebAppAssiut.Controllers
{
    public class DepartmentController : Controller
    {
        //ITIContext context = new ITIContext();
        DepartmentRepository departmentRepository;
		public DepartmentController()
		{
			departmentRepository = new DepartmentRepository();
		}

		public IActionResult Index()
        {
            List<Department> DeptList = departmentRepository.GetAll() ;
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
               departmentRepository.Add(deptFromReq);
                departmentRepository.Save();//throw exception
                //DRY
                return RedirectToAction("Index", "Department");
            }
            return View("New",deptFromReq);

        }
        #endregion
    }
}
