using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeleiteVenezolano.Entities.Entities;
using DeleiteVenezolano.Persistence;
using DeleiteVenezolano.Entities.IRepositories;

namespace DeleiteVenezolano.MVC.Controllers
{
    public class PromocionsController : Controller
    {
        //private DeleiteDbContext db = new DeleiteDbContext();
        private readonly IUnityOfWork _UnityOfWork;
        public PromocionsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;

        }
        public PromocionsController()
        {

        }

        // GET: Promocions
        public ActionResult Index()
        {
            //return View(db.Promociones.ToList());
            return View(_UnityOfWork.Promociones.GetAll());
        }

        // GET: Promocions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Promocion promocion = db.Promociones.Find(id);
            Promocion promocion = _UnityOfWork.Promociones.Get(id);
            if (promocion == null)
            {
                return HttpNotFound();
            }
            return View(promocion);
        }

        // GET: Promocions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Promocions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PromocionId,Nombre,Precio")] Promocion promocion)
        {
            if (ModelState.IsValid)
            {
                //db.Promociones.Add(promocion);
                _UnityOfWork.Promociones.Add(promocion);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(promocion);
        }

        // GET: Promocions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Promocion promocion = db.Promociones.Find(id);
            Promocion promocion = _UnityOfWork.Promociones.Get(id);
            if (promocion == null)
            {
                return HttpNotFound();
            }
            return View(promocion);
        }

        // POST: Promocions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PromocionId,Nombre,Precio")] Promocion promocion)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(promocion).State = EntityState.Modified;
                _UnityOfWork.StateModified(promocion);
                //db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(promocion);
        }

        // GET: Promocions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Promocion promocion = db.Promociones.Find(id);
            Promocion promocion = _UnityOfWork.Promociones.Get(id);
            if (promocion == null)
            {
                return HttpNotFound();
            }
            return View(promocion);
        }

        // POST: Promocions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Promocion promocion = db.Promociones.Find(id);
            Promocion promocion = _UnityOfWork.Promociones.Get(id);
            //db.Promociones.Remove(promocion);
            _UnityOfWork.Promociones.Remove(promocion);
            //db.SaveChanges();
            _UnityOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
