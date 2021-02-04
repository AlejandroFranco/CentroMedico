using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CentroMedico.Models;

namespace CentroMedico.Controllers
{
    public class CitasController : Controller
    {
        private CentroMedicoEntities1 db = new CentroMedicoEntities1();

        // GET: Citas
        public ActionResult Index()
        {
            var cita = db.Cita.Include(c => c.Medico).Include(c => c.Paciente);
            return View(cita.ToList());
        }

        // GET: Citas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // GET: Citas/Create
        public ActionResult Create()
        {
            ViewBag.id_medico = new SelectList(db.Medico, "id_medico", "especialidad");
            ViewBag.id_paciente = new SelectList(db.Paciente, "id_paciente", "cod_paciente");
            return View();
        }

        // POST: Citas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cita,id_medico,id_paciente,fecha_cita")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Cita.Add(cita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_medico = new SelectList(db.Medico, "id_medico", "especialidad", cita.id_medico);
            ViewBag.id_paciente = new SelectList(db.Paciente, "id_paciente", "cod_paciente", cita.id_paciente);
            return View(cita);
        }

        // GET: Citas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_medico = new SelectList(db.Medico, "id_medico", "especialidad", cita.id_medico);
            ViewBag.id_paciente = new SelectList(db.Paciente, "id_paciente", "cod_paciente", cita.id_paciente);
            return View(cita);
        }

        // POST: Citas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cita,id_medico,id_paciente,fecha_cita")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_medico = new SelectList(db.Medico, "id_medico", "especialidad", cita.id_medico);
            ViewBag.id_paciente = new SelectList(db.Paciente, "id_paciente", "cod_paciente", cita.id_paciente);
            return View(cita);
        }

        // GET: Citas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cita cita = db.Cita.Find(id);
            db.Cita.Remove(cita);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
