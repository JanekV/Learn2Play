using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.App.DTO.DomainEntityDTOs;
using ee.itcollege.javalg.Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;
using Folder = Domain.Folder;

namespace Contracts.DAL.App.Repositories
{
    public interface IFolderRepository: IFolderRepository<DALAppDTO.DomainEntityDTOs.Folder>
    {
        Task<List<DALAppDTO.FolderWithSong>> AllWithSongsAsync(int userId);
        Task<DALAppDTO.FolderWithSong> FindFolderWithSongsAsync(int folderId, int userId);
        Task<List<DALAppDTO.DomainEntityDTOs.Folder>> AllAsync(int userId);
        Task<DALAppDTO.DomainEntityDTOs.Folder> AddForUserAsync(DALAppDTO.DomainEntityDTOs.Folder folder, int userId);
        Task<DALAppDTO.DomainEntityDTOs.Folder> UpdateForUser(DALAppDTO.DomainEntityDTOs.Folder folder, int userId);
        Task<List<DALAppDTO.DomainEntityDTOs.Folder>> AllWithSongId(int songId, int userId);
    }
    
    public interface IFolderRepository<TDALEntity>: IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {
    }
}