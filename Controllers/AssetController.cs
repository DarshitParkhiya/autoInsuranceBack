using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApi.Models.AssetModels;
using TestApi.Models.RequestModels;
using TestApi.Services.AssetRepo;
using TestApi.Services.Common;
using TestApi.Services.RequestRepo;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService<Asset> _assettService;
        private readonly ICommonService<OrganizationModel> _organizationModel;

        public AssetController(IAssetService<Asset> assetService, ICommonService<OrganizationModel> organizationModel)
        {
            _assettService = assetService;
            _organizationModel = organizationModel;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _assettService.GetAll();
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
                var data = await _assettService.GetByID(id);
                return new OkObjectResult(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Asset oUser)
        {
            try
            {
                OrganizationModel og = new OrganizationModel();
                og = (OrganizationModel)oUser;
                await _organizationModel.Add(og);
                //await _assettService.Add(oUser);

                return new OkObjectResult(oUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] Asset model)
        {
            try
            {
                return new OkObjectResult(await _assettService.Update(model));
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
                return new OkObjectResult(await _assettService.Delete(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }
    }
}