using demo1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vehicle.Models;
using System.Collections.Generic;

namespace demo1.Repositories
{
    public class SqlVehicleDetailRepository : IVehicleDetail
    {
        private readonly ApplicationDbContext _context;
        public SqlVehicleDetailRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<ActionResult<IEnumerable<Vehicle_detail>>> getVehicleDetailsByCore(int model_id)
        {
            return await _context.Vehicle_Details
               .Where(vd => vd.comp_type == "c" && vd.model_id == model_id)
                .ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Vehicle_detail>>> getVehicleDetailsByExterior(int model_id)
        {
            return await _context.Vehicle_Details
                .Where(vd => vd.comp_type == "e" && vd.model_id == model_id)
                .ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Vehicle_detail>>> getVehicleDetailsByInterior(int model_id)
        {
            return await _context.Vehicle_Details
               .Where(vd => vd.comp_type == "i" && vd.model_id == model_id)
                .ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Vehicle_detail>>> getVehicleDetailsByStandard(int model_id)
        {
            return await _context.Vehicle_Details
               .Where(vd => vd.comp_type == "s" && vd.model_id == model_id)
                .ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Vehicle_detail>>> getVehicleDetailsByPrice(int modelId)
        {
            var vehicleDetails = await _context.Vehicle_Details
                .Where(v => v.model_id == modelId)
                .Select(v => new Vehicle_detail
                {
                    price = v.price
                })
                .ToListAsync();

            return vehicleDetails;
        }
    }
}
