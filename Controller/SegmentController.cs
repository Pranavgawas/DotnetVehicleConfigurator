using demo1.Models;
using demo1.Repositories;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vehical_config_1.Controllers
{
    [Route("api/segments")]
    [ApiController]
    public class SegmentController : ControllerBase
    {
        private readonly ISegmentRepository _repo;

        public SegmentController(ISegmentRepository repository)
        {
            _repo = repository;
        }

        // GET: api/<SegmentController>
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Segment>?>> GetSegment()

        {
            if (await _repo.GetAllSegment() == null)
            {
                return NotFound();
            }

            return await _repo.GetAllSegment();

        }



    }
}
