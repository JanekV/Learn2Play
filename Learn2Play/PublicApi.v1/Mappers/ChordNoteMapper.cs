using System;
using externalDTO = PublicApi.v1.DTO.DomainEntityDTOs;
using internalDTO = BLL.App.DTO.DomainEntityDTOs;

namespace PublicApi.v1.Mappers
{
    public class ChordNoteMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.ChordNote))
            {
                return MapFromBLL((internalDTO.ChordNote) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.ChordNote))
            {
                return MapFromExternal((externalDTO.ChordNote) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.ChordNote MapFromBLL(internalDTO.ChordNote chordNote)
        {
            var res = chordNote == null ? null : new externalDTO.ChordNote
            {
                Id = chordNote.Id,
                ChordId = chordNote.ChordId,
                Chord = ChordMapper.MapFromBLL(chordNote.Chord),
                NoteId = chordNote.NoteId,
                Note = NoteMapper.MapFromBLL(chordNote.Note)
            };


            return res;
        }

        public static internalDTO.ChordNote MapFromExternal(externalDTO.ChordNote chordNote)
        {
            var res = chordNote == null ? null : new internalDTO.ChordNote
            {
                Id = chordNote.Id,
                ChordId = chordNote.ChordId,
                Chord = ChordMapper.MapFromExternal(chordNote.Chord),
                NoteId = chordNote.NoteId,
                Note = NoteMapper.MapFromExternal(chordNote.Note)
            };

            return res;
        }

    }
}