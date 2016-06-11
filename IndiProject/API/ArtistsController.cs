using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IndiProject.Data;
using IndiProject.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace IndiProject.API
{
    [Route("api/[controller]")]
    public class ArtistsController : Controller
    {
        private ApplicationDbContext _db;
        public ArtistsController(ApplicationDbContext db)
        {
            this._db = db;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Artist> Get()
        {
            var artists = (from art in _db.Artists select art).ToList();
            //List();
            return artists;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Artist Get(int id)
        {
            //return _db.Artists.Where(a => a.Id == id).First();
            var artist = (from art in _db.Artists
                         where art.Id == id
                         select new Artist
                         {
                             Id = art.Id,
                             Name = art.Name,
                             Genre = art.Genre,
                             Albums = art.Albums
                         }).FirstOrDefault();

            return artist;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Artist artist)
        {
            _db.Artists.Add(artist);
            _db.SaveChanges();

            return Ok();
        }

        // PUT api/values/5
        [HttpPost("{id}")]
        public IActionResult Put(int id, [FromBody]Artist artist)
        {
            _db.Artists.Update(artist);
            _db.SaveChanges();

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _db.Artists.Remove(_db.Artists.Where(a => a.Id == id).First());
            _db.SaveChanges();

            return Ok();
        }
    }
}
