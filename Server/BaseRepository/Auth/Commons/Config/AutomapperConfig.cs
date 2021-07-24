using Auth.Models;
using AutoMapper;
using Auth.Models.DTO;

namespace Auth.Commons.Config {
    public class AutomapperConfig : Profile {
        public AutomapperConfig () {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}