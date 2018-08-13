using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestRest.Modelos;

namespace TestRestDirectory.Models
{
    public class DirectoryContext : DbContext
    {
        public DirectoryContext (DbContextOptions<DirectoryContext> options)
            : base(options)
        {
        }

        public DbSet<TestRest.Modelos.Personas> Personas { get; set; }
    }
}
