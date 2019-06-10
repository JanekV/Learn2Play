using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.javalg.DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Folder = DAL.App.DTO.DomainEntityDTOs.Folder;

namespace DAL.App.EF.Repositories
{
    public class UserFolderRepository: BaseRepository<DAL.App.DTO.DomainEntityDTOs.UserFolder, Domain.UserFolder, AppDbContext>, IUserFolderRepository
    {
        public UserFolderRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new UserFolderMapper())
        {
        }

        public async Task<List<DAL.App.DTO.DomainEntityDTOs.UserFolder>> AllAsyncWithInclude()
        {
            return await RepositoryDbSet
                .Include(uf => uf.AppUser)
                .Include(uf => uf.Folder)
                .Select(e => UserFolderMapper.MapFromDomain(e))
                .ToListAsync();
        }

        public async Task AddSongToFoldersAsync(int userId, int songId, int[] folderIds)
        {
            var song = await RepositoryDbContext.Songs.FindAsync(songId);
            foreach (var id in folderIds)
            {
                var userFolder = await RepositoryDbSet.FirstOrDefaultAsync(uf => uf.AppUserId == userId && uf.FolderId == id);
                if (userFolder == null) continue;
                var songInFolder =
                    await RepositoryDbContext.SongInFolders.FirstOrDefaultAsync(sif => sif.FolderId == id);
                if (songInFolder == null)
                {
                    await RepositoryDbContext.SongInFolders.AddAsync(new SongInFolder()
                    {
                        FolderId = id,
                        Folder = userFolder.Folder,
                        Song = song,
                        SongId = songId
                    });
                }
            }
        }

        public async Task<DAL.App.DTO.DomainEntityDTOs.UserFolder> FindAsync(int id)
        {
            var userFolder = await RepositoryDbSet
                .Include(uf => uf.AppUser)
                .Include(uf => uf.Folder)
                .FirstOrDefaultAsync(uf => uf.Id == id);
            
            
            return UserFolderMapper.MapFromDomain(userFolder);
        }
    }
}