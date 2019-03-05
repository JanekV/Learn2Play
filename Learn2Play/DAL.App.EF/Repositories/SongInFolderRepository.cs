using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class SongInFolderRepository: BaseRepository<SongInFolder>, ISongInFolderRepository
    {
        public SongInFolderRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}