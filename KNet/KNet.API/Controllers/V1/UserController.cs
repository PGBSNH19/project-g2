using KNet.API.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KNet.API.Repositories
{
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get (Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var user = await _context.Users
                .Where(x => x.Id == id)
                .Select(x => new
                {
                    x.Id,
                    x.FirstName,
                    x.LastName,
                    x.PhoneNumber,
                    x.Password
                }).FirstOrDefaultAsync();

            if (user is null)
                return BadRequest();

            return Ok(user);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete (Guid id)
        {
            var user = await _context.Users
                .Where(x =>
                x.Id == id &&
                x.IsActive)
                .FirstOrDefaultAsync();

            if (user is null)
                return BadRequest();

            _context.Remove(user);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
