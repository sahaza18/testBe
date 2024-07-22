using Microsoft.AspNetCore.Mvc;

namespace LogiCivilApp.Controllers
{
    public class StatGlobalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
