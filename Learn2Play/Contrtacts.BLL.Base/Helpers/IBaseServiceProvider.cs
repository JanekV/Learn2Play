using Contracts.DAL.Base;
using Contrtacts.BLL.Base.Services;

namespace Contrtacts.BLL.Base.Helpers
{
    public interface IBaseServiceProvider
    {
        TService GetService<TService>();
        IBaseEntityService<TEntity> GetEntityService<TEntity>() where TEntity : class, IBaseEntity, new();
    }
}