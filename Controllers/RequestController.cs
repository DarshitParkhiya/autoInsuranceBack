using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApi.Models.RequestModels;
using TestApi.Services.RequestRepo;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService<Request> _requestService;

        public RequestController(IRequestService<Request> RequestService)
        {
            _requestService = RequestService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _requestService.GetAll();
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
                var data = await _requestService.GetByID(id);
                return new OkObjectResult(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Request oUser)
        {
            try
            {
                await _requestService.Add(oUser);

                return new OkObjectResult(oUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] Request model)
        {
            try
            {
                return new OkObjectResult(await _requestService.Update(model));
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
                return new OkObjectResult(await _requestService.Delete(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }
    }
}