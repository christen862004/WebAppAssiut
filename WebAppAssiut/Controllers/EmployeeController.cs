using WebAppAssiut.Repository;

namespace WebAppAssiut.Controllers
{
    public class EmployeeController : Controller
    {
        //ITIContext context = new ITIContext();
        IEmployeeRepository empRepo;//DIP
        IDepartmentRspository deptRepo;
        public EmployeeController(IEmployeeRepository _empRepo,IDepartmentRspository _deptRep)//DI
        {
            empRepo=_empRepo;
            deptRepo=_deptRep;
        }
        
        public IActionResult Index()
        {
            List<Employee> EmpList= empRepo.GetAll();
            return View("Index",EmpList);
        }
        ////Get /Employee/CheckSalary?Salary=val
        public IActionResult CheckSalary(int Salary,string Name)
        {
            if (Salary > 8000)
                return Json(true);
            return Json(false);
        }

        #region New
        [HttpGet]
        public IActionResult New()
        {
            ViewData["DeptList"] = deptRepo.GetAll();
            return View("New");
        }
        //????????????????
        [HttpPost]//req .method=Post
        [ValidateAntiForgeryToken]//orm[_fvdsdjfd]
        public IActionResult SaveNew(Employee empFromReq)
        {
            // if(empFromReq.Name != null && empFromReq.Salary>8000) {
            if (ModelState.IsValid == true)
            {
                try
                {
                    empRepo.Add(empFromReq);
                   
                    empRepo.Save();
                    return RedirectToAction("Index", "Employee");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("error",ex.InnerException.Message);
                }
            }
            ViewData["DeptList"] = deptRepo.GetAll();
            return View("New",empFromReq);
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //collect
            Employee empFromDb= empRepo.GetByID(id);
            List<Department>DeptList=deptRepo.GetAll();
            //decalre
            EmpWithDeptListViewModel empVM = new EmpWithDeptListViewModel();
            //Map

            empVM.DeptList = DeptList;
            empVM.Id = empFromDb.Id;
            empVM.EmpName = empFromDb.Name;
            empVM.Salary = empFromDb.Salary;
            empVM.ImageUrl = empFromDb.ImageUrl;
            empVM.DepartmentId = empFromDb.DepartmentId;

            //NotFound
            return View("Edit", empVM);//Employee
            //send view ddisplay
        }
        [HttpPost]
        public IActionResult SaveEdit(EmpWithDeptListViewModel EmpFromReq)
        {
            if(EmpFromReq.EmpName!=null) {
                //old obj b
                Employee EmpFromdb = new Employee();

                //mapping
                EmpFromdb.Id = EmpFromReq.Id;   
				EmpFromdb.Name= EmpFromReq.EmpName;
                EmpFromdb.ImageUrl = EmpFromReq.ImageUrl;
                EmpFromdb.Salary = EmpFromReq.Salary;
                EmpFromdb.DepartmentId= EmpFromReq.DepartmentId;
                empRepo.Update(EmpFromdb);
                //save chage
                empRepo.Save();
                return RedirectToAction("Index", "Employee");

            }
            EmpFromReq.DeptList =deptRepo.GetAll();//refill
            return View("Edit", EmpFromReq);
        }
        #endregion

        #region details
        //Employee/Details/100?name=ahmed
        public IActionResult Details (int id,string name)
        {
            //Extar infom sen from back to front
            string msg = "heelo";
            int temp = 20;
            List<string> branches=new List<string> (){ "Assiut","Alex","Menia"};

            ViewData["Msg"] = msg; //set C#
            ViewData["Temp"] = temp;
            ViewData["Branches"] = branches;
            ViewBag.Color = "red";
            ViewData["Color"] = "Blue";//blue 

            Employee empModel =empRepo.GetByID(id);
            
            return View("Details", empModel);
        }
        
     
        public IActionResult DetailsVM(int id)
        {
            //Collect data
            //Extar infom sen from back to front
            string msg = "heelo";
            int temp = 20;
            List<string> branches = new List<string>() { "Assiut", "Alex", "Menia" };
            Employee empModel =empRepo.GetByID(id);

            //Mapp source =>Destination (VM)
            //declare View Modedl

            EmpDetailsWithTempColrBrcnahsMsgViewModel EmpVm = new() { 
                EmpId=empModel.Id,
                EmpName=empModel.Name,
                Temp=temp,
                Msg=msg,
                Color="red",
                Branches=branches
            };

            //Return vm
            return View("DetailsVM", EmpVm);
            //View ="DetailsVM" Model with type EmpDetailsWithTempColrBrcnahsMsgViewModel
        }
        #endregion
    }
}
