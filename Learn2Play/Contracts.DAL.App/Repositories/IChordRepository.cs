using ee.itcollege.javalg.Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IChordRepository: IChordRepository<DALAppDTO.DomainEntityDTOs.Chord>
    {       
    }
    
    public interface IChordRepository<TDALEntity>: IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {
    }
}