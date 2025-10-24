using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Social.Application.DTO;
using Social.Application.Services.Interface;

namespace Social.Api.Controllers
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);

        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int userId)
        {
            var user = await _userService.GetById(userId);
            if(User == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserDTO userDTO)
        {
            var user = await _userService.Post(userDTO);
            return Ok(user);

        }

        [HttpPut]
        public async Task<IActionResult> Put(UserUpdateDTO userDTO)
        {
            var user = await _userService.Put(userDTO);
            return Ok(user);

        }
        [HttpPut("DeactivateUser/{userId}")]
        public async Task<IActionResult> DeactivateUser(bool isActive, [FromRoute] int userId)
        {
            try
            {
                var response = await _userService.DeactivateUser(isActive, userId);
                return Ok(response);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int userId)
        {
             await _userService.Delete(userId);
            return Ok();

        }
    }
}
