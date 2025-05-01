using GestorCursos.Controllers;
using GestorCursos.DTO;
using GestorCursos.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class EstudianteTests
{
    private readonly Mock<IEstudianteService> _estudianteServiceMock;
    public EstudianteTests()
    {
        this._estudianteServiceMock = new Mock<IEstudianteService>();
    }
    
    [Fact]
    public async Task GetAllEstudiantes_ReturnsOkResult_WithListOfEstudiantes()
    {
        // Arrange

        IEnumerable<EstudianteDto> estudiantes = new List<EstudianteDto>()
        {
            new EstudianteDto(Guid.NewGuid(), "Juan Perez", "juan.perez@example.com", new DateOnly(1990, 5, 20),
                Guid.NewGuid()),
            new EstudianteDto(Guid.NewGuid(), "Maria Lopez", "maria.lopez@example.com", new DateOnly(1995, 8, 15),
                Guid.NewGuid()),
            new EstudianteDto(Guid.NewGuid(), "Carlos Gomez", "carlos.gomez@example.com", new DateOnly(1988, 3, 10),
                null)
        };
        
        this._estudianteServiceMock.Setup(service => service.GetAllEstudiantes()).ReturnsAsync(estudiantes);

        var controller = new EstudianteController(this._estudianteServiceMock.Object);

        // Act
        var result = await controller.GetAllEstudiantes();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<EstudianteDto>>(okResult.Value);
        Assert.Equal(3, returnValue.Count);
    }
}