using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ChordNoteRepository: BaseRepository<ChordNote>, IChordNoteRepository
    {
        public ChordNoteRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}