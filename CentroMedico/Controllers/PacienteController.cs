using CentroMedico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Editar(int? id)
        {
     
            return View();
        }

    }
}