using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.javalg.Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface ITabRepository : ITabRepository<DALAppDTO.DomainEntityDTOs.Tab>
    {
        Task<DALAppDTO.DomainEntityDTOs.Tab> FindAsyncWithIncludeAsync(int id);
    }
    public interface ITabRepository<TDALEntity>: IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {
        Task<List<TDALEntity>> AllAsyncWithInclude();
    }
}