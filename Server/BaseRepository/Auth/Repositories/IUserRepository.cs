using Auth.Models;
using Base.Repository.BaseSqlRepository;
using System.Threading.Tasks;

namespace Auth.Repositories {
    public interface IUserRepository: ISqlRepository<User>
    {
        Task<User> Login(string username, string password);
        bool Exists(long id, string username);
    }
}