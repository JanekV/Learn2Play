using Contracts.DAL.App.Repositories;
using DAL.App.EF.Mappers;
using ee.itcollege.javalg.DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ChordRepository: BaseRepository<DAL.App.DTO.DomainEntityDTOs.Chord, Domain.Chord, AppDbContext>, IChordRepository
    {
        public ChordRepository(AppDbContext repositoryDbContext) : base(repositoryDbContext, new ChordMapper())
        {
        }
    }
}