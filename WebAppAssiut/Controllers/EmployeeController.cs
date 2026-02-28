namespace WebAppAssiut.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();
        public EmployeeController()
        {
            
            
        }
        public IActionResult Index()
        {
            List<Employee> EmpList= context.Employees.ToList();
            return View("Index",EmpList);
        }

        #region Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //collect
            Employee empFromDb= context.Employees.FirstOrDefault(e=>e.Id==id);
            List<Department>DeptList=context.Departments.ToList();
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
                Employee EmpFromdb = context.Employees.FirstOrDefault(e => e.Id == EmpFromReq.Id);

                //mapping
                EmpFromdb.Name= EmpFromReq.EmpName;
                EmpFromdb.ImageUrl = EmpFromReq.ImageUrl;
                EmpFromdb.Salary = EmpFromReq.Salary;
                EmpFromdb.DepartmentId= EmpFromReq.DepartmentId;

                //save chage
                context.SaveChanges();
                return RedirectToAction("Index", "Employee");

            }
            EmpFromReq.DeptList = context.Departments.ToList();//refill
            return View("Edit", EmpFromReq);
        }
        #endregion

        #region details
        //Employee/Details/100
        public IActionResult Details (int id)
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

            Employee empModel = context.Employees.FirstOrDefault(e => e.Id == id);
            
            return View("Details", empModel);
        }
        
     
        public IActionResult DetailsVM(int id)
        {
            //Collect data
            //Extar infom sen from back to front
            string msg = "heelo";
            int temp = 20;
            List<string> branches = new List<string>() { "Assiut", "Alex", "Menia" };
            Employee empModel = context.Employees.FirstOrDefault(e => e.Id == id);

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
