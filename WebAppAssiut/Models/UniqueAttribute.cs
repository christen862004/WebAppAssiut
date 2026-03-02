using System.ComponentModel.DataAnnotations;

namespace WebAppAssiut.Models
{
    public class UniqueAttribute:ValidationAttribute
    {
        ITIContext context = new ITIContext();
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string? name = value.ToString();
            Employee? empFromReq=validationContext.ObjectInstance as Employee;


            Employee? EmpFromdb= context.Employees
                .FirstOrDefault(e => e.Name == name&& e.DepartmentId==empFromReq.DepartmentId);
            if (EmpFromdb == null)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Name Alreay Exist");
            //return base.IsValid(value, validationContext);
        }
    }
}
