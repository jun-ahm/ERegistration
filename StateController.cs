using Microsoft.AspNetCore.Mvc;

namespace ERegistration.Controllers
{
    public class StateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
