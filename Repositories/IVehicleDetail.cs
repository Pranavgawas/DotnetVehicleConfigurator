using demo1.Models;
using Microsoft.AspNetCore.Mvc;

namespace demo1.Repositories
{
    public interface IVehicleDetail
    {
        Task<ActionResult<IEnumerable<Vehicle_detail>>>getVehicleDetailsByCore(int model_id);
        Task<ActionResult<IEnumerable<Vehicle_detail>>> getVehicleDetailsByStandard(int model_id);
        Task<ActionResult<IEnumerable<Vehicle_detail>>> getVehicleDetailsByInterior(int model_id);
        Task<ActionResult<IEnumerable<Vehicle_detail>>> getVehicleDetailsByExterior(int model_id);
        Task<ActionResult<IEnumerable<Vehicle_detail>>> getVehicleDetailsByPrice(int model_id);
    }
}
