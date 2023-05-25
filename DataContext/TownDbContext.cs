using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Town.Models;

namespace Town.DataContext
{
    public class TownDbContext:IdentityDbContext<AppUser>
    {
        public TownDbContext(DbContextOptions<TownDbContext> options) : base(options) { }

        public DbSet<Infotmation> Infotmations { get; set; }

    }
}
