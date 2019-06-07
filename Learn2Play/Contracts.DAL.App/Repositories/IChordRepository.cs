using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.App.DTO.DomainEntityDTOs;
using ee.itcollege.javalg.Contracts.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IChordRepository: IChordRepository<DALAppDTO.DomainEntityDTOs.Chord>
    {
        Task<List<DALAppDTO.ChordWithNotes>> GetAllChordsWithNotesAsync();
        Task<DALAppDTO.ChordWithNotes> GetChordWithNotesAsync(int chordId);

        Task<Chord> FindDetachedAsync(int id);
    }
    
    public interface IChordRepository<TDALEntity>: IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {
    }
}