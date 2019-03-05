using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserInstrumentRepository: BaseRepository<UserInstrument>, IUserInstrumentRepository
    {
        public UserInstrumentRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}