using System.Threading.Tasks;
using ee.itcollege.javalg.Contracts.Base;
using ee.itcollege.javalg.Contracts.BLL.Base.Services;
using ee.itcollege.javalg.Contracts.DAL.Base;

namespace ee.itcollege.javalg.Contracts.BLL.Base
{
    public interface IBaseBLL : ITrackableInstance
    {
        /*
        IBaseEntityService<TEntity> BaseEntityService<TEntity>() 
            where TEntity : class, IDomainEntity, new();
        */

        Task<int> SaveChangesAsync(); 
        int SaveChanges();
    }

}