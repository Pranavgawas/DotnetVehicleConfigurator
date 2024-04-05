using demo1.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vehical_config_1.Controllers
{
    [Route("")]
    [ApiController]
    public class VariantController : ControllerBase
    {
        private readonly IVariantRepository _repo;

        public VariantController(IVariantRepository _repository)
        {
            _repo = _repository;
        }

        // GET api/<VariantController>/5
        [HttpGet]
        [Route("api/variants/{seg_id}/{mfg_id}")]

        public async Task<IActionResult> GetModelsByMfgandSegID(int mfg_id, int seg_id)
        {
            var models = await _repo.getvariant(mfg_id, seg_id);
            return Ok(models);
        }


    }
}
