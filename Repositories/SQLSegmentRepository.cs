using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using demo1.Models;
using Vehicle.Models;
using demo1.Repositories;

namespace Vehical_config_1.Repository
{
    public class SQLSegmentRepository : ISegmentRepository
    {
        private readonly ApplicationDbContext context;

        public SQLSegmentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<ActionResult<IEnumerable<Segment>>> GetAllSegment()
        {
            if (context.Segments == null)
            {
                return null;
            }
            return await context.Segments.ToListAsync();


        }

        public async Task<ActionResult<Segment>?> GetSegment(int Id)
        {
            var segment = await context.Segments.FindAsync(Id);

            if (segment == null)
            {
                return null;
            }

            return new ActionResult<Segment>(segment);
        }



    }
}
