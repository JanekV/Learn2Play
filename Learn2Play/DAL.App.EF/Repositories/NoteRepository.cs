using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class NoteRepository: BaseRepository<Note>, INoteRepository
    {
        public NoteRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}