using Frutas.Models;
using Frutas.Commons;
using Base.Repository.BaseSqlRepository;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Frutas.Models.Dto;
using System;

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

        public async Task<CarrinhoViewDto> GetCarrinho()
        {
            var carrinho = (from c in _FrutaDbContext.Carrinho.AsNoTracking().Include(i => i.Itens)
                       select new CarrinhoViewDto()
                       {
                           Finalizado = c.Finalizado,
                           TotalPedido = c.TotalPedido,
                           Itens = c.Itens.Select( it => new 
                           {
                               Fruta = from f in _FrutaDbContext.Frutas.AsNoTracking().Where(f => f.Id == it.FrutaId) select new { Descricao = f.Descricao, Foto = f.Foto, Id = f.Id, Nome = f.Nome },
                               Valor = it.Valor,
                               Quantidade = it.Quantidade,
                               Foto = "",
                               Nome = "",
                               Descricao = "",
                               Id = it.Id
                           }
                           ).Select( it => new FrutaDto()
                           {
                               Descricao = it.Fruta.FirstOrDefault().Descricao,
                               Foto = it.Fruta.FirstOrDefault().Foto,
                               Valor = it.Valor,
                               Nome = it.Fruta.FirstOrDefault().Nome,
                               Quantidade = it.Quantidade,
                               Id = it.Fruta.FirstOrDefault().Id
                           }).ToList()
                       });

            return carrinho.FirstOrDefault();
        }
    }
}