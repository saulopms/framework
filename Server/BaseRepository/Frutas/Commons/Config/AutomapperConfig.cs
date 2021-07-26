using AutoMapper;
using Frutas.Models;
using Frutas.Models.Dto;

namespace Frutas.Commons.Config {
    public class AutomapperConfig : Profile {
        public AutomapperConfig () {
            CreateMap<Carrinho, CarrinhoDto>().ReverseMap();
            CreateMap<Fruta, FrutaDto>().ReverseMap();
        }
    }
}