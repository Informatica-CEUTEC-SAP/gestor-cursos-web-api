using GestorCursos.Data;
using GestorCursos.DTO;
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
        
        IEnumerable<EstudianteDto> response = estudiantes.Select(e => new EstudianteDto
        (
            e.Id,
            e.Nombre,
            e.Email,
            e.FechaNacimiento,
            e.DepartamentoId
        )).ToList();
        return response;
    }
}