using demo1.DAL;
using demo1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vehicle.Models;

namespace demo1.Repositories
{
    public class SqlAlternateComponentRepo : IAlternateComponent
    {
        private readonly ApplicationDbContext _context;
        public SqlAlternateComponentRepo(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<ActionResult<IEnumerable<Vehicle_detail>>> GetCompnameByExt(int model_id)
        {
            return await _context.Vehicle_Details
               .Include(v => v.component)
               .Where(v => v.comp_type == "e" && v.model_id == model_id)
               .ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Vehicle_detail>>> GetCompnameByInt(int model_id)
        {
            return await _context.Vehicle_Details
                .Include(v => v.component)
                .Where(v => v.comp_type == "i" && v.model_id == model_id)
                .ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Vehicle_detail>>> GetCompnameByStd(int model_id)
        {
            return await _context.Vehicle_Details
                .Include(v => v.component)
                .Where(v => v.comp_type == "s" && v.model_id == model_id)
                .ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<SubCompPrice>>> GetConfigurableConfig(int modelId, string compName)
        {
            var subCompPrices = await (
                from c in _context.Components
                join a in _context.Alternate_Components on c.comp_id equals a.alt_comp_id
                where a.model_id == modelId && c.comp_name == compName
                select new SubCompPrice(c.sub_type, a.delta_price, a.alt_id)
            ).ToListAsync();

            return subCompPrices;

        }

        public async Task<ActionResult<IEnumerable<SubCompPrice>>> GetDefaultCompname(int modelId)
        {
            var subCompPrices = await(
                from c in _context.Components
                join a in _context.Alternate_Components on c.comp_id equals a.alt_comp_id
                where a.model_id == modelId
                select new SubCompPrice(c.sub_type, a.delta_price, a.alt_id)
            ).ToListAsync();

            return subCompPrices;
        }
    }
}
