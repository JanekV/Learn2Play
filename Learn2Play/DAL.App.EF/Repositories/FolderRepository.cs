using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using ee.itcollege.javalg.DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Folder = DAL.App.DTO.DomainEntityDTOs.Folder;

namespace DAL.App.EF.Repositories
{
    public class FolderRepository: BaseRepository<DAL.App.DTO.DomainEntityDTOs.Folder, Domain.Folder, AppDbContext>, IFolderRepository
    {
        public FolderRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new FolderMapper())
        {
        }

        public async Task<List<FolderWithSong>> AllWithSongsAsync(int userId)
        {
            var res = await RepositoryDbContext.UserFolders
                .Where(uf => uf.AppUserId == userId)
                .Select(uf => new
                {
                    Id = uf.FolderId,
                    FolderType = uf.Folder.FolderType.ToString(),
                    Name = uf.Folder.Name,
                    Comment = uf.Folder.Comment,
                    Songs = uf.Folder.SongInFolders.Select(sif => sif.Song).ToList()
                })
                .ToListAsync();
            var resultList = res.Select(f => new FolderWithSong()
            {
                Id = f.Id,
                FolderType = f.FolderType,
                Name = f.Name,
                Comment = f.Comment,
                Songs = f.Songs.ConvertAll(SongMapper.MapFromDomain)
            }).ToList();

            return resultList;
        }

        public async Task<FolderWithSong> FindFolderWithSongsAsync(int folderId, int userId)
        {
            var res = await RepositoryDbContext.UserFolders
                .Where(uf => uf.AppUserId == userId && uf.FolderId == folderId)
                .Select(uf => new
                {
                    Id = uf.FolderId,
                    FolderType = uf.Folder.FolderType.ToString(),
                    Name = uf.Folder.Name,
                    Comment = uf.Folder.Comment,
                    Songs = uf.Folder.SongInFolders.Select(sif => sif.Song).ToList()
                })
                .FirstOrDefaultAsync();
            var fws = new FolderWithSong()
            {
                Id = res.Id,
                FolderType = res.FolderType,
                Name = res.Name,
                Comment = res.Comment,
                Songs = res.Songs.ConvertAll(SongMapper.MapFromDomain)
            };
            return fws;
        }

        public async Task<List<Folder>> AllAsync(int userId)
        {
            return (await RepositoryDbContext.UserFolders
                .Where(uf => uf.AppUserId == userId)
                .Select(uf => uf.Folder)
                .ToListAsync()).ConvertAll(FolderMapper.MapFromDomain);
        }
    }
}