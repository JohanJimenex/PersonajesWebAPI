using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonajesWebAPI.Models;

namespace PersonajesWebAPI;

public class PersonajeDbContext : DbContext {

    public DbSet<Personaje> Personajes { get; set; }
    public DbSet<Habilidad> Habilidads { get; set; }
    public DbSet<Raza> Razas { get; set; }

    public PersonajeDbContext(DbContextOptions<PersonajeDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {

        modelBuilder.Entity<Personaje>()
        .HasOne(p => p.Raza)
        .WithMany(r => r.Personajes)
        .HasForeignKey(p => p.RazaId);

        modelBuilder.Entity<Personaje>()
        .HasMany(p => p.Habilidades)
        .WithMany(h => h.Personajes);

    }
}
