using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ChordRepository: BaseRepository<Chord>, IChordRepository
    {
        public ChordRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}