using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementApi;

namespace SchoolManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstallmentsController : ControllerBase
    {
        private readonly SchoolManagementDbContext _context;

        public InstallmentsController(SchoolManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/Installments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Installments>>> GetInstallments()
        {
            return await _context.Installments.ToListAsync();
        }

        // GET: api/Installments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Installments>> GetInstallments(int id)
        {
            var installments = await _context.Installments.FindAsync(id);

            if (installments == null)
            {
                return NotFound();
            }

            return installments;
        }

        // PUT: api/Installments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstallments(int id, Installments installments)
        {
            if (id != installments.InstallmentId)
            {
                return BadRequest();
            }

            _context.Entry(installments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstallmentsExists(id))
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

        // POST: api/Installments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Installments>> PostInstallments(Installments installments)
        {
            _context.Installments.Add(installments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstallments", new { id = installments.InstallmentId }, installments);
        }

        // DELETE: api/Installments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Installments>> DeleteInstallments(int id)
        {
            var installments = await _context.Installments.FindAsync(id);
            if (installments == null)
            {
                return NotFound();
            }

            _context.Installments.Remove(installments);
            await _context.SaveChangesAsync();

            return installments;
        }

        private bool InstallmentsExists(int id)
        {
            return _context.Installments.Any(e => e.InstallmentId == id);
        }
    }
}
