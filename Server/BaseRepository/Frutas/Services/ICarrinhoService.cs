using Base.Repository;
using Frutas.Models;
using Frutas.Models.Dto;
using Frutas.Models.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Frutas.Services {
    public interface ICarrinhoService : IBaseService<long, CarrinhoDto> {

        Task<IEnumerable<CarrinhoDto>> GetAll();
        Task<CarrinhoDto> GetEmAberto();
        Task<CarrinhoDto> Comprar(long idfruta);
        Task<CarrinhoViewModel> GetCarrinho();
    }
}