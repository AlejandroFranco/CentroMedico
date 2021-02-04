using CentroMedico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CentroMedico.Controllers
{
    public class RegistroController : Controller
    {

        public CentroMedicoEntities1 db = new CentroMedicoEntities1();

        // GET: Registro
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(Usuario usuario)
        {
        
            if (ModelState.IsValid)
            {
                usuario.rol = 1;
                usuario.fecha_nacimiento = Convert.ToDateTime(usuario.fecha_nacimiento);
                db.Usuario.Add(usuario);
                db.SaveChanges();
                ModelState.Clear();
            }
            return RedirectToAction("Login","Login");
        }


    }




}