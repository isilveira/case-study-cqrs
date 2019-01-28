using Microsoft.EntityFrameworkCore;
using SimpleCQRS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCQRS.Core.Infrastructures.Data.Contexts
{
    public class SingleCQRSContext : DbContext
    {
        protected SingleCQRSContext()
        {
            base.Database.EnsureCreated();
        }

        public SingleCQRSContext(DbContextOptions options) : base(options)
        {
            base.Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
    }
}
