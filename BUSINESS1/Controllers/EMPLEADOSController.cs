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
    public class EMPLEADOSController : Controller
    {
        private EMPRESABUSINESSEntities db = new EMPRESABUSINESSEntities();

        // GET: EMPLEADOS
        public ActionResult Index()
        {
            var eMPLEADOS = db.EMPLEADOS.Include(e => e.DEPARTAMENTOS);
            return View(eMPLEADOS.ToList());
        }

        // GET: EMPLEADOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADOS eMPLEADOS = db.EMPLEADOS.Find(id);
            if (eMPLEADOS == null)
            {
                return HttpNotFound();
            }
            return View(eMPLEADOS);
        }

        // GET: EMPLEADOS/Create
        public ActionResult Create()
        {
            ViewBag.IdDepartamento = new SelectList(db.DEPARTAMENTOS, "IdDepartamento", "NomDepartamento");
            return View();
        }

        // POST: EMPLEADOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEmpleado,IdDepartamento,NomEmpleado,Activo")] EMPLEADOS eMPLEADOS)
        {
            if (ModelState.IsValid)
            {
                db.EMPLEADOS.Add(eMPLEADOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDepartamento = new SelectList(db.DEPARTAMENTOS, "IdDepartamento", "NomDepartamento", eMPLEADOS.IdDepartamento);
            return View(eMPLEADOS);
        }

        // GET: EMPLEADOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADOS eMPLEADOS = db.EMPLEADOS.Find(id);
            if (eMPLEADOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDepartamento = new SelectList(db.DEPARTAMENTOS, "IdDepartamento", "NomDepartamento", eMPLEADOS.IdDepartamento);
            return View(eMPLEADOS);
        }

        // POST: EMPLEADOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEmpleado,IdDepartamento,NomEmpleado,Activo")] EMPLEADOS eMPLEADOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPLEADOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDepartamento = new SelectList(db.DEPARTAMENTOS, "IdDepartamento", "NomDepartamento", eMPLEADOS.IdDepartamento);
            return View(eMPLEADOS);
        }

        // GET: EMPLEADOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADOS eMPLEADOS = db.EMPLEADOS.Find(id);
            if (eMPLEADOS == null)
            {
                return HttpNotFound();
            }
            return View(eMPLEADOS);
        }

        // POST: EMPLEADOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EMPLEADOS eMPLEADOS = db.EMPLEADOS.Find(id);
            db.EMPLEADOS.Remove(eMPLEADOS);
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
