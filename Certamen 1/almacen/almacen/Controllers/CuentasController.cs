using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using almacen.Models;
namespace almacen.Controllers
{
    public class CuentasController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public IActionResult Index()
        {
            return View();
        }

        public CuentasController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        // GET: /Account/Login
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToLocal(model.ReturnUrl);
            }
            else if (result.IsLockedOut)
            {
                return View("Lockout");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }
        }
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Nombre = model.Nombre };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        public async Task<ActionResult> CreateAdmin()
        {
            var user = new ApplicationUser { UserName = "admin@example.com", Email = "admin@example.com", Nombre = "admin" };
            var result = await _userManager.CreateAsync(user, "Password123!");
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<ActionResult> CreateUser()
        {
            var user = new ApplicationUser { UserName = "user@example.com", Email = "user@example.com", Nombre = "juanito" };
            var result = await _userManager.CreateAsync(user, "Password123!");
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);

            }
            else { 
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
