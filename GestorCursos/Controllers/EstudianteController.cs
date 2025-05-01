using GestorCursos.DTO;
using GestorCursos.Services;
using Microsoft.AspNetCore.Mvc;


namespace GestorCursos.Controllers;

[ApiController]
[Route("[controller]")]
public class EstudianteController : ControllerBase
{
    //DI
    private readonly IEstudianteService _estudianteService;
   
    public EstudianteController(IEstudianteService estudianteService)
    {
        this._estudianteService = estudianteService;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<EstudianteDto>>> GetAllEstudiantes()
    {
        var estudiantes = await _estudianteService.GetAllEstudiantes();
        return Ok(estudiantes);
    }
}