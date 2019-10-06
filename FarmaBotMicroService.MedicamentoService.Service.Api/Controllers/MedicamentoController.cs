using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmaBotMicroService.MedicamentoService.Application.AppModel;
using FarmaBotMicroService.MedicamentoService.Service.Api.Contexts;

namespace FarmaBotMicroService.MedicamentoService.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentoController : ControllerBase
    {
        private readonly MedicamentosDbContext _context;

        public MedicamentoController(MedicamentosDbContext context)
        {
            _context = context;
        }

        // GET: api/Medicamento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicamentoDTO>>> GetMedicamentos()
        {
            var result = await _context.Medicamentos.Include(m => m.Sintomas).ToListAsync();

            return result;
        }

        // GET: api/Medicamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicamentoDTO>> GetMedicamentoDTO(Guid id)
        {
            var medicamentoDTO = await _context.Medicamentos.FindAsync(id);

            if (medicamentoDTO == null)
            {
                return NotFound();
            }

            return medicamentoDTO;
        }

        // PUT: api/Medicamento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicamentoDTO(Guid id, MedicamentoDTO medicamentoDTO)
        {
            if (id != medicamentoDTO.Id)
            {
                return BadRequest();
            }

            _context.Entry(medicamentoDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicamentoDTOExists(id))
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

        // POST: api/Medicamento
        [HttpPost]
        public async Task<ActionResult<MedicamentoDTO>> PostMedicamentoDTO(MedicamentoDTO medicamentoDTO)
        {
            _context.Medicamentos.Add(medicamentoDTO);

            foreach (var sintoma in medicamentoDTO.Sintomas)
            {
                sintoma.Medicamento = medicamentoDTO;
                _context.Sintomas.Add(sintoma);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicamentoDTO", new { id = medicamentoDTO.Id }, medicamentoDTO);
        }

        // DELETE: api/Medicamento/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MedicamentoDTO>> DeleteMedicamentoDTO(Guid id)
        {
            var medicamentoDTO = await _context.Medicamentos.FindAsync(id);
            if (medicamentoDTO == null)
            {
                return NotFound();
            }

            _context.Medicamentos.Remove(medicamentoDTO);
            await _context.SaveChangesAsync();

            return medicamentoDTO;
        }

        private bool MedicamentoDTOExists(Guid id)
        {
            return _context.Medicamentos.Any(e => e.Id == id);
        }
    }
}
