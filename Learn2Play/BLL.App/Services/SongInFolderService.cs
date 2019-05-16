using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using ee.itcollege.javalg.BLL.Base.Services;

namespace BLL.App.Services
{
    public class SongInFolderService : BaseEntityService<BLL.App.DTO.DomainEntityDTOs.SongInFolder, DAL.App.DTO.DomainEntityDTOs.SongInFolder, IAppUnitOfWork>, ISongInFolderService
    {
        public SongInFolderService(IAppUnitOfWork uow) : base(uow, new SongInFolderMapper())
        {
            ServiceRepository = Uow.SongInFolders;
        }

        public async Task<List<BLL.App.DTO.DomainEntityDTOs.SongInFolder>> AllAsyncWithInclude()
        {
            return (await Uow.SongInFolders.AllAsyncWithInclude()).Select(SongInFolderMapper.MapFromDAL).ToList();
        }
    }
}