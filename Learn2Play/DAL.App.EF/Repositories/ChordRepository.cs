using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ChordRepository: BaseRepository<Chord>, IChordRepository
    {
        public ChordRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}