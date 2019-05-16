using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.javalg.Contracts.DAL.Base.Repositories;
using Domain;
using ChordNote = DAL.App.DTO.DomainEntityDTOs.ChordNote;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IChordNoteRepository : IChordNoteRepository<DALAppDTO.DomainEntityDTOs.ChordNote>
    {
    }
    public interface IChordNoteRepository<TDALEntity>: IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {
        Task<List<TDALEntity>> AllAsyncWithInclude();
    }
}