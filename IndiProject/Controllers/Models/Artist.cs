using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndiProject.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}
//track model and/or details page with tracks, list of tracks for each album. //track runtime/ name of tracks. 
//photos of each album cover not in the styling but in the models 