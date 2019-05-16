using ee.itcollege.javalg.Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IStyleRepository : IStyleRepository<DALAppDTO.DomainEntityDTOs.Style>
    {
    }
    public interface IStyleRepository<TDALEntity>: IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {
    }
}