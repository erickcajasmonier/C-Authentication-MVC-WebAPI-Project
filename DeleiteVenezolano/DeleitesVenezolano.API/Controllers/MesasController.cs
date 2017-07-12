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
using System.Web.Http;
using System.Web.Http.Description;
using System.Data.Entity.Infrastructure;

namespace DeleitesVenezolano.API.Controllers
{
    public class MesasController : ApiController
    {
        private DeleiteDbContext db = new DeleiteDbContext();

        // GET: api/Administrativoes
        public IQueryable<Mesa> GetMesas()
        {
            return db.Mesas;
        }

        // GET: api/Administrativoes/5
        [ResponseType(typeof(Mesa))]
        public IHttpActionResult GetMesa(int id)
        {
            Mesa mesa = db.Mesas.Find(id);
            if (mesa == null)
            {
                return NotFound();
            }

            return Ok(mesa);
        }

        // PUT: api/Administrativoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMesa(int id, Mesa mesa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mesa.MesaId)
            {
                return BadRequest();
            }

            db.Entry(mesa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MesaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Administrativoes
        [ResponseType(typeof(Mesa))]
        public IHttpActionResult PostMesa(Mesa mesa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Mesas.Add(mesa);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mesa.MesaId }, mesa);
        }

        // DELETE: api/Administrativoes/5
        [ResponseType(typeof(Mesa))]
        public IHttpActionResult DeleteMesa(int id)
        {
            Mesa mesa = db.Mesas.Find(id);
            if (mesa == null)
            {
                return NotFound();
            }

            db.Mesas.Remove(mesa);
            db.SaveChanges();

            return Ok(mesa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MesaExists(int id)
        {
            return db.Mesas.Count(e => e.MesaId == id) > 0;
        }
    }
}
