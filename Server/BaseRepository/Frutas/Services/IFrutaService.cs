using Base.Repository;
using Frutas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Frutas.Services {
    public interface IFrutaService : IBaseService<long, Fruta> {

        Task<IEnumerable<Fruta>> GetAll();
    }
}