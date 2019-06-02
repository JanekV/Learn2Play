using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using DAL.App.DTO.DomainEntityDTOs;
using ee.itcollege.javalg.BLL.Base.Services;
using Chord = BLL.App.DTO.DomainEntityDTOs.Chord;
using Note = BLL.App.DTO.DomainEntityDTOs.Note;

namespace BLL.App.Services
{
    public class ChordService : BaseEntityService<BLL.App.DTO.DomainEntityDTOs.Chord, DAL.App.DTO.DomainEntityDTOs.Chord, IAppUnitOfWork>, IChordService
    {
        public ChordService(IAppUnitOfWork uow) : base(uow, new ChordMapper())
        {
            ServiceRepository = Uow.Chords;
        }

        public async Task<List<ChordWithNotes>> GetAllChordsWithNotesAsync()
        {
            return (await Uow.Chords.GetAllChordsWithNotesAsync()).Select(ChordMapper.MapFromDAL).ToList();
        }

        public async Task<ChordWithNotes> GetChordWithNotesAsync(int chordId)
        {
            return ChordMapper.MapFromDAL(await Uow.Chords.GetChordWithNotesAsync(chordId));
        }

        public async Task<BLL.App.DTO.DomainEntityDTOs.Chord> AddChordWithNotes(
            BLL.App.DTO.DomainEntityDTOs.Chord chord, List<BLL.App.DTO.DomainEntityDTOs.Note> notes)
        {
            var c = ChordMapper.MapFromBLL(chord);
            var res = await Uow.Chords.AddAsync(c);
            await Uow.Notes.AddMultipleAsync(notes.ConvertAll(NoteMapper.MapFromBLL));
            foreach (var note in notes)
            {
                await Uow.ChordNotes.AddAsync(new ChordNote()
                {
                    Chord = res,
                    ChordId = res.Id,
                    Note = NoteMapper.MapFromBLL(note),
                    NoteId = note.Id
                });
            }

            return ChordMapper.MapFromDAL(res);
        }

        public async Task<BLL.App.DTO.DomainEntityDTOs.Note> AddNoteToChord(Chord chord, Note note)
        {
            var res = ChordMapper.MapFromBLL(chord);
            var resNote = await Uow.Notes.AddAsync(NoteMapper.MapFromBLL(note));
            await Uow.ChordNotes.AddAsync(new ChordNote()
            {
                Chord = res,
                ChordId = res.Id,
                Note = resNote,
                NoteId = resNote.Id
            });
            return NoteMapper.MapFromDAL(resNote);
        }
    }
}