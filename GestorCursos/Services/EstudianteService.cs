using GestorCursos.DTO;

namespace GestorCursos.Services;

public class EstudianteService: IEstudianteService
{

    public async Task<IEnumerable<EstudianteDto>> GetAllEstudiantes()
    {
        IEnumerable<EstudianteDto> estudiantes = new List<EstudianteDto>()
        {
            new EstudianteDto(Guid.NewGuid(), "Juan Perez", "juan.perez@example.com", new DateOnly(1990, 5, 20), Guid.NewGuid()),
            new EstudianteDto(Guid.NewGuid(), "Maria Lopez", "maria.lopez@example.com", new DateOnly(1995, 8, 15), Guid.NewGuid()),
            new EstudianteDto(Guid.NewGuid(), "Carlos Gomez", "carlos.gomez@example.com", new DateOnly(1988, 3, 10), null)
        };
        return estudiantes;
    }
}