using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{   
    public interface IUserInstrumentRepository : IUserInstrumentRepository<DALAppDTO.DomainEntityDTOs.UserInstrument>
    {
    }
    public interface IUserInstrumentRepository<TDALEntity>: IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {
        Task<List<TDALEntity>> AllAsyncWithInclude();
    }
}