using GestorCursos.DTO;

namespace GestorCursos.Services;

public interface IEstudianteService
{
    Task<IEnumerable<EstudianteDto>> GetAllEstudiantes();
    Task<EstudianteDto> GetEstudianteById(Guid id);
    Task<EstudianteDto> CreateEstudiante(CreateUpdateEstudianteDto estudiante);
    Task<EstudianteDto> UpdateEstudiante(Guid id, CreateUpdateEstudianteDto estudiante);
    Task<bool> DeleteEstudiante(Guid id);
}