using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class TuningNoteRepository: BaseRepository<TuningNote>, ITuningNoteRepository
    {
        public TuningNoteRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}