using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.javalg.Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using BLLAppDTO = BLL.App.DTO.DomainEntityDTOs;
using FolderWithSong = BLL.App.DTO.FolderWithSong;

namespace Contracts.BLL.App.Services
{
    public interface IFolderService : IBaseEntityService<BLLAppDTO.Folder>, IFolderRepository<BLLAppDTO.Folder>
    {
        Task<List<FolderWithSong>> AllWithSongsAsync(int userId);
        Task<FolderWithSong> FindFolderWithSongsAsync(int folderId, int userId);
        Task<List<BLLAppDTO.Folder>> AllAsync(int userId);
        Task<BLLAppDTO.Folder> AddForUserAsync(BLLAppDTO.Folder folder, int userId);
        Task<BLLAppDTO.Folder> UpdateForUser(BLLAppDTO.Folder folder, int userId);
        Task<List<BLLAppDTO.Folder>> AllWithSongId(int songId, int userId);
    }
}

