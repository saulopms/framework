using Base.Repository;
using Frutas.Models;
using Frutas.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Frutas.Services {
    public interface IFrutaService : IBaseService<long, FrutaDto> {

        Task<IEnumerable<FrutaDto>> GetAll();
        Task<FrutaDto> Comprar(long id);
        Task Devolver(long id, FrutaDto fruta);
    }
}