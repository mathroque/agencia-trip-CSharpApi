using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgenciatripapiMysql.Data;
using AgenciatripapiMysql.Models;
using System.Web.Http.Cors;

namespace AgenciatripapiMysql.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DestinoController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public DestinoController(ApiDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DestinoModel>>> GetDestino()
        {
            return await _context.Destino.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<DestinoModel>> GetDestinoModel(int id)
        {
            var destinoModel = await _context.Destino.FindAsync(id);

            if (destinoModel == null)
            {
                return NotFound();
            }

            return destinoModel;
        }
       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDestinoModel(int id, DestinoModel destinoModel)
        {
            if (id != destinoModel.id)
            {
                return BadRequest();
            }

            _context.Entry(destinoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DestinoModelExists(id))
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

        [HttpPost]
        public async Task<ActionResult<DestinoModel>> PostDestinoModel(DestinoModel destinoModel)
        {
            _context.Destino.Add(destinoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDestinoModel", new { id = destinoModel.id }, destinoModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDestinoModel(int id)
        {
            var destinoModel = await _context.Destino.FindAsync(id);
            if (destinoModel == null)
            {
                return NotFound();
            }

            _context.Destino.Remove(destinoModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DestinoModelExists(int id)
        {
            return _context.Destino.Any(e => e.id == id);
        }
    }
}
