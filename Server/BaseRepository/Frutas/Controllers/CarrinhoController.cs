using System.Collections.Generic;
using System.Threading.Tasks;
using Base.Repository.Utils;
using Frutas.Models;
using Frutas.Models.Dto;
using Frutas.Models.ViewModel;
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
        public Task<CarrinhoDto> GetAll()
        {
            return _CarrinhoService.GetEmAberto();
        }

        [HttpGet]
        [Authorize]
        [Route("Carrinho")]
        public Task<CarrinhoViewModel> GetCarrinho()
        {
            return _CarrinhoService.GetCarrinho();
        }

        [HttpPost]
        [Authorize]
        public async Task<CarrinhoDto> Save(ItemCarrinho fruta)
        {
            return await _CarrinhoService.Comprar(fruta.FrutaId); 
            //Created(UrlUtils.FromUri(Request, CarrinhoSave.Id), CarrinhoSave);
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