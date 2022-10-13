using Application.DTOs;
using Application.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCourseTwo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("login")]   
        public async Task<ActionResult> Login([FromBody] UserDTO userDTO)
        {
            var result = await _userService.GenerateToken(userDTO);
            if (result.IsSuccess) return Ok(result.Data);
            return BadRequest(result);
        }
    }
}
