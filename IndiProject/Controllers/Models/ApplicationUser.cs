using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IndiProject.Models
{
   
    public class ApplicationUser : IdentityUser
    {
        
        public ICollection<Album> Albums { get; set; }
    }
}
