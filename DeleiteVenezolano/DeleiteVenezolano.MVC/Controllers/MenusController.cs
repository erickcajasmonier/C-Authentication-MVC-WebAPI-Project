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
    public class MenusController : Controller
    {
        //private DeleiteDbContext db = new DeleiteDbContext();
        private readonly IUnityOfWork _UnityOfWork;
        public MenusController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;

        }
        public MenusController()
        {

        }

        // GET: Menus
        public ActionResult Index()
        {
            //return View(db.Menus.ToList());
            return View(_UnityOfWork.Menus.GetAll());
        }

        // GET: Menus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Menu menu = db.Menus.Find(id);
            Menu menu = _UnityOfWork.Menus.Get(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // GET: Menus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Menus/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MenuId,Nombre,Precio,TipoMenu")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                //db.Menus.Add(menu);
                _UnityOfWork.Menus.Add(menu);

                // db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(menu);
        }

        // GET: Menus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Menu menu = db.Menus.Find(id);
            Menu menu = _UnityOfWork.Menus.Get(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: Menus/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MenuId,Nombre,Precio,TipoMenu")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(menu).State = EntityState.Modified;
                _UnityOfWork.StateModified(menu);

                // db.SaveChanges();
                _UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menu);
        }

        // GET: Menus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Menu menu = db.Menus.Find(id);
            Menu menu = _UnityOfWork.Menus.Get(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Menu menu = db.Menus.Find(id);
            Menu menu = _UnityOfWork.Menus.Get(id);

            //db.Menus.Remove(menu);
            _UnityOfWork.Menus.Remove(menu);

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
