using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.App.DTO.DomainEntityDTOs;
using ee.itcollege.javalg.Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IStyleRepository : IStyleRepository<DALAppDTO.DomainEntityDTOs.Style>
    {
        Task<List<Style>> GetStylesForIds(List<int> ids);

    }
    public interface IStyleRepository<TDALEntity>: IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {
    }
}