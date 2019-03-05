using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class SongKeyRepository: BaseRepository<SongKey>, ISongKeyRepository
    {
        public SongKeyRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}