    using Microsoft.AspNetCore.Mvc;

namespace MvcNetCoreSession.Controllers
{
    public class ManagedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string usuario, string password)
        {
            if(usuario.ToLower() == "admin" && password.ToLower() == "admin")
            {
                HttpContext.Session.SetString("Usuario", usuario);
                return RedirectToAction("Productos", "Tienda");
            }
            else
            {
                ViewBag.Mensaje = "Error credenciales";
                return View();
            }
        }

        public IActionResult Denied()
        {
            return View();  
        }
    }
}
