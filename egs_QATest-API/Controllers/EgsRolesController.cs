using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using egs_QATest_API.Models;

namespace egs_QATest_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EgsRolesController : ControllerBase
    {
        private readonly EgsQAsuiteContext _context;

        public EgsRolesController(EgsQAsuiteContext context)
        {
            _context = context;
        }

        // GET: api/EgsRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EgsRole>>> GetEgsRoles()
        {
          if (_context.EgsRoles == null)
          {
              return NotFound();
          }
            return await _context.EgsRoles.ToListAsync();
        }

        // GET: api/EgsRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EgsRole>> GetEgsRole(int id)
        {
          if (_context.EgsRoles == null)
          {
              return NotFound();
          }
            var egsRole = await _context.EgsRoles.FindAsync(id);

            if (egsRole == null)
            {
                return NotFound();
            }

            return egsRole;
        }

        // PUT: api/EgsRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEgsRole(int id, EgsRole egsRole)
        {
            if (id != egsRole.RoleId)
            {
                return BadRequest();
            }

            _context.Entry(egsRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EgsRoleExists(id))
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

        // POST: api/EgsRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EgsRole>> PostEgsRole(EgsRole egsRole)
        {
          if (_context.EgsRoles == null)
          {
              return Problem("Entity set 'EgsQAsuiteContext.EgsRoles'  is null.");
          }
            _context.EgsRoles.Add(egsRole);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EgsRoleExists(egsRole.RoleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEgsRole", new { id = egsRole.RoleId }, egsRole);
        }

        // DELETE: api/EgsRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEgsRole(int id)
        {
            if (_context.EgsRoles == null)
            {
                return NotFound();
            }
            var egsRole = await _context.EgsRoles.FindAsync(id);
            if (egsRole == null)
            {
                return NotFound();
            }

            _context.EgsRoles.Remove(egsRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EgsRoleExists(int id)
        {
            return (_context.EgsRoles?.Any(e => e.RoleId == id)).GetValueOrDefault();
        }
    }
}
