using KNet.API.Context;
using KNet.API.Models;
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
        public async Task<IActionResult> Get(Guid id)
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
        public async Task<IActionResult> Delete(Guid id)
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

        [HttpPut]
        public async Task<IActionResult> Put(User request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await _context.Users
                .Where(x =>
                x.Id == request.Id &&
                x.IsActive)
                .FirstOrDefaultAsync();

            if (user is null)
                return BadRequest();

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;
            user.Password = request.Password;

            _context.Update(user);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(User request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Password = request.Password
            };

            _context.Add(user);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
