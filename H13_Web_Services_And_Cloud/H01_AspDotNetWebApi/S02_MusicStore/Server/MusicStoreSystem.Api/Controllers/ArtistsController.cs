﻿namespace MusicStoreSystem.Api.Controllers
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using System.Web.Http.Description;
    using Data;
    using MusicStoreSystem.Models;

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ArtistsController : ApiController
    {
        private MusicStoreSystemDbContext db = new MusicStoreSystemDbContext();

        // GET: api/Artists
        public IQueryable<Artist> GetArtists()
        {
            return db.Artists;
        }

        // GET: api/Artists/5
        [ResponseType(typeof(Artist))]
        public IHttpActionResult GetArtist(int id)
        {
            Artist artist = db.Artists.Find(id);

            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        // PUT: api/Artists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArtist(int id, Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != artist.Id)
            {
                return BadRequest();
            }

            db.Entry(artist).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistExists(id))
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

        // POST: api/Artists
        [ResponseType(typeof(Artist))]
        public IHttpActionResult PostArtist(Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Artists.Add(artist);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = artist.Id }, artist);
        }

        // DELETE: api/Artists/5
        [ResponseType(typeof(Artist))]
        public IHttpActionResult DeleteArtist(int id)
        {
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return NotFound();
            }

            db.Artists.Remove(artist);
            db.SaveChanges();

            return Ok(artist);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArtistExists(int id)
        {
            return db.Artists.Count(e => e.Id == id) > 0;
        }
    }
}