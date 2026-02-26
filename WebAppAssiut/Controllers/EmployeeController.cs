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

    }
}
