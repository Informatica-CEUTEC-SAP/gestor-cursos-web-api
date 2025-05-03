namespace GestorCursos.DTO;

public record CreateUpdateEstudianteDto(
    string Nombre, 
    string Email,
    DateOnly FechaNacimiento,  
    Guid? DepartamentoId
);