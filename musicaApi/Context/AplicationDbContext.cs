using Microsoft.EntityFrameworkCore;
using musicaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace musicaApi.Context
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<escuela> Escuela { get; set; }
        public DbSet<Profesor> profesor { get; set; }
        public DbSet<Alumno> alumno { get; set; }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
       : base(options)
        {
        }
    }
}
