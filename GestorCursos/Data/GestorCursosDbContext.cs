using GestorCursos.Data.Configurations;
using GestorCursos.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorCursos.Data;

public class GestorCursosDbContext: DbContext
{
    public GestorCursosDbContext(DbContextOptions<GestorCursosDbContext> options): base(options)
    {
    }
    
    public DbSet<Estudiante> Estudiantes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new EstudiantesConfiguration().Configure(modelBuilder.Entity<Estudiante>());
    }
}