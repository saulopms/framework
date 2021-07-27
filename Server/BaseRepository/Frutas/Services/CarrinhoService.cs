using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Base.Repository;
using Base.Repository.ExceptionUtils;
using Frutas.Models;
using Frutas.Models.Dto;
using Frutas.Repositories;


namespace Frutas.Services {
    public class CarrinhoService : BaseServiceValidation, ICarrinhoService {
        private readonly ICarrinhoRepository _Carrinhorepository;
        private readonly IFrutaService _FrutaService;
        private readonly IMapper _Imapper;

        public CarrinhoService(ICarrinhoRepository carrinhoRepository, 
            IMapper imapper, IFrutaService frutaService) {
            _Carrinhorepository = carrinhoRepository;
            _Imapper = imapper;
            _FrutaService = frutaService;
        }


        public async Task Delete (long id) 
        {
            var Carrinho = await _Carrinhorepository.GetById (id);
            if (Carrinho == null) 
                throw new CustomException (MessageException.OBJECT_NOT_FOUND_EXCEPTION, 
                    HttpStatusCode.NotFound);
            await _Carrinhorepository.Delete (Carrinho);
        }

        public async Task<CarrinhoDto> GetById (long id) 
        {
            var carrinho = await _Carrinhorepository.GetById (id);
            if (carrinho == null) 
                throw new CustomException (MessageException.OBJECT_NOT_FOUND_EXCEPTION, 
                    HttpStatusCode.NotFound);
            return _Imapper.Map<CarrinhoDto>(carrinho);
        }

        public async Task<CarrinhoDto> GetEmAberto()
        {
            var carrinho = await _Carrinhorepository.GetEmAberto();
            return _Imapper.Map<CarrinhoDto>(carrinho);
        }

        public async Task<IEnumerable<CarrinhoDto>> GetAll()
        {
            var dados = await _Carrinhorepository.Search(x => x.Id > 0);                
            return _Imapper.Map<IEnumerable<CarrinhoDto>>(dados);
        }

        public async Task<CarrinhoViewDto> GetCarrinho()
        {
            return await _Carrinhorepository.GetCarrinho();
        }

        public CarrinhoDto Comprar(long idfruta)
        {
            var aberto = GetEmAberto().Result;
            var fruta = _FrutaService.Comprar(idfruta).Result;
            try
            {
                var item = new ItemCarrinho() { FrutaId = idfruta, Quantidade = 1, Valor = fruta.Valor };
                if (aberto == null)
                {
                    List<ItemCarrinho> itens = new List<ItemCarrinho>() { item };
                    aberto = new CarrinhoDto() { Itens = itens };
                    aberto = Save(aberto).Result;
                }
                else
                {
                    var contem = false;
                    foreach(var it in aberto.Itens)
                    {
                        if(it.FrutaId == item.FrutaId)
                        {
                            it.Quantidade += 1;
                            it.Valor += item.Valor;
                            contem = true;
                            break;
                        }
                    }
                    if(!contem)
                        aberto.Itens.Add(item);
                    var total = aberto.Itens.Sum(x => x.Valor);
                    aberto.TotalPedido = total;
                    Update(aberto.Id, aberto);
                }
            }
            catch(Exception ex)
            {
                _FrutaService.Devolver(idfruta, fruta);
            }

            return aberto;
        }
        public async Task<CarrinhoDto> Save (CarrinhoDto entidade) 
        {
            var carrinho = _Imapper.Map<Carrinho>(entidade);
            var save = await _Carrinhorepository.Save (carrinho);
            var carrinhoDto = _Imapper.Map<CarrinhoDto>(save);
            return carrinhoDto;
        }

        public Task Update (long id, CarrinhoDto entidade) 
        {
            var model = _Imapper.Map<Carrinho>(entidade);
            model.Id = id;
            return _Carrinhorepository.Update(model);
        }

    }
}