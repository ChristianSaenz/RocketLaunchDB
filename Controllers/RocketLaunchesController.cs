using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Launch_Database__2_.Data;
using Rocket_Launch_Database__2_.Models;



namespace Rocket_Launch_Database__2_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RocketLaunchesController : ControllerBase
    {
        private readonly RocketLaunchDbContext _context;
        private readonly ILogger<RocketLaunchesController> _logger;

        public RocketLaunchesController(RocketLaunchDbContext context, ILogger<RocketLaunchesController> logger)
        {
            _context = context;
            _logger = logger;

        }

        // GET: api/RocketLaunches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RocketLaunch>>> GetRocketLaunches()
        {
            return await _context.RocketLaunches.ToListAsync();
        }

        // GET: api/RocketLaunches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RocketLaunch>> GetRocketLaunch(int id)
        {
            try
            {
                var rocketLaunch = await _context.RocketLaunches.FindAsync(id);

                if (rocketLaunch == null)
                {
                    _logger.LogWarning("Rocket Launch with ID {Id} not found. ", id);
                    return NotFound("Rocket Launch was not found.");
                }
                return rocketLaunch;
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occrued while retriving Rocket Launch with ID {Id}. ", id);
                return StatusCode(500, "An error occrued while processing you're request. ");
            }
               
           
            
            

        }

        // PUT: api/RocketLaunches/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRocketLaunch(int id, RocketLaunch rocketLaunch)
        {
            if (id != rocketLaunch.Id)
            {
                return BadRequest("The ID in the URL does not match the ID of the Rocket Launch to update.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingRocketLaunch = await _context.RocketLaunches
       .Include(rl => rl.LaunchSite)
       .Include(rl => rl.LaunchVehicle)
       .Include(rl => rl.Payload)
       .Include(rl => rl.User)
       .FirstOrDefaultAsync(rl => rl.Id == id);

            if (existingRocketLaunch == null)
            {
                _logger.LogWarning("Rocket Launch Id {id} was not found. ", id);
                return NotFound("Rocket Launch was not found");
            }

            if (rocketLaunch.LaunchSite != null)
            {

                if (string.IsNullOrWhiteSpace(rocketLaunch.LaunchSite.Name))
                {
                    ModelState.AddModelError("LaunchSite.Name", "Launch site name is required.");
                }

                if (string.IsNullOrWhiteSpace(rocketLaunch.LaunchSite.Location))
                {
                    ModelState.AddModelError("LaunchSite.Location", "Launch site location is required.");
                }

            if(ModelState.IsValid) 
                {
                    _context.Entry(existingRocketLaunch.LaunchSite).CurrentValues.SetValues(rocketLaunch.LaunchSite);

                }
            }

            if (rocketLaunch.Payload != null)
            {
                if (string.IsNullOrWhiteSpace(rocketLaunch.Payload.Name))
                {
                    ModelState.AddModelError("Payload.Name", "Payload name is required.");
                }

                if (string.IsNullOrWhiteSpace(rocketLaunch.Payload.Type))
                {
                    ModelState.AddModelError("Payload.Type", "Payload type is required.");
                }

                if (rocketLaunch.Payload.Weight <= 0)
                {
                    ModelState.AddModelError("Payload.Weight", "Payload weight must be a positive value.");
                }
                if (ModelState.IsValid)
                {
                    _context.Entry(existingRocketLaunch.Payload).CurrentValues.SetValues(rocketLaunch.Payload);

                }
            }
            if (rocketLaunch.User != null)
            {
                if (string.IsNullOrWhiteSpace(rocketLaunch.User.Name))
                {
                    ModelState.AddModelError("User.Name", "User name is required.");
                }

                if (string.IsNullOrWhiteSpace(rocketLaunch.User.Email) || !IsValidEmail(rocketLaunch.User.Email))
                {
                    ModelState.AddModelError("User.Email", "A valid user email is required.");
                }

                if (ModelState.IsValid)
                {
                    _context.Entry(existingRocketLaunch.User).CurrentValues.SetValues(rocketLaunch.User);

                }
            }

            if(rocketLaunch.LaunchVehicle != null) 
            {
                if (string.IsNullOrWhiteSpace(rocketLaunch.LaunchVehicle.Name))
                {
                    ModelState.AddModelError("LaunchVehicle.Name", "Launch vehicle name is required.");
                }
                if (string.IsNullOrWhiteSpace(rocketLaunch.LaunchVehicle.Manufacturer)) 
                {
                    ModelState.AddModelError("LaunchVehicle.Manufacturer", "Launch vehicle manufacturer is required.");
                }
                if(ModelState.IsValid) 
                {
                    _context.Entry(existingRocketLaunch.LaunchVehicle).CurrentValues.SetValues(rocketLaunch.LaunchVehicle);
                }
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(existingRocketLaunch).CurrentValues.SetValues(rocketLaunch);

            if (rocketLaunch.LaunchSite != null)
            {
                _context.Entry(existingRocketLaunch.LaunchSite).CurrentValues.SetValues(rocketLaunch.LaunchSite);
            }

            _logger.LogInformation("Before update: Rocket Launch ID {Id}, Details: {@ExistingRocketLaunch}", id, existingRocketLaunch);

            try
            {
                await _context.SaveChangesAsync();
                _logger.LogInformation("Successfully updated Rocket Launch with ID {Id}.", id);
                _logger.LogInformation("After update: Rocket Launch ID {Id}, Details: {@RocketLaunch}", id, rocketLaunch);
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, "A concurrency error occurred updating the Rocket Launch with ID {Id}.", id);
                return Conflict("The Rocket Launch was modified by another process. Please reload and try again.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred updating the Rocket Launch with ID {Id}.", id);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    

        // POST: api/RocketLaunches
        [HttpPost]
        public async Task<ActionResult<RocketLaunch>> CreateRocketLaunch(RocketLaunch rocketLaunch)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (rocketLaunch.Id != 0)
            {
                return BadRequest("ID should not be set for new rocket Launch. It will be generated automatically.");
            }
            try
            {
                _context.RocketLaunches.Add(rocketLaunch);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetRocketLaunch), new { id = rocketLaunch.Id }, rocketLaunch);
            }
            catch(DbUpdateException ex) 
            {
                _logger.LogError(ex, "An error occurred while creating a new Rocket Launch.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
          

        }

        // DELETE: api/RocketLaunches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRocketLaunch(int id)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var rocketLaunch = await _context.RocketLaunches.FindAsync(id);
                    if (rocketLaunch == null)
                    {
                        return NotFound($"RocketLaunch with ID {id} was not found.");
                    }

                    // Only delete the RocketLaunch record. Do not delete the associated LaunchSite, LaunchVehicle, Payload, or User records.
                    _context.RocketLaunches.Remove(rocketLaunch);

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return NoContent();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError(ex, "An error occurred while deleting RocketLaunch with ID {id}.", id);
                    return StatusCode(500, "An error occurred while processing your request.");
                }
            }
        }

        private bool RocketLaunchExists(int id)
        {
            return _context.RocketLaunches.Any(e => e.Id == id);
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }
}
