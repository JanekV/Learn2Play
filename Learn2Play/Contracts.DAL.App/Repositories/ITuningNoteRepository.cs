using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.javalg.Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface ITuningNoteRepository : ITuningNoteRepository<DALAppDTO.DomainEntityDTOs.TuningNote>
    {
    }
    public interface ITuningNoteRepository<TDALEntity>: IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {
        Task<List<TDALEntity>> AllAsyncWithInclude();
    }
}