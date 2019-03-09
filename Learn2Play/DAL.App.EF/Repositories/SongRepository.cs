using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class SongRepository: BaseRepository<Song>, ISongRepository
    {
        public SongRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}