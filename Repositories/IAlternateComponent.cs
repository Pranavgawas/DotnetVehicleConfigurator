using demo1.DAL;
using demo1.Models;
using Microsoft.AspNetCore.Mvc;

namespace demo1.Repositories
{
    public interface IAlternateComponent { 
    
        Task<ActionResult<IEnumerable<SubCompPrice>>> GetDefaultCompname(int modelId);
        Task<ActionResult<IEnumerable<Vehicle_detail>>> GetCompnameByExt(int model_id);
        Task<ActionResult<IEnumerable<Vehicle_detail>>> GetCompnameByStd(int model_id);
        Task<ActionResult<IEnumerable<Vehicle_detail>>> GetCompnameByInt(int model_id);
        Task<ActionResult<IEnumerable<SubCompPrice>>> GetConfigurableConfig(int modelId, string compName);
    }
}
