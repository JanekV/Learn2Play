using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class SongChordRepository: BaseRepository<SongChord>, ISongChordRepository
    {
        public SongChordRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}