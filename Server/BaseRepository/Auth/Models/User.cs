using Base.Repository.Models;

namespace Auth.Models
{
    public class User: Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
}