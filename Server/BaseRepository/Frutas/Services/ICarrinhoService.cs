using Base.Repository;
using Frutas.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Frutas.Services {
    public interface ICarrinhoService : IBaseService<long, CarrinhoDto> {

        Task<IEnumerable<CarrinhoDto>> GetAll();
        Task<CarrinhoDto> GetEmAberto();
        CarrinhoDto Comprar(long idfruta);
        Task<CarrinhoViewDto> GetCarrinho();
    }
}