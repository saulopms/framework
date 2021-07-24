using System.Threading.Tasks;
using Auth.Models;
using Auth.Models.DTO;
using Base.Repository;

namespace Auth.Services {
    public interface IUserService : IBaseService<long, User>
    {
       Task<string> Login(string username, string password);
    }
    
}