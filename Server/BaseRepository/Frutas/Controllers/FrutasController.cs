using System.Collections.Generic;
using System.Threading.Tasks;
using Base.Repository.Utils;
using Frutas.Models.Dto;
using Frutas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Frutas.Controller
{
    [Route("api/frutas")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class FrutaController : ControllerBase
    {
        private readonly IFrutaService _FrutaService;
        public FrutaController(IFrutaService FrutaService)
        {
            _FrutaService = FrutaService;
        }

        [HttpGet("{id}")]
        [Authorize]
        public Task<FrutaDto> GetById(long id)
        {
            return _FrutaService.GetById(id);
        }

        [HttpGet]
        [Authorize]
        public Task<IEnumerable<FrutaDto>> GetAll()
        {
            return _FrutaService.GetAll();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Save(FrutaDto Fruta)
        {
            var FrutaSave = _FrutaService.Save(Fruta);
            return Created(UrlUtils.FromUri(Request, FrutaSave.Id), FrutaSave);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task Delete(long id)
        {
            await _FrutaService.Delete(id);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task Update(long id, FrutaDto Fruta)
        {
            await _FrutaService.Update(id, Fruta);
        }
    }
}