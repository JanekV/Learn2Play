using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class SongInFolderRepository: BaseRepository<SongInFolder>, ISongInFolderRepository
    {
        public SongInFolderRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public async Task<IEnumerable<SongInFolder>> AllAsyncWithInclude()
        {
            return await RepositoryDbSet
                .Include(sf => sf.Song)
                .Include(sf => sf.Folder)
                .ToListAsync();
        }
        
        public override async Task<SongInFolder> FindAsync(params object[] id)
        {
            var songInFolder = await base.FindAsync(id);
            if (songInFolder != null)
            {
                await RepositoryDbContext.Entry(songInFolder)
                    .Reference(sf => sf.Song).LoadAsync();
                await RepositoryDbContext.Entry(songInFolder)
                    .Reference(sf => sf.Folder).LoadAsync();
            }
            return songInFolder;
        }
    }
}