using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndiProject.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<Track> Tracks { get; set; }
        public string AlbumArt { get; set; }
    }
}
