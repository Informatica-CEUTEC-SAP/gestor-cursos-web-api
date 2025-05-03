using GestorCursos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorCursos.Data.Configurations;

public class EstudiantesConfiguration: IEntityTypeConfiguration<Estudiante>
{
    public void Configure(EntityTypeBuilder<Estudiante> builder)
    { 
// name table
        builder.ToTable("Estudiantes");
// Configuring the entity properties
        builder.Property(e => e.Nombre)
            .HasMaxLength(250);
        
        builder.Property(e => e.Email)
            .HasMaxLength(100)
            .IsUnicode(false);
        
        builder.Property(e => e.FechaNacimiento)
            .HasColumnType("date");
        
// Seeder data
        builder.HasData(
            new Estudiante
            {
                Id = Guid.NewGuid(),
                Nombre = "Juan Pérez",
                Email = "juan.perez@example.com",
                FechaNacimiento = new DateOnly(1990, 5, 15),
                DepartamentoId = Guid.NewGuid()
            },
            new Estudiante
            {
                Id = Guid.NewGuid(),
                Nombre = "María López",
                Email = "maria.lopez@example.com",
                FechaNacimiento = new DateOnly(1995, 8, 20),
                DepartamentoId = Guid.NewGuid()
            }
        );
    }
}