using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VMStarter.Demo.DAL.Models
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options):base(options)
        {

        }

        public virtual DbSet<Client> Clients { get; set; }
    }
}
