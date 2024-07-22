using Microsoft.AspNetCore.Mvc;

namespace LogiCivilApp.Controllers
{
    public class Login_FOController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register_Form()
        {
            return View();
        }
    }
}
