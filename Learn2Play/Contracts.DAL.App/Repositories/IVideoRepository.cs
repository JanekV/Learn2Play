using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.javalg.Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IVideoRepository : IVideoRepository<DALAppDTO.DomainEntityDTOs.Video>
    {
        Task<DALAppDTO.DomainEntityDTOs.Video> FindAsyncWithIncludeAsync(int id);
        void RemoveTabsVorVideo(int id);
    }
    public interface IVideoRepository<TDALEntity>: IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {
        Task<List<TDALEntity>> AllAsyncWithInclude();
    }
}