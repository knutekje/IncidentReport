using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IncidentReport.Data;
using IncidentReport.Model;

namespace IncidentReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IncidentContext _context;

        public IncidentController(IncidentContext context)
        {
            _context = context;
        }

        // GET: api/Incident
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncidentCase>>> GetIncidents()
        {
            return await _context.IncidentCases.ToListAsync();
        }

        // GET: api/Incident/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IncidentCase>> GetIncident(long id)
        {
            var incident = await _context.IncidentCases.FindAsync(id);

            if (incident == null)
            {
                return NotFound();
            }

            return incident;
        }

        // PUT: api/Incident/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncident(long id, IncidentCase IncidentCase)
        {
            if (id != IncidentCase.Id)
            {
                return BadRequest();
            }

            _context.Entry(IncidentCase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidentExists(id))
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

        // POST: api/Incident
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IncidentCase>> PostIncident(IncidentCase incidentcase)
        {
            _context.IncidentCases.Add(incidentcase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncident", new { id = incidentcase.Id }, incidentcase);
        }

        // DELETE: api/Incident/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncident(long id)
        {
            var incident = await _context.IncidentCases.FindAsync(id);
            if (incident == null)
            {
                return NotFound();
            }

            _context.IncidentCases.Remove(incident);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IncidentExists(long id)
        {
            return _context.IncidentCases.Any(e => e.Id == id);
        }
    }
}
