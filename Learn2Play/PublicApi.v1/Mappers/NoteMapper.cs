using System;
using externalDTO = PublicApi.v1.DTO.DomainEntityDTOs;
using internalDTO = BLL.App.DTO.DomainEntityDTOs;

namespace PublicApi.v1.Mappers
{
    public class NoteMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Note))
            {
                return MapFromBLL((internalDTO.Note) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Note))
            {
                return MapFromExternal((externalDTO.Note) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Note MapFromBLL(internalDTO.Note note)
        {
            var res = note == null ? null : new externalDTO.Note
            {
                Id = note.Id,
                Name = note.Name
                
            };


            return res;
        }

        public static internalDTO.Note MapFromExternal(externalDTO.Note note)
        {
            var res = note == null ? null : new internalDTO.Note
            {
                Id = note.Id,
                Name = note.Name
            };

            return res;
        }

    }
}