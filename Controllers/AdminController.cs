using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TestApi.Models.AdminModels;
using TestApi.Services.AdminRepo;

namespace TestApi.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService<Admin> _adminService;

        public AdminController(IAdminService<Admin> adminService)
        {
            _adminService = adminService;
        }

        //[HttpGet("get")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _adminService.GetAll();
                return new OkObjectResult(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        //[HttpGet("getByID")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            try
            {
                var data = await _adminService.GetByID(id);
                return new OkObjectResult(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        //[HttpPost("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Admin oUser)
        {
            try
            {
                await _adminService.Add(oUser);

                return new OkObjectResult(oUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        //[HttpPut("update")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Admin model)
        {
            try
            {
                return new OkObjectResult(await _adminService.Update(model));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        //[HttpDelete("delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                return new OkObjectResult(await _adminService.Delete(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }
    }
}