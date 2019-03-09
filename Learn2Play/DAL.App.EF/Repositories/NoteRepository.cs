using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class NoteRepository: BaseRepository<Note>, INoteRepository
    {
        public NoteRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}