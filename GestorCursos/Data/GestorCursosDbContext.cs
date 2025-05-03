using Microsoft.EntityFrameworkCore;

namespace GestorCursos.Data;

public class GestorCursosDbContext: DbContext
{
    public GestorCursosDbContext(DbContextOptions<GestorCursosDbContext> options): base(options)
    {
    }
    
    
}