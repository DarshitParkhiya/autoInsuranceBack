using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApi.Models.UserModels;
using TestApi.Services.UserRepo;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService<User> _UserService;

        public UserController(IUserService<User> UserService)
        {
            _UserService = UserService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _UserService.GetAll();
                return new OkObjectResult(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpGet("getByID")]
        public async Task<IActionResult> GetByID(string id)
        {
            try
            {
                var data = await _UserService.GetByID(id);
                return new OkObjectResult(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] User oUser)
        {
            try
            {
                await _UserService.Add(oUser);

                return new OkObjectResult(oUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] User model)
        {
            try
            {
                return new OkObjectResult(await _UserService.Update(model));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                return new OkObjectResult(await _UserService.Delete(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }
    }
}