using System.Threading.Tasks;
using Contracts.Base;
using Contracts.DAL.Base;
using Contrtacts.BLL.Base.Services;

namespace Contrtacts.BLL.Base
{
    public interface IBaseBLL : ITrackableInstance
    {
        IBaseEntityService<TEntity> BaseEntityService<TEntity>() 
            where TEntity : class, IBaseEntity, new();
        
        Task<int> SaveChangesAsync();   
    }

}