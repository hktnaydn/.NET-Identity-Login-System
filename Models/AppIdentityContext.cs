using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace aspnetcoreıdentyegitim.Models
{
    public class AppIdentityContext:IdentityDbContext<AppUser,AppRole,string>
    {
        public AppIdentityContext(DbContextOptions<AppIdentityContext> options):base(options)
        {

            
        }


    }
}
