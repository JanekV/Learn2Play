using System.Threading.Tasks;
using Contracts.Base;
using Contracts.BLL.Base.Services;
using Contracts.DAL.Base;

namespace Contrtacts.BLL.Base
{
    public interface IBaseBLL : ITrackableInstance
    {
        IBaseEntityService<TEntity> BaseEntityService<TEntity>() 
            where TEntity : class, IDomainEntity, new();
        
        Task<int> SaveChangesAsync();   
    }

}