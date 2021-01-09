using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vlad_Porime_Proiect.Models;

namespace Vlad_Porime_Proiect.Data
{
    public class Vlad_Porime_ProiectContext : DbContext
    {
        public Vlad_Porime_ProiectContext (DbContextOptions<Vlad_Porime_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Vlad_Porime_Proiect.Models.Shoe> Shoe { get; set; }

        public DbSet<Vlad_Porime_Proiect.Models.Factory> Factory { get; set; }

        public DbSet<Vlad_Porime_Proiect.Models.Category> Category { get; set; }
    }
}
