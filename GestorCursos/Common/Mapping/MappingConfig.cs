using System.Reflection;
using Mapster;

namespace GestorCursos.Common.Mapping;

public static class MappingConfig
{
    public static void RegisterMapsterConfiguration(this IServiceCollection services)
    {
        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
    }
}