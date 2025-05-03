using GestorCursos.Data;
using GestorCursos.DTO;
using GestorCursos.Models;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace GestorCursos.Services;

public class EstudianteService: IEstudianteService
{
    private readonly IDbContextFactory<GestorCursosDbContext> _gestorCursosContextFactory;
    private readonly IMapper _mapper;

    public EstudianteService(IDbContextFactory<GestorCursosDbContext> gestorCursosContextFactory,IMapper mapper)
    {
        _gestorCursosContextFactory = gestorCursosContextFactory ?? throw new ArgumentNullException(nameof(gestorCursosContextFactory));
        _mapper = mapper;
    }
    public async Task<IEnumerable<EstudianteDto>> GetAllEstudiantes()
    {
        var context = await _gestorCursosContextFactory.CreateDbContextAsync();
        var estudiantes = await context.Estudiantes
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<EstudianteDto>>(estudiantes);
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

        return _mapper.Map<EstudianteDto>(estudiante);
    }

    public async Task<EstudianteDto> CreateEstudiante(EstudianteDto estudiante)
    {
        var context = await _gestorCursosContextFactory.CreateDbContextAsync();
        var newEstudiante = _mapper.Map<Estudiante>(estudiante);
        context.Add(newEstudiante);
        await context.SaveChangesAsync();
        return _mapper.Map<EstudianteDto>(newEstudiante);
    }

    public async Task<EstudianteDto> UpdateEstudiante(EstudianteDto estudiante)
    {
        var context = await _gestorCursosContextFactory.CreateDbContextAsync();
        var existingEstudiante = await context.Estudiantes
            .FirstOrDefaultAsync(e => e.Id == estudiante.Id);
        if (existingEstudiante == null)
        {
            return null;
        }
        _mapper.Map(estudiante, existingEstudiante);
        context.Update(existingEstudiante);
        await context.SaveChangesAsync();
        return _mapper.Map<EstudianteDto>(existingEstudiante);
    }

    public async Task<bool> DeleteEstudiante(Guid id)
    {
        var context = await _gestorCursosContextFactory.CreateDbContextAsync();
        context.Remove(new Estudiante { Id = id });
        var result = await context.SaveChangesAsync();
        return result > 0;
    }
}