using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.App.DTO.DomainEntityDTOs;
using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using DAL.App.DTO;
using ee.itcollege.javalg.BLL.Base.Services;
using FolderWithSong = BLL.App.DTO.FolderWithSong;

namespace BLL.App.Services
{
    public class FolderService : BaseEntityService<BLL.App.DTO.DomainEntityDTOs.Folder, DAL.App.DTO.DomainEntityDTOs.Folder, IAppUnitOfWork>, IFolderService
    {
        public FolderService(IAppUnitOfWork uow) : base(uow, new FolderMapper())
        {
            ServiceRepository = Uow.Folders;
        }

        public async Task<List<FolderWithSong>> AllWithSongsAsync(int userId)
        {
            return (await Uow.Folders.AllWithSongsAsync(userId)).ConvertAll(FolderMapper.MapFromDAL);
        }

        public async Task<FolderWithSong> FindFolderWithSongsAsync(int folderId, int userId)
        {
            return FolderMapper.MapFromDAL(await Uow.Folders.FindFolderWithSongsAsync(folderId, userId));
        }

        public async Task<List<Folder>> AllAsync(int userId)
        {
            return (await Uow.Folders.AllAsync(userId)).ConvertAll(FolderMapper.MapFromDAL);
        }

        public async Task<Folder> AddForUserAsync(Folder folder, int userId)
        {
            return FolderMapper.MapFromDAL(await Uow.Folders.AddForUserAsync(FolderMapper.MapFromBLL(folder), userId));
        }

        public async Task<Folder> UpdateForUser(Folder folder, int userId)
        {
            return FolderMapper.MapFromDAL(await Uow.Folders.UpdateForUser(FolderMapper.MapFromBLL(folder), userId));
        }

        public async Task<List<Folder>> AllWithSongId(int songId, int userId)
        {
            return (await Uow.Folders.AllWithSongId(songId, userId)).ConvertAll(FolderMapper.MapFromDAL);
        }
    }
}