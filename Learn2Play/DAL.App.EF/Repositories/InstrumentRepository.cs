using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class InstrumentRepository: BaseRepository<Instrument, AppDbContext>, IInstrumentRepository
    {
        public InstrumentRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext)
        {
        }
    }
}