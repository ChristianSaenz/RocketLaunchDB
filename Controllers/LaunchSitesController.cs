using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Launch_Database__2_.Data;
using Rocket_Launch_Database__2_.Models;


namespace Rocket_Launch_Database__2_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LaunchSitesController : ControllerBase
    {
        private readonly RocketLaunchDbContext _context;
        private readonly ILogger<LaunchSitesController> _logger;

        public LaunchSitesController(RocketLaunchDbContext context, ILogger<LaunchSitesController> logger) 
        {
            _context = context;
            _logger = logger;
        }
    

       

        // GET: api/LaunchSites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LaunchSite>>> GetLaunchSites()
        {
            return await _context.LaunchSite.ToListAsync();
        }

        // GET: api/LaunchSites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LaunchSite>> GetLaunchSite(int id)
        {
            try
            {
                var launchSite = await _context.LaunchSite.FindAsync(id);

                if (launchSite == null)
                {
                    _logger.LogWarning("Launch site with ID {Id} not found. ", id);
                    return NotFound("Launch site was not found.");
                }
                return launchSite;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occrued while retriving Launch site with ID {Id}. ", id);
                return StatusCode(500, "An error occrued while processing you're request. ");
            }


        }

        // PUT: api/LaunchSites/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLaunchSite(int id, LaunchSite launchSite)
        {
            if (id != launchSite.Id)
            {
                
                return BadRequest("The ID in the URL does not match the ID of the launch site to update.");
            }

            if (!LaunchSiteExists(id))
            {
                
                return NotFound($"A launch site with ID {id} was not found.");
            }

            _context.Entry(launchSite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, "A concurrency error occurred updating the launch site with ID {Id}.", id);
                return Conflict("The launch site was modified by another process. Please reload and try again.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred updating the launch site with ID {Id}.", id);
                return StatusCode(500, "An error occurred while processing your request.");
            }

            // Successfully updated
            return NoContent();
        }


        // POST: api/LaunchSites
        [HttpPost]
        public async Task<ActionResult<LaunchSite>> CreateLaunchSite(LaunchSite launchSite)
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest( ModelState);    
            }
            if (launchSite.Id != 0)
            {
                return BadRequest("ID should not be set for new launch Site. It will be generated automatically.");
            }
            try
            {
                _context.LaunchSite.Add(launchSite);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetLaunchSite),  new { id = launchSite.Id }, launchSite);
            }
            catch(DbUpdateException ex) 
            {
                _logger.LogError(ex, "An error occurred while creating a new launch site.");
                return StatusCode(500, "An error occurred while processing your request.");
            }

        }

        // DELETE: api/LaunchSites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLaunchSite(int id)
        {
            var launchSite = await _context.LaunchSite.FindAsync(id);
            if (launchSite == null)
            {
                _logger.LogInformation("Attempted to delete a Launch Site with ID {Id}, but it was not found.", id);
                return NotFound($"A launch site with ID {id} was not found.");
            }

            
            var isReferenced = await _context.RocketLaunches.AnyAsync(rl => rl.LaunchSiteId == id);
            if (isReferenced)
            {
               
                _logger.LogWarning("Attempted to delete Launch Site with ID {Id} which is referenced by one or more RocketLaunch records.", id);
                return BadRequest($"Launch Site with ID {id} is referenced by one or more RocketLaunch records and cannot be deleted without affecting those records.");
            }

            try
            {
                _context.LaunchSite.Remove(launchSite);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Deleted Launch Site with ID {Id}.", id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting Launch Site with ID {Id}.", id);
                return StatusCode(500, "An error occurred while processing your request.");
            }

            return NoContent();
        }


        private bool LaunchSiteExists(int id)
        {
            return _context.LaunchSite.Any(e => e.Id == id);
        }
    }
}