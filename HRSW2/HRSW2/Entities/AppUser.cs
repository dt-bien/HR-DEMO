using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSW2.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string LastName { get; set; }
    }
}
