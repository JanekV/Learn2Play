using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.javalg.DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class SongInFolderRepository: BaseRepository<DAL.App.DTO.DomainEntityDTOs.SongInFolder, Domain.SongInFolder, AppDbContext>, ISongInFolderRepository
    {
        public SongInFolderRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new SongInFolderMapper())
        {
        }

        public async Task<List<DAL.App.DTO.DomainEntityDTOs.SongInFolder>> AllAsyncWithInclude()
        {
            return await RepositoryDbSet
                .Include(sf => sf.Song)
                .Include(sf => sf.Folder)
                .Select(e => SongInFolderMapper.MapFromDomain(e))
                .ToListAsync();
        }
        
        public async Task<DAL.App.DTO.DomainEntityDTOs.SongInFolder> FindAsync(int id)
        {
            
            var songInFolder = await RepositoryDbSet
                .Include(sf => sf.Song)
                .Include(sf => sf.Folder)
                .FirstOrDefaultAsync(sf => sf.Id == id);
            
            
            return SongInFolderMapper.MapFromDomain(songInFolder);
        }
    }
}