using Frutas.Models;
using Base.Repository.BaseSqlRepository;
using System.Threading.Tasks;
using Frutas.Models.Dto;

namespace Frutas.Repositories {
    public interface ICarrinhoRepository: ISqlRepository<Carrinho>
    {
        Task<Carrinho> GetEmAberto();
        Task<CarrinhoViewDto> GetCarrinho();
    }
}