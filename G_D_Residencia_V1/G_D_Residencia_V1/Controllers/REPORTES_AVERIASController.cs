using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using G_D_Residencia_V1.Models;

namespace G_D_Residencia_V1.Controllers
{
    public class REPORTES_AVERIASController : Controller
    {
        private RESIDENT_SYSTEMEntities db = new RESIDENT_SYSTEMEntities();

        // GET: REPORTES_AVERIAS
        public ActionResult Index()
        {
            var rEPORTES_AVERIAS = db.REPORTES_AVERIAS.Include(r => r.USUARIO);
            return View(rEPORTES_AVERIAS.ToList());
        }

        // GET: REPORTES_AVERIAS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REPORTES_AVERIAS rEPORTES_AVERIAS = db.REPORTES_AVERIAS.Find(id);
            if (rEPORTES_AVERIAS == null)
            {
                return HttpNotFound();
            }
            return View(rEPORTES_AVERIAS);
        }

        // GET: REPORTES_AVERIAS/Create
        public ActionResult Create()
        {
            ViewBag.id_usuario = new SelectList(db.USUARIOS, "id_usuario", "nombres");
            return View();
        }

        // POST: REPORTES_AVERIAS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_averia,id_usuario,descripcion_averia,status,fecha_solicitud,fecha_respuesta")] REPORTES_AVERIAS rEPORTES_AVERIAS)
        {
            if (ModelState.IsValid)
            {
                db.REPORTES_AVERIAS.Add(rEPORTES_AVERIAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_usuario = new SelectList(db.USUARIOS, "id_usuario", "nombres", rEPORTES_AVERIAS.id_usuario);
            return View(rEPORTES_AVERIAS);
        }

        // GET: REPORTES_AVERIAS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REPORTES_AVERIAS rEPORTES_AVERIAS = db.REPORTES_AVERIAS.Find(id);
            if (rEPORTES_AVERIAS == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_usuario = new SelectList(db.USUARIOS, "id_usuario", "nombres", rEPORTES_AVERIAS.id_usuario);
            return View(rEPORTES_AVERIAS);
        }

        // POST: REPORTES_AVERIAS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_averia,id_usuario,descripcion_averia,status,fecha_solicitud,fecha_respuesta")] REPORTES_AVERIAS rEPORTES_AVERIAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rEPORTES_AVERIAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_usuario = new SelectList(db.USUARIOS, "id_usuario", "nombres", rEPORTES_AVERIAS.id_usuario);
            return View(rEPORTES_AVERIAS);
        }

        // GET: REPORTES_AVERIAS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REPORTES_AVERIAS rEPORTES_AVERIAS = db.REPORTES_AVERIAS.Find(id);
            if (rEPORTES_AVERIAS == null)
            {
                return HttpNotFound();
            }
            return View(rEPORTES_AVERIAS);
        }

        // POST: REPORTES_AVERIAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            REPORTES_AVERIAS rEPORTES_AVERIAS = db.REPORTES_AVERIAS.Find(id);
            db.REPORTES_AVERIAS.Remove(rEPORTES_AVERIAS);
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
