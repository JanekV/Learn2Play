using System.Threading.Tasks;
using DAL.App.DTO.DomainEntityDTOs;
using ee.itcollege.javalg.Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IInstrumentRepository: IInstrumentRepository<DALAppDTO.DomainEntityDTOs.Instrument>
    {
        Task<Instrument> FindDetachedAsync(int id);
    }
    
    public interface IInstrumentRepository<TDALEntity>: IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {
    }
}