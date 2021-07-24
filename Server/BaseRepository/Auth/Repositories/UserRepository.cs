using Auth.Models;
using Auth.Commons;
using Base.Repository.Models;
using Base.Repository.BaseSqlRepository;
using Isopoh.Cryptography.Argon2;
using System.Linq;
using System.Threading.Tasks;


namespace Auth.Repositories
{
    public class UserRepository: SqlRepository<User>, IUserRepository
    {
        private readonly UserDbContext _userDbContext;
        public UserRepository(UserDbContext userDbContext) : base(userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public async Task<User> Login(string username, string password)
        {
            var func = await Search(entidade => 
                 entidade.Username == username);

            var usuario = func.FirstOrDefault();

            if ((usuario != null)&&(usuario.Id > 0))
            {
                bool verified = Argon2.Verify(usuario.Password, password);

                if (verified)
                    return usuario;
                else
                    return null;
            }
            return null;            
        }

        public bool Exists(long id, string username )
        {
            var func = Search(entidade =>
              entidade.Username == username
              && ((id > 0) && (entidade.Id != id))).Result;
            return func.Count() > 0;
        }

    }
}