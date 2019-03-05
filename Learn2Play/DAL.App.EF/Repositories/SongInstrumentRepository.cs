using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class SongInstrumentRepository: BaseRepository<SongInstrument>, ISongInstrumentRepository
    {
        public SongInstrumentRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}