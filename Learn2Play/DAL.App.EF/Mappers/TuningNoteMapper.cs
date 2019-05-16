using System;
using ee.itcollege.javalg.Contracts.DAL.Base.Mappers;
using DALAppDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class TuningNoteMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DALAppDTO.DomainEntityDTOs.TuningNote))
            {
                return MapFromDomain((Domain.TuningNote) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.TuningNote))
            {
                return MapFromDAL((DALAppDTO.DomainEntityDTOs.TuningNote) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DALAppDTO.DomainEntityDTOs.TuningNote MapFromDomain(Domain.TuningNote tuningNote)
        {
            var res = tuningNote == null ? null : new DALAppDTO.DomainEntityDTOs.TuningNote
            {
                Id = tuningNote.Id,
                Name = tuningNote.Name,
                InstrumentId = tuningNote.InstrumentId,
                Instrument = InstrumentMapper.MapFromDomain(tuningNote.Instrument),
                NoteId = tuningNote.NoteId,
                Note = NoteMapper.MapFromDomain(tuningNote.Note) 
            };


            return res;
        }

        public static Domain.TuningNote MapFromDAL(DALAppDTO.DomainEntityDTOs.TuningNote tuningNote)
        {
            var res = tuningNote == null ? null : new Domain.TuningNote
            {
                Id = tuningNote.Id,
                Name = tuningNote.Name,
                InstrumentId = tuningNote.InstrumentId,
                Instrument = InstrumentMapper.MapFromDAL(tuningNote.Instrument),
                NoteId = tuningNote.NoteId,
                Note = NoteMapper.MapFromDAL(tuningNote.Note) 
            };

            return res;
        }

    }
}