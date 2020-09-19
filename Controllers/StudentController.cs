using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApi.Models.StudentModels;
using TestApi.Services.StudentRepo;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService<Student> _studentService;

        public StudentController(IStudentService<Student> studentService)
        {
            _studentService = studentService;
        }

        //[HttpGet("get")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _studentService.GetAll();
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
                var data = await _studentService.GetByID(id);
                return new OkObjectResult(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        //[HttpPost("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Student oUser)
        {
            try
            {
                await _studentService.Add(oUser);

                return new OkObjectResult(oUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpPost("auth")]
        public async Task<IActionResult> Create([FromBody] StudentAuth oUser)
        {
            try
            {
                Student student = await _studentService.authenticateStudent(oUser);

                return new OkObjectResult(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        //[HttpPut("update")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Student model)
        {
            try
            {
                return new OkObjectResult(await _studentService.Update(model));
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
                return new OkObjectResult(await _studentService.Delete(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }
    }
}