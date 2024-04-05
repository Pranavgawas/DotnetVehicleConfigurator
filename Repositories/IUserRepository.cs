using demo1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace demo1.Repositories
{
    public interface IUserRepository
    {
        Task<ActionResult<User>> AddUser(User user);
        Task<bool> ValidateUser(User user);
    }

}
