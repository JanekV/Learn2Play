using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class InstrumentRepository: BaseRepository<Instrument>, IInstrumentRepository
    {
        public InstrumentRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}