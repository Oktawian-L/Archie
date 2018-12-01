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
using KryptoAPI.Data;

namespace KryptoAPI.Controllers
{
    public class TickerStoragesController : ApiController
    {
        private Syrakuza db = new Syrakuza();

        // GET: api/TickerStorages
        public IQueryable<TickerStorage> GetTickerStorage()
        {
            return db.TickerStorage;
        }

        // GET: api/TickerStorages/5
        [ResponseType(typeof(TickerStorage))]
        public IHttpActionResult GetTickerStorage(int id)
        {
            TickerStorage tickerStorage = db.TickerStorage.Find(id);
            if (tickerStorage == null)
            {
                return NotFound();
            }

            return Ok(tickerStorage);
        }

        // PUT: api/TickerStorages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTickerStorage(int id, TickerStorage tickerStorage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tickerStorage.Id)
            {
                return BadRequest();
            }

            db.Entry(tickerStorage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TickerStorageExists(id))
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

        // POST: api/TickerStorages
        [ResponseType(typeof(TickerStorage))]
        public IHttpActionResult PostTickerStorage(TickerStorage tickerStorage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TickerStorage.Add(tickerStorage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tickerStorage.Id }, tickerStorage);
        }

        // DELETE: api/TickerStorages/5
        [ResponseType(typeof(TickerStorage))]
        public IHttpActionResult DeleteTickerStorage(int id)
        {
            TickerStorage tickerStorage = db.TickerStorage.Find(id);
            if (tickerStorage == null)
            {
                return NotFound();
            }

            db.TickerStorage.Remove(tickerStorage);
            db.SaveChanges();

            return Ok(tickerStorage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TickerStorageExists(int id)
        {
            return db.TickerStorage.Count(e => e.Id == id) > 0;
        }
    }
}