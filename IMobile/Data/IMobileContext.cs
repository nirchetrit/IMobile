using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IMobile.Models;

namespace IMobile.Models
{
    public class IMobileContext : DbContext
    {
        public IMobileContext (DbContextOptions<IMobileContext> options)
            : base(options)
        {
        }

        public DbSet<IMobile.Models.Accessorie> Accessorie { get; set; }

        public DbSet<IMobile.Models.Cart> Cart { get; set; }

        public DbSet<IMobile.Models.CartItemAcc> CartItemAcc { get; set; }

        public DbSet<IMobile.Models.CartItemDevice> CartItemDevice { get; set; }

        public DbSet<IMobile.Models.Device> Device { get; set; }

        public DbSet<IMobile.Models.Supplier> Supplier { get; set; }
    }
}
