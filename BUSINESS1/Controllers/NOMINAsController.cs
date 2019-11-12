using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BUSINESS1.Models;

namespace BUSINESS1.Controllers
{
    public class NOMINAsController : Controller
    {
        private EMPRESABUSINESSEntities db = new EMPRESABUSINESSEntities();

        // GET: NOMINAs
        public ActionResult Index()
        {
            var nOMINA = db.NOMINA.Include(n => n.EMPLEADOS);
            return View(nOMINA.ToList());
        }

        // GET: NOMINAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOMINA nOMINA = db.NOMINA.Find(id);
            if (nOMINA == null)
            {
                return HttpNotFound();
            }
            return View(nOMINA);
        }

        // GET: NOMINAs/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpleado = new SelectList(db.EMPLEADOS, "IdEmpleado", "NomEmpleado");
            return View();
        }

        // POST: NOMINAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdNomina,IdEmpleado,Fecha,SueldoDia,Dias,SueldoQuincenal")] NOMINA nOMINA)
        {
            if (ModelState.IsValid)
            {
                db.NOMINA.Add(nOMINA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmpleado = new SelectList(db.EMPLEADOS, "IdEmpleado", "NomEmpleado", nOMINA.IdEmpleado);
            return View(nOMINA);
        }

        // GET: NOMINAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOMINA nOMINA = db.NOMINA.Find(id);
            if (nOMINA == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpleado = new SelectList(db.EMPLEADOS, "IdEmpleado", "NomEmpleado", nOMINA.IdEmpleado);
            return View(nOMINA);
        }

        // POST: NOMINAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdNomina,IdEmpleado,Fecha,SueldoDia,Dias,SueldoQuincenal")] NOMINA nOMINA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nOMINA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpleado = new SelectList(db.EMPLEADOS, "IdEmpleado", "NomEmpleado", nOMINA.IdEmpleado);
            return View(nOMINA);
        }

        // GET: NOMINAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOMINA nOMINA = db.NOMINA.Find(id);
            if (nOMINA == null)
            {
                return HttpNotFound();
            }
            return View(nOMINA);
        }

        // POST: NOMINAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NOMINA nOMINA = db.NOMINA.Find(id);
            db.NOMINA.Remove(nOMINA);
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
