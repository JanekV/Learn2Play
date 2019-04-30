using System;
using Contracts.BLL.Base.Mappers;

namespace BLL.App.Mappers
{
    public class ChordNoteMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.DomainEntityDTOs.ChordNote))
            {
                return MapFromDAL((DAL.App.DTO.DomainEntityDTOs.ChordNote) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.DomainEntityDTOs.ChordNote))
            {
                return MapFromBLL((BLL.App.DTO.DomainEntityDTOs.ChordNote) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.DomainEntityDTOs.ChordNote MapFromDAL(DAL.App.DTO.DomainEntityDTOs.ChordNote chordNote)
        {
            var res = chordNote == null ? null : new BLL.App.DTO.DomainEntityDTOs.ChordNote
            {
                Id = chordNote.Id,
                ChordId = chordNote.ChordId,
                Chord = ChordMapper.MapFromDAL(chordNote.Chord),
                NoteId = chordNote.NoteId,
                Note = NoteMapper.MapFromDAL(chordNote.Note)
            };


            return res;
        }

        public static DAL.App.DTO.DomainEntityDTOs.ChordNote MapFromBLL(BLL.App.DTO.DomainEntityDTOs.ChordNote chordNote)
        {
            var res = chordNote == null ? null : new DAL.App.DTO.DomainEntityDTOs.ChordNote
            {
                Id = chordNote.Id,
                ChordId = chordNote.ChordId,
                Chord = ChordMapper.MapFromBLL(chordNote.Chord),
                NoteId = chordNote.NoteId,
                Note = NoteMapper.MapFromBLL(chordNote.Note)
            };

            return res;
        }

    }
}