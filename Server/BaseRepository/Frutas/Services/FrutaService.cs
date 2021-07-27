using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Base.Repository;
using Base.Repository.ExceptionUtils;
using Frutas.Models;
using Frutas.Models.Dto;
using Frutas.Models.Validator;
using Frutas.Repositories;


namespace Frutas.Services {
    public class FrutaService : BaseServiceValidation, IFrutaService {
        private readonly IFrutaRepository _Frutarepository;
        private readonly IMapper _Imapper;

        public FrutaService (IFrutaRepository FrutaRepository, 
             IMapper Imapper) {
            _Frutarepository = FrutaRepository;
            _Imapper = Imapper;
        }


        public async Task Delete (long id) 
        {
            var Fruta = await _Frutarepository.GetById (id);
            if (Fruta == null) 
                throw new CustomException (MessageException.OBJECT_NOT_FOUND_EXCEPTION, 
                    HttpStatusCode.NotFound);
            await _Frutarepository.Delete (Fruta);
        }

        public async Task<FrutaDto> GetById (long id) 
        {
            var Fruta = await _Frutarepository.GetById (id);
            if (Fruta == null) 
                throw new CustomException (MessageException.OBJECT_NOT_FOUND_EXCEPTION, 
                    HttpStatusCode.NotFound);
            return _Imapper.Map<FrutaDto>(Fruta);
        }

        public async Task<IEnumerable<FrutaDto>> GetAll()
        {
            return _Imapper.Map<IEnumerable<FrutaDto>>(await _Frutarepository.Search(x => x.Id > 0));
        }

        public async Task<FrutaDto> Save (FrutaDto entidade) 
        {
            if (!ExecutarValidacao (new FrutaValidator (), entidade)) 
                throw new CustomException (GetError (), HttpStatusCode.BadRequest);
            var salvar = _Imapper.Map<Fruta>(entidade);
            var save = await _Frutarepository.Save (salvar);
            return _Imapper.Map<FrutaDto>(save);
        }

        public async Task Update (long id, FrutaDto entidade) 
        {
            if (!ExecutarValidacao (new FrutaValidator (), entidade)) 
                throw new CustomException (GetError (), HttpStatusCode.BadRequest);
            entidade.Id = id;
            await _Frutarepository.Update (_Imapper.Map<Fruta>(entidade));
        }

        public async Task<FrutaDto> Comprar (long id)
        {
            var fruta = GetById(id).Result;
            if (fruta == null)
                throw new CustomException("Dados não encontrados", HttpStatusCode.BadRequest);
            if (fruta.Quantidade <= 0)
                throw new CustomException(MessageException.SEM_ESTOQUE, HttpStatusCode.BadRequest);
            fruta.Quantidade--;
            await Update(id, fruta);
            return fruta;
        }

        public async Task Devolver(long id, FrutaDto fruta)
        {
            fruta.Quantidade++;
            await Update(id, fruta);
        }
    }
}