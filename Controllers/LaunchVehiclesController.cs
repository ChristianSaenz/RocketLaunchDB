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
    public class LaunchVehiclesController : ControllerBase
    {
        private readonly RocketLaunchDbContext _context;
        private readonly ILogger<LaunchVehiclesController> _logger;

        public LaunchVehiclesController(RocketLaunchDbContext context, ILogger<LaunchVehiclesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/LaunchVehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LaunchVehicle>>> GetLaunchVehicles()
        {
            return await _context.LaunchVehicle.ToListAsync();
        }

        // GET: api/LaunchVehicles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LaunchVehicle>> GetLaunchVehicle(int id)
        {
            try
            {
                var launchVehicle = await _context.LaunchVehicle.FindAsync(id);

                if (launchVehicle == null)
                {
                    _logger.LogWarning("Launch Vehicle with ID {Id} not found. ", id);
                    return NotFound("Launch Vehicle was not found.");
                }

                return launchVehicle;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "An error occrued while retriving Launch Vehicle with ID {Id}. ", id);
                return StatusCode(500, "An error occrued while processing you're request. ");
            }
        }

        // PUT: api/LaunchVehicles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLaunchVehicle(int id, LaunchVehicle launchVehicle)
        {
            if (id != launchVehicle.Id)
            {
                return BadRequest("The ID in the URL does not match the ID of the launch vehicle to update.");
            }
            if (!LaunchVehicleExists(id))
            {
                return NotFound($"A launch vehicle with ID {id} was not found.");
            }

            if (_context.LaunchVehicle.Any(lv => lv.Name == launchVehicle.Name && lv.Id != id))
            {
                return BadRequest("The launch vehicle name must be unique.");
            }

            _context.Entry(launchVehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, "A concurrency error occurred updating the launch vehicle with ID {Id}.", id);
                return Conflict("The launch vehicle was modified by another process. Please reload and try again.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred updating the launch vehicle with ID {Id}.", id);
                return StatusCode(500, "An error occurred while processing your request.");
            }
            return NoContent();
        }

        // POST: api/LaunchVehicles
        [HttpPost]
        public async Task<ActionResult<LaunchVehicle>> CreateLaunchVehicle(LaunchVehicle launchVehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (launchVehicle.Id != 0)
            {
                return BadRequest("ID should not be set for new launch Vehicle. It will be generated automatically.");
            }
            try
            {
                _context.LaunchVehicle.Add(launchVehicle);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetLaunchVehicle), new { id = launchVehicle.Id }, launchVehicle);
            }
            catch(DbUpdateException ex) 
            {
                _logger.LogError(ex, "An error occurred while creating a new launch Vehicle.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // DELETE: api/LaunchVehicles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLaunchVehicle(int id)
        {
            var launchVehicle = await _context.LaunchVehicle.FindAsync(id);
            if (launchVehicle == null)
            {
                _logger.LogInformation("Attempted to delete a Launch Vehicle with ID {Id}, but it was not found.", id);
                return NotFound($"A launch vehicle with ID {id} was not found.");
            }

            
            var isReferenced = await _context.RocketLaunches.AnyAsync(rl => rl.LaunchVehicleId == id);
            if (isReferenced)
            {
                
                _logger.LogWarning("Attempted to delete Launch Vehicle with ID {Id} which is referenced by one or more RocketLaunch records.", id);
                return BadRequest($"Launch Vehicle with ID {id} is referenced by one or more RocketLaunch records and cannot be deleted without affecting those records.");
            }

            try
            {
                _context.LaunchVehicle.Remove(launchVehicle);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Deleted Launch Vehicle with ID {Id}.", id);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, "A concurrency error occurred while deleting Launch Vehicle with ID {Id}.", id);
                return StatusCode(500, "An error occurred while processing your request.");
            }
            return NoContent();
        }

        private bool LaunchVehicleExists(int id)
        {
            return _context.LaunchVehicle.Any(e => e.Id == id);
        }
    }
}