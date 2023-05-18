using AutoMapper;
using DTO;
using entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IMapper _mapper;

        private readonly IUsersService _usersService;

        private readonly ILogger<UsersController> _logger;

        public UsersController(IUsersService usersService, IMapper mapper, ILogger<UsersController> logger)
        {
            _usersService = usersService;
            _mapper = mapper;
            _logger = logger;
        }

        // POST api/<UserController>
        [HttpPost("signIn")]
        public async Task<ActionResult<UserDto>> SignIn([FromBody] UserLoginDto userFromBody)
        {
            _logger.LogInformation($"user {userFromBody.Email} try to sign in");
            User user = await _usersService.SignIn(_mapper.Map<UserLoginDto, User>(userFromBody));
            if (user == null)
                return Unauthorized();
            return Ok(_mapper.Map<User, UserDto>(user));

        }

        [HttpPost("signUp")]
        public async Task<ActionResult<UserDto>> SignUp([FromBody] User newUser)
        {
            User userCreated = await _usersService.SignUp(newUser);
            if (userCreated != null)
                return Ok(_mapper.Map<User, UserDto>(userCreated));
            return BadRequest();
        }


        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id, [FromBody] User userToUpdate)
        {
            if (await _usersService.UpdateUser(id, userToUpdate))
                return Ok(userToUpdate);
            return BadRequest();
        }
    }
}
