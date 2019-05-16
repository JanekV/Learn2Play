using ee.itcollege.javalg.Contracts.DAL.Base;

namespace ee.itcollege.javalg.Contracts.BLL.Base.Helpers
{
    public interface IBaseServiceProvider
    {
        TService GetService<TService>();
        
        // IBaseEntityService<TEntity> GetEntityService<TEntity>() where TEntity : class, IBaseEntity, new();
    }
}