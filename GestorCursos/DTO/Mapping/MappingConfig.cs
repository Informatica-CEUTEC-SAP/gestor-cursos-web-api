using GestorCursos.Models;
using Mapster;

namespace GestorCursos.DTO.Mapping;

public class MappingConfig: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Estudiante, EstudianteDto>();
    }
}