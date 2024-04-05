using demo1.Models;
using demo1.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo1.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class Alternate_ComponentController : ControllerBase
    {
        private readonly IAlternateComponent _repository;

        public Alternate_ComponentController(IAlternateComponent repository)
        {
            _repository = repository;
        }
        [HttpGet("GetCompnameByExt/{modelId:int}")]
        public async Task<ActionResult<IEnumerable<Vehicle_detail>>> GetCompnameByExt(int modelId)
        {
            var vehicleDetails = await _repository.GetCompnameByExt(modelId);
            return Ok(vehicleDetails);
        }
        [HttpGet("GetCompnameByInt/{modelId:int}")]
        public async Task<ActionResult<IEnumerable<Vehicle_detail>>> GetCompnameByInt(int modelId)
        {
            var vehicleDetails = await _repository.GetCompnameByInt(modelId);
            return Ok(vehicleDetails);
        }
        [HttpGet("GetCompnameByStd/{modelId:int}")]
        public async Task<ActionResult<IEnumerable<Vehicle_detail>>> GetCompnameByStd(int modelId)
        {
            var vehicleDetails = await _repository.GetCompnameByStd(modelId);
            return Ok(vehicleDetails);
        }
        [HttpGet("GetConfigurableConfig/{modelId:int}/{CompName}")]
        public async Task<ActionResult<IEnumerable<Vehicle_detail>>> GetConfigurableConfig(int modelId, String compName)
        {
            var vehicleDetails = await _repository.GetConfigurableConfig(modelId,compName);
            return Ok(vehicleDetails);
        }
    }
}
