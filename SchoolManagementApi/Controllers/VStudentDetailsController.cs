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
    public class VStudentDetailsController : ControllerBase
    {
        private readonly SchoolManagementDbContext _context;

        public VStudentDetailsController(SchoolManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/VStudentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VStudentDetails>>> GetVStudentDetails()
        {
            return await _context.VStudentDetails.ToListAsync();
        }

        // GET: api/VStudentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VStudentDetails>> GetVStudentDetails(int id)
        {
            var vStudentDetails = await _context.VStudentDetails.FindAsync(id);

            if (vStudentDetails == null)
            {
                return NotFound();
            }

            return vStudentDetails;
        }

        // PUT: api/VStudentDetails/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVStudentDetails(int id, VStudentDetails vStudentDetails)
        {
            if (id != vStudentDetails.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(vStudentDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VStudentDetailsExists(id))
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

        // POST: api/VStudentDetails
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<VStudentDetails>> PostVStudentDetails(VStudentDetails vStudentDetails)
        {
            _context.VStudentDetails.Add(vStudentDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVStudentDetails", new { id = vStudentDetails.StudentId }, vStudentDetails);
        }

        // DELETE: api/VStudentDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VStudentDetails>> DeleteVStudentDetails(int id)
        {
            var vStudentDetails = await _context.VStudentDetails.FindAsync(id);
            if (vStudentDetails == null)
            {
                return NotFound();
            }

            _context.VStudentDetails.Remove(vStudentDetails);
            await _context.SaveChangesAsync();

            return vStudentDetails;
        }

        private bool VStudentDetailsExists(int id)
        {
            return _context.VStudentDetails.Any(e => e.StudentId == id);
        }
    }
}
