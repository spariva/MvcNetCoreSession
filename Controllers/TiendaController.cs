using Microsoft.AspNetCore.Mvc;

namespace MvcNetCoreSession.Controllers
{
    public class TiendaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Productos() 
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Denied", "Managed");
            }
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Productos(string direccion, string[]producto)
        {
            if (HttpContext.Session.GetString("Usuario") == null) 
            {
                return RedirectToAction("Denied", "Managed");
            }
            else
            {
                TempData["Productos"] = producto;
                TempData["Direccion"] = direccion;
                return RedirectToAction("PedidoFinal");
            }
        }

        public IActionResult PedidoFinal()
        {
            string[] productos = TempData["Productos"] as string[];
            ViewBag.Direccion = TempData["Direccion"];
            return View(productos);
        }


    }
}
