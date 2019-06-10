using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using ee.itcollege.javalg.BLL.Base.Services;

namespace BLL.App.Services
{
    public class UserFolderService : BaseEntityService<BLL.App.DTO.DomainEntityDTOs.UserFolder, DAL.App.DTO.DomainEntityDTOs.UserFolder, IAppUnitOfWork>, IUserFolderService
    {
        public UserFolderService(IAppUnitOfWork uow) : base(uow, new UserFolderMapper())
        {
            ServiceRepository = Uow.UserFolders;
        }

        public async Task<List<BLL.App.DTO.DomainEntityDTOs.UserFolder>> AllAsyncWithInclude()
        {
            return (await Uow.UserFolders.AllAsyncWithInclude()).Select(UserFolderMapper.MapFromDAL).ToList();
        }

        public async Task AddSongToFoldersAsync(int userId, int songId, int[] folderIds)
        {
            await Uow.UserFolders.AddSongToFoldersAsync( userId, songId, folderIds);
        }
    }
}