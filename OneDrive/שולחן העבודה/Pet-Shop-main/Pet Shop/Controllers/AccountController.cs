using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pet_Shop.Models;

namespace Pet_Shop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User NewUser, int roleId)
        {
            //Creating roles if they are not yet created
            var NormalRole = new IdentityRole() { Name = "Normal" };
            if (!await _roleManager.RoleExistsAsync(NormalRole.Name))
                await _roleManager.CreateAsync(NormalRole);
            var AdminRole = new IdentityRole() { Name = "Admin" };
            if (!await _roleManager.RoleExistsAsync(AdminRole.Name))
                await _roleManager.CreateAsync(AdminRole);
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = NewUser.Username
                };
                var result = await _userManager.CreateAsync(user, NewUser.Password);
                if (result.Succeeded)
                {
                    if (roleId == 1)
                        await _userManager.AddToRoleAsync(user, "Normal");
                    else
                        await _userManager.AddToRoleAsync(user, "Admin");
                    await _signInManager.SignInAsync(user, false);
                    return Redirect("/Home/Index");
                }
                //Validation errors
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View("Register");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User LoggedUser)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(LoggedUser.Username, LoggedUser.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Username or Password incorrect");
            }
            return View();
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
