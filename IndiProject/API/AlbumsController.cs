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
    public class AlbumsController : Controller
    {
        private ApplicationDbContext _db;
        public AlbumsController(ApplicationDbContext db)
        {
            this._db = db;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Album> Get()
        {
            return (from alb in _db.Albums where alb.ApplicationUser.UserName == User.Identity.Name
                    select new Album
                    {
                        Id = alb.Id,
                        Name = alb.Name,
                        Artist = alb.Artist,
                        AlbumArt = alb.AlbumArt
                    }).ToList();
          
           
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Album Get(int id)
        {
            var album = (from alb in _db.Albums
                         where alb.Id == id
                         select new Album
                         {
                             Id = alb.Id,
                             Name = alb.Name,
                             Artist = alb.Artist,
                             Tracks = alb.Tracks,
                             AlbumArt = alb.AlbumArt
                         }).FirstOrDefault();

            return album;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post ([FromBody]Album album)
        {
            ApplicationUser usr = (from user in _db.Users
                                   where user.UserName == User.Identity.Name
                                   select user).FirstOrDefault();

            album.ApplicationUser = usr;
            _db.Albums.Add(album);
            _db.SaveChanges();

            return Ok();
        }

        // PUT api/values/5
        [HttpPost("{id}")]
        public IActionResult Put(int id, [FromBody]Album album)
        {
            _db.Albums.Update(album);
            _db.SaveChanges();

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _db.Albums.Remove(_db.Albums.Where(a => a.Id == id).First());
            _db.SaveChanges();

            return Ok();
        }
    }
}
