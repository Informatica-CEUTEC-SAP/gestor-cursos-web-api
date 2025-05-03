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
{        try
        {
            var estudiantes = await _estudianteService.GetAllEstudiantes();
            return Ok(estudiantes);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }}
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<EstudianteDto>> GetEstudianteById(Guid id)
    {
        try
        {
            var estudiante = await _estudianteService.GetEstudianteById(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            return Ok(estudiante);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<EstudianteDto>> CreateEstudiante([FromBody] CreateUpdateEstudianteDto estudianteDto)
    {
        try
        {
            if (estudianteDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var createdEstudiante = await _estudianteService.CreateEstudiante(estudianteDto);
            return CreatedAtAction(nameof(GetEstudianteById), new { id = createdEstudiante.Id }, createdEstudiante);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<EstudianteDto>> UpdateEstudiante([FromRoute] Guid id,[FromBody] CreateUpdateEstudianteDto estudianteDto)
    {
        try
        {
            if (estudianteDto == null || id == Guid.Empty)
            {
                return BadRequest("Invalid data.");
            }

            var updatedEstudiante = await _estudianteService.UpdateEstudiante(id, estudianteDto);
            if (updatedEstudiante == null)
            {
                return NotFound();
            }
            return Ok(updatedEstudiante);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteEstudiante(Guid id)
    {
        try
        {
            var result = await _estudianteService.DeleteEstudiante(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}