using ee.itcollege.javalg.Contracts.Base;
using ee.itcollege.javalg.Contracts.DAL.Base;
using ee.itcollege.javalg.Contracts.DAL.Base.Repositories;

namespace ee.itcollege.javalg.Contracts.BLL.Base.Services
{
    public interface IBaseService : ITrackableInstance
    {
    }
    
    public interface IBaseEntityService<TBLLEntity> :IBaseService, IBaseRepository<TBLLEntity> 
        where TBLLEntity : class, new()
    {
        
    }

}