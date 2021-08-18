using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PeliculasDisney.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeliculasDisney.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Personaje> Personaje { get; set; }
    }
}
