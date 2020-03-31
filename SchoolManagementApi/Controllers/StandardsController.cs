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
    public class StandardsController : ControllerBase
    {
        private readonly SchoolManagementDbContext _context;

        public StandardsController(SchoolManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/Standards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Standards>>> GetStandards()
        {
            return await _context.Standards.ToListAsync();
        }

        // GET: api/Standards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Standards>> GetStandards(int id)
        {
            var standards = await _context.Standards.FindAsync(id);

            if (standards == null)
            {
                return NotFound();
            }

            return standards;
        }

        // PUT: api/Standards/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStandards(int id, Standards standards)
        {
            if (id != standards.StandardId)
            {
                return BadRequest();
            }

            _context.Entry(standards).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StandardsExists(id))
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

        // POST: api/Standards
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Standards>> PostStandards(Standards standards)
        {
            _context.Standards.Add(standards);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStandards", new { id = standards.StandardId }, standards);
        }

        // DELETE: api/Standards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Standards>> DeleteStandards(int id)
        {
            var standards = await _context.Standards.FindAsync(id);
            if (standards == null)
            {
                return NotFound();
            }

            _context.Standards.Remove(standards);
            await _context.SaveChangesAsync();

            return standards;
        }

        private bool StandardsExists(int id)
        {
            return _context.Standards.Any(e => e.StandardId == id);
        }
    }
}
