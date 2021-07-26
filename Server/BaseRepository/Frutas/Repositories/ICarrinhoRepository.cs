using Frutas.Models;
using Base.Repository.BaseSqlRepository;
using System.Threading.Tasks;
using Frutas.Models.ViewModel;

namespace Frutas.Repositories {
    public interface ICarrinhoRepository: ISqlRepository<Carrinho>
    {
        Task<Carrinho> GetEmAberto();
        Task<CarrinhoViewModel> GetCarrinho();
    }
}