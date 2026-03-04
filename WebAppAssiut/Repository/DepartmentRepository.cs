namespace WebAppAssiut.Repository
{
	public class DepartmentRepository : IDepartmentRspository
	{
		ITIContext context;
		public DepartmentRepository(ITIContext _ctx)
		{
			context =_ctx; // new ITIContext();
		}
		public void Add(Department obj)
		{
			context.Departments.Add(obj);
		}

		public void Delete(int id)
		{
			Department dep = GetByID(id);
			context.Departments.Remove(dep);
		}

		public List<Department> GetAll()
		{
			return context.Departments.ToList();
		}

		public Department GetByID(int id)
		{
			return context.Departments.FirstOrDefault(e=>e.Id == id);
		}

		public void Save()
		{
			context.SaveChanges();
		}

		public void Update(Department obj)
		{
			Department dep= GetByID(obj.Id);
			dep.Name = obj.Name;
			dep.ManagerName = obj.ManagerName;

		}
	}
}
