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
    public class EgsAccountsController : ControllerBase
    {
        private readonly EgsQAsuiteContext _context;

        public EgsAccountsController(EgsQAsuiteContext context)
        {
            _context = context;
        }

        // GET: api/EgsAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EgsAccount>>> GetEgsAccounts()
        {
          if (_context.EgsAccounts == null)
          {
              return NotFound();
          }
            return await _context.EgsAccounts.ToListAsync();
        }

        // GET: api/EgsAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EgsAccount>> GetEgsAccount(int id)
        {
          if (_context.EgsAccounts == null)
          {
              return NotFound();
          }
            var egsAccount = await _context.EgsAccounts.FindAsync(id);

            if (egsAccount == null)
            {
                return NotFound();
            }

            return egsAccount;
        }

        // PUT: api/EgsAccounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEgsAccount(int id, EgsAccount egsAccount)
        {
            if (id != egsAccount.UserId)
            {
                return BadRequest();
            }

            _context.Entry(egsAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EgsAccountExists(id))
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


        // POST: api/EgsAccounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EgsAccount>> PostEgsAccount(EgsAccount egsAccount)
        {
          if (_context.EgsAccounts == null)
          {
              return Problem("Entity set 'EgsQAsuiteContext.EgsAccounts'  is null.");
          }
            _context.EgsAccounts.Add(egsAccount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEgsAccount", new { id = egsAccount.UserId }, egsAccount);
        }

        // DELETE: api/EgsAccounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEgsAccount(int id)
        {
            if (_context.EgsAccounts == null)
            {
                return NotFound();
            }
            var egsAccount = await _context.EgsAccounts.FindAsync(id);
            if (egsAccount == null)
            {
                return NotFound();
            }

            _context.EgsAccounts.Remove(egsAccount);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EgsAccountExists(int id)
        {
            return (_context.EgsAccounts?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
