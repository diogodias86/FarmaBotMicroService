using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmaBotMicroService.PedidoService.Application.AppModel;
using FarmaBotMicroService.PedidoService.Service.Api.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FarmaBotMicroService.PedidoService.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly PedidosDbContext _context;

        public PedidoController(PedidosDbContext context)
        {
            _context = context;
        }

        // GET: api/Pedido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoDTO>>> GetPedidos()
        {
            var result = await _context.Pedidos.Include(i => i.Itens)
                                                .ThenInclude( m=> m.Medicamento).ToListAsync();

            return result;
        }

        // GET: api/Pedido/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoDTO>> GetPedidoDTO(Guid id)
        {
            var pedidoDTO = await _context.Pedidos.Include(i => i.Itens)
                                                .ThenInclude(m => m.Medicamento)
                                                .Where(p=> p.Id == id).FirstOrDefaultAsync();

            if (pedidoDTO == null)
            {
                return NotFound();
            }

            return pedidoDTO;
        }

        // PUT: api/Pedido/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedidoDTO(Guid id, PedidoDTO pedidoDTO)
        {
            if (id != pedidoDTO.Id)
            {
                return BadRequest();
            }

            _context.Entry(pedidoDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoDTOExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pedido
        [HttpPost]
        public async Task<ActionResult<PedidoDTO>> PostPedidoDTO(PedidoDTO pedidoDTO)
        {
            _context.Pedidos.Add(pedidoDTO);

            foreach (var itemPedido in pedidoDTO.Itens)
            {
                itemPedido.Pedido = pedidoDTO;
                _context.Itens.Add(itemPedido);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedidoDTO", new { id = pedidoDTO.Id }, pedidoDTO);
        }

        // DELETE: api/Pedido/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PedidoDTO>> DeletePedidoDTO(Guid id)
        {
            var pedidoDTO = await _context.Pedidos.FindAsync(id);
            if (pedidoDTO == null)
            {
                return NotFound();
            }

            _context.Pedidos.Remove(pedidoDTO);
            await _context.SaveChangesAsync();

            return pedidoDTO;
        }

        private bool PedidoDTOExists(Guid id)
        {
            return _context.Pedidos.Any(e => e.Id == id);
        }
    }
}
