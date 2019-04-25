using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{   
    public interface IUserFolderRepository : IUserFolderRepository<DALAppDTO.DomainEntityDTOs.UserFolder>
    {
    }
    public interface IUserFolderRepository<TDALEntity>: IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {
        Task<List<TDALEntity>> AllAsyncWithInclude();
    }
}