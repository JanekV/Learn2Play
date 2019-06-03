using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.javalg.Contracts.DAL.Base.Repositories;
using Domain;
using Chord = DAL.App.DTO.DomainEntityDTOs.Chord;
using ChordNote = DAL.App.DTO.DomainEntityDTOs.ChordNote;
using DALAppDTO = DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IChordNoteRepository : IChordNoteRepository<DALAppDTO.DomainEntityDTOs.ChordNote>
    {
        void RemoveByNote(int noteId);
    }
    public interface IChordNoteRepository<TDALEntity>: IBaseRepository<TDALEntity> 
        where TDALEntity : class, new()
    {
        Task<List<TDALEntity>> AllAsyncWithInclude();
    }
}