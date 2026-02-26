namespace WebAppAssiut.Models
{
    public class StudentBL
    {
        List<Student> students;
        public StudentBL()
        {
            students = new List<Student>() { 
                new Student(){ Id=1,Name="Ahmed",Address="alex",ImageUrl="m.png"},
                new Student(){ Id=2,Name="Hala",Address="alex",ImageUrl="2.jpg"},
                new Student(){ Id=3,Name="Sara",Address="alex",ImageUrl="2.jpg"},
            };
        }

        public List<Student> GetAll()
        {
            return students;
        }

        public Student GetById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }
    }
}
