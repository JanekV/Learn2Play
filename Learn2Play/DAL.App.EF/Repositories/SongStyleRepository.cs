using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class SongStyleRepository: BaseRepository<SongStyle>, ISongStyleRepository
    {
        public SongStyleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}