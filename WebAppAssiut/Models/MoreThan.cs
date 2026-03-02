using System.ComponentModel.DataAnnotations;

namespace WebAppAssiut.Models
{
    public class MoreThanAttribute:ValidationAttribute
    {
        public int Max { get; set; }
        public int Min { get; set; }
        public MoreThanAttribute(int maxval)
        {
            Max= maxval;
        }
        public override bool IsValid(object? value)
        {
            int val = int.Parse(value.ToString());
            //if(val>Max)
            return true;
        }
    }
}
