using System;
using Contracts.BLL.Base.Mappers;


namespace BLL.App.Mappers
{
    public class TuningNoteMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.DomainEntityDTOs.TuningNote))
            {
                return MapFromDAL((DAL.App.DTO.DomainEntityDTOs.TuningNote) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.DomainEntityDTOs.TuningNote))
            {
                return MapFromBLL((BLL.App.DTO.DomainEntityDTOs.TuningNote) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.DomainEntityDTOs.TuningNote MapFromDAL(DAL.App.DTO.DomainEntityDTOs.TuningNote tuningNote)
        {
            var res = tuningNote == null ? null : new BLL.App.DTO.DomainEntityDTOs.TuningNote
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

        public static DAL.App.DTO.DomainEntityDTOs.TuningNote MapFromBLL(BLL.App.DTO.DomainEntityDTOs.TuningNote tuningNote)
        {
            var res = tuningNote == null ? null : new DAL.App.DTO.DomainEntityDTOs.TuningNote
            {
                Id = tuningNote.Id,
                Name = tuningNote.Name,
                InstrumentId = tuningNote.InstrumentId,
                Instrument = InstrumentMapper.MapFromBLL(tuningNote.Instrument),
                NoteId = tuningNote.NoteId,
                Note = NoteMapper.MapFromBLL(tuningNote.Note) 
            };

            return res;
        }

    }
}