using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSW2.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public AppRole()
        {

        }
        public AppRole(string rolename) : base(rolename)
        {
           

        }
        public string Description { get; set; }
    }
}
