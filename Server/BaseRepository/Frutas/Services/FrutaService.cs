using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Base.Repository;
using Base.Repository.ExceptionUtils;
using Frutas.Models;
using Frutas.Models.Validator;
using Frutas.Repositories;
using Microsoft.Extensions.Configuration;


namespace Frutas.Services {
    public class FrutaService : BaseServiceValidation, IFrutaService {
        private readonly IFrutaRepository _Frutarepository;
        private readonly IConfiguration _Configuration;

        public FrutaService (IFrutaRepository FrutaRepository, 
            IConfiguration configuration) {
            _Frutarepository = FrutaRepository;
            _Configuration = configuration;
        }


        public async Task Delete (long id) 
        {
            var Fruta = await _Frutarepository.GetById (id);
            if (Fruta == null) 
                throw new CustomException (MessageException.OBJECT_NOT_FOUND_EXCEPTION, 
                    HttpStatusCode.NotFound);
            await _Frutarepository.Delete (Fruta);
        }

        public async Task<Fruta> GetById (long id) 
        {
            var Fruta = await _Frutarepository.GetById (id);
            if (Fruta == null) 
                throw new CustomException (MessageException.OBJECT_NOT_FOUND_EXCEPTION, 
                    HttpStatusCode.NotFound);
            return Fruta;
        }

        public async Task<IEnumerable<Fruta>> GetAll()
        {
            return await _Frutarepository.Search(x => x.Id > 0);
        }

        public async Task<Fruta> Save (Fruta entidade) 
        {
            if (!ExecutarValidacao (new FrutaValidator (), entidade)) 
                throw new CustomException (GetError (), HttpStatusCode.BadRequest);
            var save = await _Frutarepository.Save (entidade);
            return save;
        }

        public async Task Update (long id, Fruta entidade) 
        {
            if (!ExecutarValidacao (new FrutaValidator (), entidade)) 
                throw new CustomException (GetError (), HttpStatusCode.BadRequest);
            entidade.Id = id;
            await _Frutarepository.Update (entidade);
        }
    }
}