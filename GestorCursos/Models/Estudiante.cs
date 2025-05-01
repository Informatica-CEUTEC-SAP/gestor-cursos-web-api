namespace GestorCursos.Models;

public class Estudiante
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public DateOnly FechaNacimiento { get; set; }
    public Guid? DepartamentoId { get; set; }
}