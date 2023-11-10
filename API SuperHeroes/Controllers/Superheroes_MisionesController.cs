using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API_SuperHeroes.Models;

namespace API_SuperHeroes.Controllers
{
    public class Superheroes_MisionesController : ApiController
    {
        private SuperHeroesEntities db = new SuperHeroesEntities();

        // GET: api/Superheroes_Misiones
        public IHttpActionResult GetSuperheroes_Misiones()
        {
            return Ok(db.Superheroes_Misiones.ToList().Select(x => new Superheroes_Misiones()).ToList());
        }

        // GET: api/Superheroes_Misiones/5
        [ResponseType(typeof(Superheroes_Misiones))]
        public IHttpActionResult GetSuperheroes_Misiones(int id)
        {
            Superheroes_Misiones superheroes_Misiones = db.Superheroes_Misiones.Find(id);
            if (superheroes_Misiones == null)
            {
                return NotFound();
            }

            return Ok(superheroes_Misiones);
        }

        // PUT: api/Superheroes_Misiones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSuperheroes_Misiones(int id, Superheroes_Misiones superheroes_Misiones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != superheroes_Misiones.SuperheroeID)
            {
                return BadRequest();
            }

            db.Entry(superheroes_Misiones).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Superheroes_MisionesExists(id))
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

        // POST: api/Superheroes_Misiones
        [ResponseType(typeof(Superheroes_Misiones))]
        public IHttpActionResult PostSuperheroes_Misiones(Superheroes_Misiones superheroes_Misiones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Superheroes_Misiones.Add(superheroes_Misiones);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Superheroes_MisionesExists(superheroes_Misiones.SuperheroeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = superheroes_Misiones.SuperheroeID }, superheroes_Misiones);
        }

        // DELETE: api/Superheroes_Misiones/5
        [ResponseType(typeof(Superheroes_Misiones))]
        public IHttpActionResult DeleteSuperheroes_Misiones(int id)
        {
            Superheroes_Misiones superheroes_Misiones = db.Superheroes_Misiones.Find(id);
            if (superheroes_Misiones == null)
            {
                return NotFound();
            }

            db.Superheroes_Misiones.Remove(superheroes_Misiones);
            db.SaveChanges();

            return Ok(superheroes_Misiones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Superheroes_MisionesExists(int id)
        {
            return db.Superheroes_Misiones.Count(e => e.SuperheroeID == id) > 0;
        }
    }
}