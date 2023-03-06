using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppCodeFirst.Models;

namespace WebAppCodeFirst.Data
{
    public class WebAppCodeFirstDbContext : DbContext
    {
        public WebAppCodeFirstDbContext (DbContextOptions<WebAppCodeFirstDbContext> options)
            : base(options)
        {
        }

        public DbSet<Hotel> Hotel { get; set; } = default!;
        public DbSet<Room> Room { get; set; } = default!;
        public DbSet<Restaurant> Restaurant { get; set; } = default!;
        public DbSet<Appreciation> Appreciation { get; set; } = default!;
    }
}
