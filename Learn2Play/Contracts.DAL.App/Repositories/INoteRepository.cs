using ee.itcollege.javalg.Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface INoteRepository: INoteRepository<DALAppDTO.DomainEntityDTOs.Note>
    {      
    }
    
    public interface INoteRepository<TDALEntity>: IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {
    }
}