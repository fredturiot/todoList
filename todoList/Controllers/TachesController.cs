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
using todoList.Data;
using todoList.Models;

namespace todoList.Controllers
{
    public class TachesController : ApiController
    {
        private TodoDbContext db = new TodoDbContext();

        // GET: api/Taches
        public IQueryable<Tache> GetTache()
        {
            return db.Tache;
        }

        // GET: api/Taches/5
        [ResponseType(typeof(Tache))]
        public IHttpActionResult GetTache(int id)
        {
            Tache tache = db.Tache.Find(id);
            if (tache == null)
            {
                return NotFound();
            }

            return Ok(tache);
        }

        // PUT: api/Taches/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTache(int id, Tache tache)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tache.ID)
            {
                return BadRequest();
            }

            db.Entry(tache).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TacheExists(id))
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

        // POST: api/Taches
        [ResponseType(typeof(Tache))]
        public IHttpActionResult PostTache(Tache tache)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tache.Add(tache);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tache.ID }, tache);
        }

        // DELETE: api/Taches/5
        [ResponseType(typeof(Tache))]
        public IHttpActionResult DeleteTache(int id)
        {
            Tache tache = db.Tache.Find(id);
            if (tache == null)
            {
                return NotFound();
            }

            db.Tache.Remove(tache);
            db.SaveChanges();

            return Ok(tache);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TacheExists(int id)
        {
            return db.Tache.Count(e => e.ID == id) > 0;
        }
    }
}