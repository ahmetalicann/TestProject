using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.MvcWebUI.Identity
{
    //Identity için olusturdugumuz User ve Role classlarını IdentityDbContexte implement ettik ve DbSet oalrak buraya tanıttık.
    public class AppIdentityDbContext : IdentityDbContext<AppIdentityUser,AppIdentityRole,string>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options):base(options)
        {
        }
        public DbSet<AppIdentityUser> AppIdentityUsers { get; set; }
        public DbSet<AppIdentityRole> AppIdentityRoles { get; set; }
    }
}
