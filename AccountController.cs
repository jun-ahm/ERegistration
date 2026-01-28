using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ERegistration.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login() => View();        

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password, string returnUrl)
        {
            // Dummy user validation
            if (username == "admin" && password == "password")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "Admin")
                };
                var claimsIdentity = new ClaimsIdentity(claims, "cookie");
                await HttpContext.SignInAsync("cookie", new ClaimsPrincipal(claimsIdentity));

                if(!String.IsNullOrWhiteSpace(returnUrl))
                    return RedirectToAction("Index", returnUrl);

                return RedirectToAction("Index", "Home");

            }
            ViewBag.Error = "Invalid username or password";
            return View();
        }
        
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("cookie");
            return RedirectToAction("Login", "Account");
        }

        //public IActionResult AccessDenied() => View();
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
