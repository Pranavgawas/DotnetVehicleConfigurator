using Microsoft.AspNetCore.Mvc;
using demo1.Models;
using demo1.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vehical_config_1.Controllers
{
    [Route("")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerRepository _repo;

        public ManufacturerController(IManufacturerRepository repository)
        {
            _repo = repository;
        }
        // GET: api/<ManufacturerController>
        [HttpGet("api/allmfg")]
        public async Task<ActionResult<IEnumerable<Manufacturer>?>> Getallmfg()

        {
            if (await _repo.GetAllManufacturer() == null)
            {
                return NotFound();
            }

            return await _repo.GetAllManufacturer();

        }

        [HttpGet("api/mfgbyid/{Seg_id}")]
        public async Task<IActionResult> GetManufacturersbyid(int Seg_id)
        {
            var manufacturers = await _repo.GetAllManufacturerbyid(Seg_id);

            if (manufacturers == null)
            {
                return NoContent();
            }

            return Ok(manufacturers);
        }






    }
}
