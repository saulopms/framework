using Auth.Models;
using Auth.Repositories;
using AutoMapper;
using Base.Repository;
using Isopoh.Cryptography.Argon2;
using System.Net;
using Auth.Models.Validator;
using System.Threading.Tasks;
using Auth.Models.DTO;
using Base.Repository.ExceptionUtils;

namespace Auth.Services {
    public class UserService : BaseServiceValidation, IUserService {
        private readonly IUserRepository userRepository;
        private readonly ITokenService tokenService;
        private readonly IMapper _mapper;
        public UserService (IUserRepository UserRepository,
            IMapper Mapper, ITokenService TokenService) {
            userRepository = UserRepository;
            _mapper = Mapper;
            tokenService = TokenService;
        }
        public async Task<User> GetById(long id)
        {
            var entidade = await userRepository.GetById(id);
            return entidade;
        }

        public async Task<string> Login(string username, string password)
        {
            var user = await userRepository.Login(username, password);
            if(user == null)
                throw new CustomException(MessageException.SENHAS_NAO_CONFEREM,
                    HttpStatusCode.BadRequest);
            var resposta = _mapper.Map<UserDto>(user);        
            if ((user != null) && (user.Id > 0))
            {
                return tokenService.GenerateToken(resposta);
            }
            return "";            
        }

        public Task<User> Save(User entidade)
        {
            if (!ExecutarValidacao(new UserValidator(), entidade))
                throw new CustomException(GetError(), HttpStatusCode.BadRequest);
            if (userRepository.Exists(0, entidade.Username))
                throw new CustomException(MessageException.ERRO_SERVIDOR,
                    HttpStatusCode.BadRequest);
            string passwordHash = Argon2.Hash(entidade.Password);
            entidade.Password = passwordHash;
            return userRepository.Save(entidade);
        }

        public async Task Update(long id, User entidade)
        {
            var userOriginal = userRepository.GetById(id).Result;
            if (userOriginal == null)
                throw new CustomException(MessageException.OBJECT_NOT_FOUND_EXCEPTION,
                    HttpStatusCode.BadRequest);          
            if (!ExecutarValidacao(new UserValidator(), entidade))
                throw new CustomException(GetError(), HttpStatusCode.BadRequest);
            if (userRepository.Exists(id, entidade.Username))
                throw new CustomException(MessageException.ERRO_SERVIDOR,
                    HttpStatusCode.BadRequest);
            entidade.Password = userOriginal.Password;
            entidade.Id = id;
            await userRepository.Update(entidade);
        }

        public Task Delete(long id)
        {
            var entidade = userRepository.GetById(id).Result;
            if (entidade == null) 
                throw new CustomException(MessageException.OBJECT_NOT_FOUND_EXCEPTION, 
                    HttpStatusCode.NotFound);
            userRepository.Delete(entidade);
            return Task.FromResult("");
        }
    }
}