using System;
using externalDTO = PublicApi.v1.DTO.DomainEntityDTOs;
using internalDTO = BLL.App.DTO.DomainEntityDTOs;


namespace PublicApi.v1.Mappers
{
    public class TuningNoteMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.TuningNote))
            {
                return MapFromBLL((internalDTO.TuningNote) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.TuningNote))
            {
                return MapFromExternal((externalDTO.TuningNote) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.TuningNote MapFromBLL(internalDTO.TuningNote tuningNote)
        {
            var res = tuningNote == null ? null : new externalDTO.TuningNote
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

        public static internalDTO.TuningNote MapFromExternal(externalDTO.TuningNote tuningNote)
        {
            var res = tuningNote == null ? null : new internalDTO.TuningNote
            {
                Id = tuningNote.Id,
                Name = tuningNote.Name,
                InstrumentId = tuningNote.InstrumentId,
                Instrument = InstrumentMapper.MapFromExternal(tuningNote.Instrument),
                NoteId = tuningNote.NoteId,
                Note = NoteMapper.MapFromExternal(tuningNote.Note) 
            };

            return res;
        }

    }
}