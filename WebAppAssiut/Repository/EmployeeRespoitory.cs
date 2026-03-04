namespace WebAppAssiut.Repository
{
	public class EmployeeRespoitory : IEmployeeRepository
	{
		ITIContext context;
		public EmployeeRespoitory(ITIContext _ctx)
		{
			context = _ctx;// new ITIContext();
		}
		public void Add(Employee obj)
		{
			context.Employees.Add(obj);
		}

		public void Delete(int id)
		{
			Employee emp = GetByID(id);
			context.Employees.Remove(emp);	
		}

		public List<Employee> GetAll()
		{
		//	return context.Set<Employee>().ToList();
			return context.Employees.ToList();
		}

		public Employee GetByID(int id)
		{
			return context.Employees.FirstOrDefault(e => e.Id == id);
		}

		public void Save()
		{
			context.SaveChanges();
		}

		public void Update(Employee obj)
		{
			Employee empfronDB = GetByID(obj.Id);
			empfronDB.Name = obj.Name;
			empfronDB.Salary = obj.Salary;
			empfronDB.DepartmentId = obj.DepartmentId;
			empfronDB.ImageUrl = obj.ImageUrl;
			
			//throw new NotImplementedException();
		}
	}
}
