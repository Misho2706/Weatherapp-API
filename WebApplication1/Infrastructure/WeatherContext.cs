using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Infrastructure.Models;

namespace WebApplication1.Infrastructure
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options)
            : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<request_fore> request_fore { get; set; }
        public DbSet<request_history> request_history { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Users_Log> Users_Log { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("DefaultConnection");
        //}
    }
}
