using DeviceManagement.Database.Modal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement.Database.Context
{
    public class DeviceContext : DbContext
    {
        public DbSet<Device> Device { get; set; }
        public DeviceContext(DbContextOptions<DeviceContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=DeviceManagement;User Id=sa;Password=$kelta001");
        }
    }
   
}
