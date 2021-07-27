using System.Collections.Generic;
using System.Threading.Tasks;
using Frutas.Models;
using Frutas.Models.Dto;
using Frutas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Frutas.Controller
{
    [Route("api/carrinho")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class CarrinhoController : ControllerBase
    {
        private readonly ICarrinhoService _CarrinhoService;
        public CarrinhoController(ICarrinhoService CarrinhoService)
        {
            _CarrinhoService = CarrinhoService;
        }

        [HttpGet("{id}")]
        [Authorize]
        public Task<CarrinhoDto> GetById(long id)
        {
            return _CarrinhoService.GetById(id);
        }

        [HttpGet]
        [Authorize]
        public Task<CarrinhoViewDto> GetCarrinho()
        {
            return _CarrinhoService.GetCarrinho();
        }

        [HttpGet]
        [Authorize]
        [Route("Aberto")]
        public Task<CarrinhoDto> GetAberto()
        {
            return _CarrinhoService.GetEmAberto();
        }

        [HttpPost]
        [Authorize]
        public CarrinhoDto Save(ItemCarrinho fruta)
        {
            return _CarrinhoService.Comprar(fruta.FrutaId); 
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task Delete(long id)
        {
            await _CarrinhoService.Delete(id);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task Update(long id, CarrinhoDto Carrinho)
        {
            await _CarrinhoService.Update(id, Carrinho);
        }
    }
}