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
    public class EmpleadoesController : Controller
    {
        // private DeleiteDbContext db = new DeleiteDbContext();
        private readonly IUnityOfWork _UnityOfWork;


        public EmpleadoesController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;

        }
        public EmpleadoesController()
        {

        }

        // GET: Empleadoes
        public ActionResult Index()
        {
            //return View(db.Empleados.ToList());
            return View(_UnityOfWork.Empleados.GetAll());
        }

        // GET: Empleadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Empleado empleado = db.Empleados.Find(id);
            Empleado empleado = _UnityOfWork.Empleados.Get(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleadoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpleadoId,Dni,Nombre,Apellido,Correo,Direccion,FecInicio,TipoEmpleado")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                //db.Empleados.Add(empleado);
                _UnityOfWork.Empleados.Add(empleado);

                //db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Empleado empleado = db.Empleados.Find(id);
            Empleado empleado = _UnityOfWork.Empleados.Get(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpleadoId,Dni,Nombre,Apellido,Correo,Direccion,FecInicio,TipoEmpleado")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(empleado).State = EntityState.Modified;
                _UnityOfWork.StateModified(empleado);

                //db.SaveChanges();
                _UnityOfWork.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Empleado empleado = db.Empleados.Find(id);
            Empleado empleado = _UnityOfWork.Empleados.Get(id);

            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Empleado empleado = db.Empleados.Find(id);
            Empleado empleado = _UnityOfWork.Empleados.Get(id);

            //db.Empleados.Remove(empleado);
            _UnityOfWork.Empleados.Remove(empleado);

            // db.SaveChanges();
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
