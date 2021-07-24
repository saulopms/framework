using System.Threading.Tasks;

namespace Base.Repository
{
    public interface IBaseService<Id, T> {
        Task<T> GetById (Id id);
        Task<T> Save (T entidade);
        Task Delete (Id id);
        Task Update (Id id,T entidade);
    }
}