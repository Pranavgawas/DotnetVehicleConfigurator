using demo1.Models;
using demo1.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo1.Controller
{
    [Route("")]
    [ApiController]
    public class vehicle_detailController : ControllerBase
    {
        private readonly IVehicleDetail _vehicleDetailRepository;

        public vehicle_detailController(IVehicleDetail Repository)
        {
            _vehicleDetailRepository = Repository;
        }

        [HttpGet("api/componentbyc/{modelId:int}")]
        public async Task<ActionResult<IEnumerable<Vehicle_detail>>> getVehicleDetailsByCore(int modelId)
        {
            var vehicleDetails = await _vehicleDetailRepository.getVehicleDetailsByCore(modelId);
            return Ok(vehicleDetails);
        }
        [HttpGet("api/componentbye/{modelId:int}")]
        public async Task<ActionResult<IEnumerable<Vehicle_detail>>> getVehicleDetailsByExterior(int modelId)
        {
            var vehicleDetails = await _vehicleDetailRepository.getVehicleDetailsByExterior(modelId);
            return Ok(vehicleDetails);
        }
        [HttpGet("api/componentbyi/{modelId:int}")]
        public async Task<ActionResult<IEnumerable<Vehicle_detail>>> getVehicleDetailsByInterior(int modelId)
        {
            var vehicleDetails = await _vehicleDetailRepository.getVehicleDetailsByInterior(modelId);
            return Ok(vehicleDetails);
        }
        [HttpGet("api/componentbys/{modelId:int}")]
        public async Task<ActionResult<IEnumerable<Vehicle_detail>>> getVehicleDetailsByStandard(int modelId)
        {
            var vehicleDetails = await _vehicleDetailRepository.getVehicleDetailsByStandard(modelId);
            return Ok(vehicleDetails);
        }
        [HttpGet("componentbyp/{modelId:int}")]
        public async Task<ActionResult<IEnumerable<Vehicle_detail>>> getVehicleDetailsByPrice(int modelId)
        {
            var vehicleDetails = await _vehicleDetailRepository.getVehicleDetailsByPrice(modelId);
            return Ok(vehicleDetails);
        }
    }
}
