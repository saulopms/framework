using Base.Repository.Models;

namespace Base.Repository
{
    public interface ISqlRepository<T> where T : Entity {
        T GetById (long id);
        T Save (T entidade);
        void Delete (T entidade);
        void Update (T entidade);
    }
}