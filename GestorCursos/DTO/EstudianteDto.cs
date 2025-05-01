namespace GestorCursos.DTO;

public record EstudianteDto(
    Guid Id, 
    string Nombre, 
    string Email,
    DateOnly FechaNacimiento,  
    Guid? DepartamentoId
);