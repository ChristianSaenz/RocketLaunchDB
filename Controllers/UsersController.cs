using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Rocket_Launch_Database__2_.Data;
using Rocket_Launch_Database__2_.Models;



namespace Rocket_Launch_Database__2_.Controllers
{
    [ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly RocketLaunchDbContext _context;
    private readonly ILogger<LaunchSitesController> _logger;


        public UsersController(RocketLaunchDbContext context, ILogger<LaunchSitesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Users
        [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return await _context.User.ToListAsync();
    }

    // GET: api/Users/5
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
            try
            {
                var user = await _context.User.FindAsync(id);

                if (user == null)
                {
                    _logger.LogWarning("user with ID {Id} not found. ", id);
                    return NotFound("user was not found.");
                }
                return user;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "An error occrued while retriving user with ID {Id}. ", id);
                return StatusCode(500, "An error occrued while processing you're request. ");
            }

     
    }

    // PUT: api/Users/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, User user)
    {
        if (id != user.Id)
        {
            return BadRequest("The ID in the URL does not match the ID of the user to update.");
        }
        if (!UserExists(id))
        {
            return NotFound($"A user with ID {id} was not found.");
        }
        
            _context.Entry(user).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
             _logger.LogError(ex, "A concurrency error occurred updating the user with ID {Id}.", id);
             return Conflict("The user was modified by another process. Please reload and try again.");
        }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred updating the user with ID {Id}.", id);
                return StatusCode(500, "An error occurred while processing your request.");
            }

            return NoContent();
    }

    // POST: api/Users
    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(User user)
    {
            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            if (user.Id != 0)
            {
                return BadRequest("ID should not be set for new user. It will be generated automatically.");
            }
            try
            {
                _context.User.Add(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetUser", new { id = user.Id }, user);
            }
            catch(DbUpdateException ex)
            {
                _logger.LogError(ex, "An error occurred while creating a new user.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        
    }

    // DELETE: api/Users/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _context.User.FindAsync(id);
        if (user == null)
        {
                _logger.LogInformation("Attempted to delete a user with ID {Id}, but it was not found.", id);
                return NotFound($"A user with ID {id} was not found.");
        }
            var isReferenced = await _context.RocketLaunches.AnyAsync(u => u.UserId == id);
            if (isReferenced)
            {
                // Log and return a warning without deleting the LaunchVehicle
                _logger.LogWarning("Attempted to delete User with ID {Id} which is referenced by one or more RocketLaunch records.", id);
                return BadRequest($"User with ID {id} is referenced by one or more RocketLaunch records and cannot be deleted without affecting those records.");
            }
            try
        {
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Deleted user with ID {Id}.", id);
            }
        catch (Exception ex) 
        {
                _logger.LogError(ex, "An error occurred while deleting user with ID {Id}.", id);
                return StatusCode(500, "An error occurred while processing your request.");
        }
            return NoContent();

        }

    private bool UserExists(int id)
    {
        return _context.User.Any(e => e.Id == id);
    }
}
}