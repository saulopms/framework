using Auth.Models.DTO;

namespace Auth.Services
{
    public interface ITokenService
    {
        string GenerateToken(UserDto permissoes);
    }
}