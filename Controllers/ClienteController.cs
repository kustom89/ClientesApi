using ClienteApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClienteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController: ControllerBase
    {

        private readonly CLientesContext _context;

        public ClienteController(CLientesContext context)
        {
            _context = context;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Cliente>>> ListarClientes()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return Ok(clientes);
        }

        [HttpGet("listarSP")]
        public async Task<ActionResult<IEnumerable<Cliente>>> ListarClientesSP()
        {
            var clientes = await _context.Clientes
                .FromSqlRaw("EXEC VerClientes")
                .ToListAsync();

            return Ok(clientes);
        }
    }


}
