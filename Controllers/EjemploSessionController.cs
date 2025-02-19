using Microsoft.AspNetCore.Mvc;
using MvcNetCoreSession.Extensions;
using MvcNetCoreSession.Helpers;
using MvcNetCoreSession.Models;

namespace MvcNetCoreSession.Controllers
{
    public class EjemploSessionController : Controller
    {
        HelperSessionContextAccesor helper;

        public EjemploSessionController(HelperSessionContextAccesor helper)
        {
            this.helper = helper;
        }

        public IActionResult Index()
        {   
            List<Mascota> mascotas = this.helper.GetMascotasSession();
            return View(mascotas);
        }

        public IActionResult SessionSimple(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    HttpContext.Session.SetString("Nombre", "Entraptra");
                    HttpContext.Session.SetString("Hora", DateTime.Now.ToLongTimeString());
                    ViewBag.Mensaje = "Datos almacenados en la sesión";
                }
                else if (accion.ToLower() == "mostrar")
                {
                    ViewBag.Nombre = HttpContext.Session.GetString("Nombre");
                    ViewBag.Hora = HttpContext.Session.GetString("Hora");
                }
            }
            return View();
        }

        public IActionResult SessionMascota(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    Mascota mascota = new Mascota() { Edad = 5, Nombre = "Firulais", Tipo = "Perro" };
                    byte[] datos = HelperBinarySession.ObjectToByte(mascota);
                    HttpContext.Session.Set("Mascota", datos);
                    ViewBag.Mensaje = "Datos almacenados en la sesión";
                }
                else if (accion.ToLower() == "mostrar")
                {
                    byte[] datos = HttpContext.Session.Get("Mascota");
                    Mascota mascota = (Mascota)HelperBinarySession.ByteToObject(datos);
                    ViewBag.Mascota = mascota;
                    ViewBag.Mensaje = "Datos recuperados";
                }
            }
            return View();
        }


        public IActionResult SessionCollection(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    List<Mascota> mascotas = new List<Mascota>()
                    {
                        new Mascota() { Edad = 5, Nombre = "Firulais", Tipo = "Perro" },
                        new Mascota() { Edad = 2, Nombre = "Mishi", Tipo = "Gato" },
                        new Mascota() { Edad = 1, Nombre = "Piolin", Tipo = "Pajaro" }
                    };
                    byte[] datos = HelperBinarySession.ObjectToByte(mascotas);
                    HttpContext.Session.Set("Mascotas", datos);
                    ViewBag.Mensaje = "Datos almacenados en la sesión";
                }
                else if (accion.ToLower() == "mostrar")
                {
                    byte[] datos = HttpContext.Session.Get("Mascota");
                    List<Mascota> mascotas = (List<Mascota>)HelperBinarySession.ByteToObject(datos);
                    ViewBag.Mascota = mascotas;
                    ViewBag.Mensaje = "Datos recuperados";
                    return View(mascotas);
                }
            }
            return View();
        }

        public IActionResult SessionMascotaJson(string accion)
        {
            if(accion == null)
            {
                return View();
            }

            if(accion.ToLower() == "almacenar")
            {
                Mascota mascota = new Mascota{ Edad = 5, Nombre = "Vicenta", Tipo = "Perro" };
                string json = HelperJsonSession.SerializeObject<Mascota>(mascota);
                HttpContext.Session.SetString("Mascota", json);
                ViewBag.Mensaje = "Datos almacenados en la sesión";
            }
            else if(accion.ToLower() == "mostrar")
            {
                string json = HttpContext.Session.GetString("Mascota");
                Mascota mascota = HelperJsonSession.DeserializeObject<Mascota>(json);
                ViewBag.Mascota = mascota;
                ViewBag.Mensaje = "Datos recuperados";
            }

            return View();
        }


        public IActionResult SessionMascotaObject(string accion) { 
        
            if(accion == null)
            {
                return View();
            }

            if (accion.ToLower() == "almacenar")
            {
                Mascota mascota = new Mascota { Edad = 5, Nombre = "Olaz", Tipo = "Pez" };
                HttpContext.Session.SetObject("Mascota", mascota);
            }
            else if (accion.ToLower() == "mostrar")
            {
                Mascota mascota = HttpContext.Session.GetObject<Mascota>("Mascota");
                ViewBag.Mascota = mascota;
            }

            return View();
        }

        public IActionResult SessionMascotaCollection(string accion) 
        { 
            if(accion == null)
            {
                return View();
            }

            if (accion.ToLower() == "almacenar")
            {
                List<Mascota> mascotas = new List<Mascota>
                {
                    new Mascota { Edad = 2, Nombre = "Olaf", Tipo = "Pez" },
                    new Mascota { Edad = 5, Nombre = "Patricio", Tipo = "Estrella" },
                    new Mascota { Edad = 1, Nombre = "Serafina", Tipo = "Lagarto" },
                };
                HttpContext.Session.SetObject("Mascotas", mascotas);
                ViewBag.Mensaje = "Colección creada";
                return View();

            } else if(accion.ToLower() == "mostrar")
            {
                List<Mascota> mascotas = HttpContext.Session.GetObject<List<Mascota>>("Mascotas");
                ViewBag.mascotas = mascotas;
                return View(mascotas);
            }
            return View();
        }
    }
}
