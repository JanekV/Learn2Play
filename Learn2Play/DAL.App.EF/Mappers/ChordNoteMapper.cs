using System;
using ee.itcollege.javalg.Contracts.DAL.Base.Mappers;
using DALAppDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class ChordNoteMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DALAppDTO.DomainEntityDTOs.ChordNote))
            {
                return MapFromDomain((Domain.ChordNote) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.ChordNote))
            {
                return MapFromDAL((DALAppDTO.DomainEntityDTOs.ChordNote) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DALAppDTO.DomainEntityDTOs.ChordNote MapFromDomain(Domain.ChordNote chordNote)
        {
            var res = chordNote == null ? null : new DALAppDTO.DomainEntityDTOs.ChordNote
            {
                Id = chordNote.Id,
                ChordId = chordNote.ChordId,
                Chord = ChordMapper.MapFromDomain(chordNote.Chord),
                NoteId = chordNote.NoteId,
                Note = NoteMapper.MapFromDomain(chordNote.Note)
            };


            return res;
        }

        public static Domain.ChordNote MapFromDAL(DALAppDTO.DomainEntityDTOs.ChordNote chordNote)
        {
            var res = chordNote == null ? null : new Domain.ChordNote
            {
                Id = chordNote.Id,
                ChordId = chordNote.ChordId,
                Chord = ChordMapper.MapFromDAL(chordNote.Chord),
                NoteId = chordNote.NoteId,
                Note = NoteMapper.MapFromDAL(chordNote.Note)
            };

            return res;
        }

    }
}