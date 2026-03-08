using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAppAssiut.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController
            (UserManager<ApplicationUser> userManger,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManger;
            this.signInManager = signInManager;
        }
        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel userFromRequest)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser appUser = new ApplicationUser()
                {
                    UserName=userFromRequest.UserName,
                    PasswordHash = userFromRequest.Password,
                    Address = userFromRequest.Address,
                };

                //add user db
                IdentityResult result=await userManager.CreateAsync(appUser,userFromRequest.Password);
                if(result.Succeeded)
                {
                    await userManager.AddToRoleAsync(appUser, "Admin");//asign user to role

                    //cookie
                    await signInManager.SignInAsync(appUser, false); //id,username,email ,role
                    return RedirectToAction("Index", "Employee");

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View("Register",userFromRequest);
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel userFromReq)
        {
            if (ModelState.IsValid) {
                 ApplicationUser appUser=await userManager.FindByNameAsync(userFromReq.UserName);
                if (appUser != null)
                {
                    bool found= await  userManager.CheckPasswordAsync(appUser, userFromReq.Password);
                    if (found)
                    {
                        List<Claim> Claims = new List<Claim>();
                        Claims.Add(new Claim("Address",appUser.Address));
                        await signInManager.SignInWithClaimsAsync(appUser, userFromReq.RememeberMe,Claims);
                        return RedirectToAction("Index", "Employee");
                    }
                }
                ModelState.AddModelError("", "Invaliad account");
            }
            return View("Login",userFromReq);

        }
        #endregion

        #region SignOut
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        #endregion
    }
}
