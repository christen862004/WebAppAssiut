namespace WebAppAssiut.ViewModels
{
    public class EmpWithDeptListViewModel
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public int Salary { get; set; }
        public string? ImageUrl { get; set; }
        public int DepartmentId { get; set; }

        public List<Department> DeptList { get; set; }
    }
}
