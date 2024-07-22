using LogiCivilApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LogiCivilApp.Controllers
{
    public class LoginController : Controller
    {

        LogicivilContext dbContext = new LogicivilContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Authentification(string email , string password)
        {
            try {
                Utilisateur utilisateurForCheck = new Utilisateur();
                utilisateurForCheck.Mail = email;
                utilisateurForCheck.Password = password;
                Utilisateur afterCheck = utilisateurForCheck.authentification(dbContext);
                afterCheck.Password = "";
                
                string userData = JsonSerializer.Serialize(afterCheck);

                string? profilName = dbContext.Profils
                                     .Where(pr => pr.IdProfil == afterCheck.IdProfil)
                                     .Select(pr => pr.Nom)
                                     .FirstOrDefault();

                HttpContext.Session.SetString("User", userData);
                HttpContext.Session.SetString("_Layout", "_LayoutClient");
                HttpContext.Session.SetString("PrName_User", profilName);


                TempData["successMessage"] = "Authentification réussie !";
                TempData["redirectAfterToast"] = Url.Action("Index", "StatGlobal");
                return RedirectToAction("Index", "Login");

            }
            catch (Exception ex) {
                TempData["email"] = email;
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("User");
            HttpContext.Session.Remove("_Layout");
            HttpContext.Session.Remove("PrName_User");

            return RedirectToAction("Index", "Login");
        }



    }
}
