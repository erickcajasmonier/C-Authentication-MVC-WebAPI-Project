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
    public class PromocionsController : ApiController
    {
        private DeleiteDbContext db = new DeleiteDbContext();

        // GET: api/Administrativoes
        public IQueryable<Promocion> GetPromocion()
        {
            return db.Promociones;
        }

        // GET: api/Administrativoes/5
        [ResponseType(typeof(Promocion))]
        public IHttpActionResult GetPromocion(int id)
        {
            Promocion promocion = db.Promociones.Find(id);
            if (promocion == null)
            {
                return NotFound();
            }

            return Ok(promocion);
        }

        // PUT: api/Administrativoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPromocion(int id, Promocion promocion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != promocion.PromocionId)
            {
                return BadRequest();
            }

            db.Entry(promocion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromocionExists(id))
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
        [ResponseType(typeof(Promocion))]
        public IHttpActionResult PostPromocion(Promocion promocion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Promociones.Add(promocion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = promocion.PromocionId }, promocion);
        }

        // DELETE: api/Administrativoes/5
        [ResponseType(typeof(Promocion))]
        public IHttpActionResult DeletePromocion(int id)
        {
            Promocion promocion = db.Promociones.Find(id);
            if (promocion == null)
            {
                return NotFound();
            }

            db.Promociones.Remove(promocion);
            db.SaveChanges();

            return Ok(promocion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PromocionExists(int id)
        {
            return db.Promociones.Count(e => e.PromocionId == id) > 0;
        }
    }
}
