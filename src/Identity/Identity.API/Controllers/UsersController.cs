using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Identity.API.Dtos;
using Identity.API.Entities;
using Identity.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        [HttpPost]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<User>> AddUser(UserDto u)
        {
            User user = new User(u);
            if (await _userRepository.AddUser(user))
            {
                return Ok("A new user was added successfully!");
            }

            return BadRequest("Oops, somthing wring happened!");
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<UserDto>>> GetUsers()
        {
            IEnumerable<User> innerUsers = await _userRepository.GetUsers();
            ICollection<UserDto> users = new LinkedList<UserDto>();

            foreach (User u in innerUsers)
            {
                users.Add(new UserDto()
                {
                    Name = u.Name,
                    Surname = u.Surname,
                    Birthday = u.Birthday,
                    GroupId = u.GroupId
                });
            }
            return Ok(users);
        }
    }
}
