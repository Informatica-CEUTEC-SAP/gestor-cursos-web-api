using GestorCursos.Data;
using GestorCursos.DTO;
using GestorCursos.Models;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace GestorCursos.Services;

public class EstudianteService: IEstudianteService
{
    private readonly IDbContextFactory<GestorCursosDbContext> _gestorCursosContextFactory;

    public EstudianteService(IDbContextFactory<GestorCursosDbContext> gestorCursosContextFactory)
    {
        _gestorCursosContextFactory = gestorCursosContextFactory ?? throw new ArgumentNullException(nameof(gestorCursosContextFactory));
    }
    public async Task<IEnumerable<EstudianteDto>> GetAllEstudiantes()
    {
        var context = await _gestorCursosContextFactory.CreateDbContextAsync();
        var estudiantes = await context.Estudiantes
            .AsNoTracking()
            .ToListAsync();

        return estudiantes.Adapt<List<EstudianteDto>>();
    }

    public async Task<EstudianteDto> GetEstudianteById(Guid id)
    {
        var context = await _gestorCursosContextFactory.CreateDbContextAsync();
        var estudiante = await context.Estudiantes
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
        if (estudiante == null)
        {
            return null;
        }

        return estudiante.Adapt<EstudianteDto>();
    }

    public async Task<EstudianteDto> CreateEstudiante(CreateUpdateEstudianteDto estudiante)
    {
        var context = await _gestorCursosContextFactory.CreateDbContextAsync();
        var newEstudiante = estudiante.Adapt<Estudiante>();
        context.Add(newEstudiante);
        await context.SaveChangesAsync();
        return newEstudiante.Adapt<EstudianteDto>();
    }

    public async Task<EstudianteDto> UpdateEstudiante(Guid id, CreateUpdateEstudianteDto estudiante)
    {
        var context = await _gestorCursosContextFactory.CreateDbContextAsync();
        var existingEstudiante = await context.Estudiantes
            .FirstOrDefaultAsync(e => e.Id == id);
        if (existingEstudiante == null)
        {
            return null;
        }
        estudiante.Adapt(existingEstudiante);
        context.Update(existingEstudiante);
        await context.SaveChangesAsync();
        return existingEstudiante.Adapt<EstudianteDto>();
    }

    public async Task<bool> DeleteEstudiante(Guid id)
    {
        var context = await _gestorCursosContextFactory.CreateDbContextAsync();
        var estudiante = await context.Estudiantes.FirstOrDefaultAsync(e => e.Id == id);
        if (estudiante == null)
        {
            return false;
        }
        context.Remove(estudiante);
        var result = await context.SaveChangesAsync();
        return result > 0;
    }
}