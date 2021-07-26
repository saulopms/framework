using Frutas.Models;
using Frutas.Commons;
using Base.Repository.BaseSqlRepository;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Frutas.Models.ViewModel;

namespace Frutas.Repositories
{
    public class CarrinhoRepository: SqlRepository<Carrinho>, ICarrinhoRepository
    {
        private readonly FrutasDbContext _FrutaDbContext;
        public CarrinhoRepository(FrutasDbContext FrutaDbContext) : base(FrutaDbContext)
        {
            _FrutaDbContext = FrutaDbContext;
        }

        public async Task<Carrinho> GetEmAberto()
        {
            var entity = _FrutaDbContext.Carrinho.AsNoTracking()
                       .Include(it => it.Itens)
                       .Where(x => x.Finalizado == false).FirstOrDefault();
            return entity;
        }

        public async Task<CarrinhoViewModel> GetCarrinho()
        {
            var carrinho = (from c in _FrutaDbContext.Carrinho.AsNoTracking().Include(i => i.Itens)
                            join it in _FrutaDbContext.ItemCarrinho.AsNoTracking() on c.Id equals it.CarrinhoId
                            join f in _FrutaDbContext.Frutas.AsNoTracking() on it.FrutaId equals f.Id
                            select new CarrinhoViewModel
                            {
                                Finalizado = c.Finalizado,
                                TotalPedido = c.TotalPedido,
                                Itens = c.Itens.Select(
                                     it => new Models.Dto.FrutaDto()
                                     {
                                         Descricao = f.Descricao,
                                         Foto = f.Foto,
                                         Id = it.Id,
                                         Nome = f.Nome,
                                         Quantidade = it.Quantidade,
                                         Valor = it.Valor
                                     }).ToList()
                            }).ToList();
            return carrinho.FirstOrDefault();
        }
    }
}