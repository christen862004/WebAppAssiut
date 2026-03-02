using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppAssiut.Models
{
    public class Employee
    {
        public int Id { get; set; }

        //[Required]
        [MaxLength(25,ErrorMessage ="Name Must be Less than 5 char")]
        [MinLength(3)]
        [Unique]
        public string Name { get; set; }

        //[Range(8000,25000)]
        //  [Remote("CheckSalary","Employee",ErrorMessage ="Salary invali",AdditionalFields = "Name")]//Get /Employee/CheckSalary?Salary=val
        [MoreThan(9000,Min=111)]
        public int Salary { get; set; }

        [RegularExpression(@"\w+\.(jpg|png)",ErrorMessage ="image Must be jpg or png ex: asd.jpg")]
        public string? ImageUrl { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
       
        //[Reuired]
        public Department? Department { get; set; }
    }
}
