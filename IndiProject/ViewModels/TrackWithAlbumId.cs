using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndiProject.ViewModels
{
    public class TrackWithAlbumId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Length { get; set; }
        public int AlbumId { get; set; }
    }
}
