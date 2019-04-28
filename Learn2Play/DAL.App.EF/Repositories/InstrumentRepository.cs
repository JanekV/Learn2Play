using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class InstrumentRepository: BaseRepository<DAL.App.DTO.DomainEntityDTOs.Instrument, Domain.Instrument, AppDbContext>, IInstrumentRepository
    {
        public InstrumentRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new InstrumentMapper())
        {
        }
    }
}