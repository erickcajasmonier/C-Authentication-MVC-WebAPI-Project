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
    public class ComprobantesController : ApiController
    {
        private DeleiteDbContext db = new DeleiteDbContext();

        // GET: api/Administrativoes
        public IQueryable<Comprobante> GetComprobante()
        {
            return db.Comprobantes;
        }

        // GET: api/Administrativoes/5
        [ResponseType(typeof(Comprobante))]
        public IHttpActionResult GetComprobante(int id)
        {
            Comprobante comprobante = db.Comprobantes.Find(id);
            if (comprobante == null)
            {
                return NotFound();
            }

            return Ok(comprobante);
        }

        // PUT: api/Administrativoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComprobante(int id, Comprobante comprobante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comprobante.ComprobanteId)
            {
                return BadRequest();
            }

            db.Entry(comprobante).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComprobanteExists(id))
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
        [ResponseType(typeof(Comprobante))]
        public IHttpActionResult PostComprobante(Comprobante comprobante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Comprobantes.Add(comprobante);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = comprobante.ComprobanteId }, comprobante);
        }

        // DELETE: api/Administrativoes/5
        [ResponseType(typeof(Comprobante))]
        public IHttpActionResult DeleteComprobante(int id)
        {
            Comprobante comprobante = db.Comprobantes.Find(id);
            if (comprobante == null)
            {
                return NotFound();
            }

            db.Comprobantes.Remove(comprobante);
            db.SaveChanges();

            return Ok(comprobante);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComprobanteExists(int id)
        {
            return db.Comprobantes.Count(e => e.ComprobanteId == id) > 0;
        }
    }
}
