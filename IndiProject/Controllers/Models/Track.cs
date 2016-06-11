using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndiProject.Models
{
    public class Track
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public string Length { get; set; }
        public Album Album { get; set; }
    }
}
