using CentroMedico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CentroMedico.Controllers
{
    public class PacienteController : Controller
    {
        private CentroMedicoEntities1 db = new CentroMedicoEntities1();

        // GET: Paciente
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Perfil() {
            int id_usuario =  Convert.ToInt32(Session["id_usuario"]);
            var perfil = db.Usuario.FirstOrDefault(u => u.id_usuario == id_usuario);
            return View(perfil);
        }

        // GET: 
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }
   
        public ActionResult Salir()
        {
            Session.Remove("rol");
            Session.Remove("usuario");
            Session.Remove("id_usuario");
            return Redirect("Login");

        }

    }
}