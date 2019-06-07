using System.Threading.Tasks;
using ee.itcollege.javalg.Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO.DomainEntityDTOs;

namespace Contracts.BLL.App.Services
{
    public interface IVideoService : IBaseEntityService<BLLAppDTO.Video>, IVideoRepository<BLLAppDTO.Video>
    {
        Task<BLLAppDTO.Video> FindAsyncWithIncludeAsync(int id);

        void RemoveTabsForVideo(int id);
    }
}