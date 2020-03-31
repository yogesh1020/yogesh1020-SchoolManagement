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
    public class AdmissionsController : ControllerBase
    {
        private readonly SchoolManagementDbContext _context;

        public AdmissionsController(SchoolManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/Admissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admissions>>> GetAdmissions()
        {
            return await _context.Admissions.ToListAsync();
        }

        // GET: api/Admissions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Admissions>> GetAdmissions(int id)
        {
            var admissions = await _context.Admissions.FindAsync(id);

            if (admissions == null)
            {
                return NotFound();
            }

            return admissions;
        }

        // PUT: api/Admissions/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmissions(int id, Admissions admissions)
        {
            if (id != admissions.AdmissionId)
            {
                return BadRequest();
            }

            _context.Entry(admissions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdmissionsExists(id))
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

        // POST: api/Admissions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Admissions>> PostAdmissions(Admissions admissions)
        {
            _context.Admissions.Add(admissions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdmissions", new { id = admissions.AdmissionId }, admissions);
        }

        // DELETE: api/Admissions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Admissions>> DeleteAdmissions(int id)
        {
            var admissions = await _context.Admissions.FindAsync(id);
            if (admissions == null)
            {
                return NotFound();
            }

            _context.Admissions.Remove(admissions);
            await _context.SaveChangesAsync();

            return admissions;
        }

        private bool AdmissionsExists(int id)
        {
            return _context.Admissions.Any(e => e.AdmissionId == id);
        }
    }
}
