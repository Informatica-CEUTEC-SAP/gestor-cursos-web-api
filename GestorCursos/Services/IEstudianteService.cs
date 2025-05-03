using GestorCursos.DTO;

namespace GestorCursos.Services;

public interface IEstudianteService
{
    Task<IEnumerable<EstudianteDto>> GetAllEstudiantes();
    Task<EstudianteDto> GetEstudianteById(Guid id);
    Task<EstudianteDto> CreateEstudiante(EstudianteDto estudiante);
    Task<EstudianteDto> UpdateEstudiante(EstudianteDto estudiante);
    Task<bool> DeleteEstudiante(Guid id);
}