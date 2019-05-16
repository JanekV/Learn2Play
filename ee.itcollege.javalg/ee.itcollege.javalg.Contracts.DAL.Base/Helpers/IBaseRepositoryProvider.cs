using ee.itcollege.javalg.Contracts.DAL.Base.Repositories;

namespace ee.itcollege.javalg.Contracts.DAL.Base.Helpers
{
    public interface IBaseRepositoryProvider
    {
        TRepository GetRepository<TRepository>();

        IBaseRepository<TDALEntity> GetEntityRepository<TDALEntity, TDomainEntity>()
            where TDALEntity : class, new()
            where TDomainEntity : class, IDomainEntity, new();
    }

}