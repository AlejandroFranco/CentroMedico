using CentroMedico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CentroMedico.Controllers
{
    public class LoginController : Controller
    {

        public CentroMedicoEntities1 db = new CentroMedicoEntities1();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            int id;
            var usr = db.Usuario.FirstOrDefault(u => u.nombre_usuario == usuario.nombre_usuario && u.pass_usuario == usuario.pass_usuario);
            if (usr != null)
            {
                if (usr.rol == 1)
                {
                    /*La id 1 corresponde a un paciente*/
                    id = 1;
                }
                else if (usr.rol == 2)
                {
                    /*La id 2 corresponde a un Medico*/
                    id = 2;
                }
                else {
                    /*La id 3 corresponde a un Administrador*/
                    id = 3;
                }
                Session["rol"] = usr.rol;
                Session["usuario"] = usr.nombre_usuario;
                Session["id_usuario"] = usr.id_usuario;
                return VerificarSesion(id);
            }
            else
            {
                ModelState.AddModelError("", "Verifique sus credenciales");
            }

            return View();
        }


        public ActionResult VerificarSesion(int id)
        {
            if (Session["id_usuario"] != null)
            {
                if (id == 1)
                {
                    return Redirect("Home/Usuario");
                }
                else if (id == 2)
                {
                    return Redirect("Home/Medico");
                }
                else {
                    return Redirect("Home/Administrador");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }

        }





    }
}