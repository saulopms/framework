using Frutas.Models;
using Frutas.Repositories;
using Frutas.Commons;
using Base.Repository.BaseSqlRepository;


namespace Frutas.Repositories
{
    public class FrutaRepository: SqlRepository<Fruta>, IFrutaRepository
    {
        private readonly FrutasDbContext _FrutaDbContext;
        public FrutaRepository(FrutasDbContext FrutaDbContext) : base(FrutaDbContext)
        {
            _FrutaDbContext = FrutaDbContext;
        }
    }
}