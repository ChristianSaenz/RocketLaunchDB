using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Launch_Database__2_.Data;
using Rocket_Launch_Database__2_.Models;

namespace Rocket_Launch_Database__2_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PayloadsController : ControllerBase
    {
        private readonly RocketLaunchDbContext _context;
        private readonly ILogger<PayloadsController> _logger;

        public PayloadsController(RocketLaunchDbContext context, ILogger<PayloadsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Payloads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payload>>> GetPayloads()
        {
            return await _context.Payload.ToListAsync();
        }

        // GET: api/Payloads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payload>> GetPayload(int id)
        {
            try
            {
                var payload = await _context.Payload.FindAsync(id);
                if (payload == null)
                {
                    _logger.LogWarning("Payload with Id {Id} not found.", id);
                    return NotFound("Payload was not found");
                }
                return payload;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occrued while retriving Payload with ID {Id}. ", id);
                return StatusCode(500, "An error occrued while processing you're request. ");
            }
            
        }

        // PUT: api/Payloads/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayload(int id, Payload payload)
        {
            if (id != payload.Id)
            {
                return BadRequest("The ID in the URL does not match the ID of the payload to update.");
            }
            if(!PayloadExists(id))
            {
                return NotFound($"A Paylaod with ID {id} was not found.");
            }

            _context.Entry(payload).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, "A concurrency error occurred updating the Paylaod with ID {Id}.", id);
                return Conflict("The Paylaod was modified by another process. Please reload and try again.");
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "An error occurred updating the Paylaod with ID {Id}.", id);
                return StatusCode(500, "An error occurred while processing your request.");
            }
            // Successfully updated
            return NoContent();
        }

        // POST: api/Payloads
        [HttpPost]
        public async Task<ActionResult<Payload>> CreatePayload(Payload payload)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (payload.Id != 0)
            {
                return BadRequest("ID should not be set for new payload. It will be generated automatically.");
            }
            try
            {
                _context.Payload.Add(payload);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetPayload), new { id = payload.Id }, payload);
            }
            catch (DbUpdateConcurrencyException ex) 
            {
                _logger.LogError(ex, "An error occurred while creating a new launch site.");
                return StatusCode(500, "An error occurred while processing your request.");
            }

        }

        // DELETE: api/Payloads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayload(int id)
        {
            var payload = await _context.Payload.FindAsync(id);
            if (payload == null)
            {
                _logger.LogInformation("Attempted to delete a Payload with ID {Id}, but it was not found.", id);
                return NotFound($"A Payload with ID {id} was not found.");
            }

            var isReferenced = await _context.RocketLaunches.AnyAsync(pl => pl.PayloadId == id);
            if (isReferenced)
            {
                // Log and return a warning without deleting the LaunchVehicle
                _logger.LogWarning("Attempted to delete Payload with ID {Id} which is referenced by one or more RocketLaunch records.", id);
                return BadRequest($"Payload with ID {id} is referenced by one or more RocketLaunch records and cannot be deleted without affecting those records.");
            }
            try
            {
                _context.Payload.Remove(payload);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Deleted Payloads with ID {Id}.", id);
            }
            catch(DbUpdateConcurrencyException ex) 
            {
                _logger.LogError(ex, "An error occurred while deleting Payload with ID {Id}.", id);
                return StatusCode(500, "An error occurred while processing your request.");

            }
            return NoContent();
        }

        private bool PayloadExists(int id)
        {
            return _context.Payload.Any(e => e.Id == id);
        }
    }
}