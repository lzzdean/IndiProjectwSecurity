using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IndiProject.Data;
using IndiProject.Models;
using IndiProject.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace IndiProject.API
{
    [Route("api/[controller]")]
    public class TracksController : Controller
    {
        private ApplicationDbContext _db;
        public TracksController(ApplicationDbContext db)
        {
            this._db = db;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Track> Get()
        {
            return (from t in _db.Tracks
                    select new Track
                    {
                        Id = t.Id,
                        Name = t.Name,
                        Length = t.Length,

                    }).ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Track Get(int id)
        {

            //return _db.Tracks.Where(t => t.Id == id).FirstOrDefault();

            return (from trc in _db.Tracks
                    where trc.Id == id
                    select new Track
                    {
                        Id = trc.Id,
                        Name = trc.Name,
                        Length = trc.Length,
                        Album = trc.Album
                    }).FirstOrDefault();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]TrackWithAlbumId track)
        {
            var album = (from a in _db.Albums
                         where a.Id == track.AlbumId
                         select a).FirstOrDefault();

            var trackToAdd = new Track
            {
                Name = track.Name,
                Length = track.Length,
                Album = album


            };
            _db.Tracks.Add(trackToAdd);
            _db.SaveChanges();
            return Ok();
        }

        // PUT api/values/5
        [HttpPost("{id}")]
        public IActionResult Put(int id, [FromBody]Track track)
        {
            _db.Tracks.Update(track);
            _db.SaveChanges();

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {

            _db.Tracks.Remove(_db.Tracks.Where(t => t.Id == id).First());
            _db.SaveChanges();

            return Ok();

        }
    }
}
