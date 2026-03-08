using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace WebAppAssiut.ViewModels
{
    public class LoginViewModel
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememeberMe { get; set; }
    }
}
