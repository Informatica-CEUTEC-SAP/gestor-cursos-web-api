using GestorCursos.DTO;

namespace GestorCursos.Services;

public interface IEstudianteService
{
    Task<IEnumerable<EstudianteDto>> GetAllEstudiantes();
}