﻿using KNet.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace KNet.API.Repositories
{
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var user = await _userRepository.GetUserById(id);

            if (user is null)
                return BadRequest();

            return Ok(user);
        }

        [HttpGet("email")]
        public async Task<IActionResult> Get(string email)
        {
            if (email == string.Empty)
                return BadRequest();

            var user = await _userRepository.GetUserByEmail(email);

            if (user is null)
                return BadRequest();

            return Ok(user);
        }

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var users = await _userRepository.GetAllUsers();

            if (users is null)
                return BadRequest();

            return Ok(users);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var user = await _userRepository.GetUserById(id);
            await _userRepository.Delete(user);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateUserModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await _userRepository.GetUserById(request.Id);

            if (user is null)
                return BadRequest();

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;
            user.Password = request.Password;

            await _userRepository.Update(user);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = new UserModel
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Password = request.Password
            };

            await _userRepository.Add(user);
            return Ok();
        }
    }
}
