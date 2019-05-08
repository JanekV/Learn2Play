using System;
using externalDTO = PublicApi.v1.DTO.DomainEntityDTOs;
using internalDTO = BLL.App.DTO.DomainEntityDTOs;


namespace PublicApi.v1.Mappers
{
    public class SongKeyMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.SongKey))
            {
                return MapFromBLL((internalDTO.SongKey) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.SongKey))
            {
                return MapFromExternal((externalDTO.SongKey) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.SongKey MapFromBLL(internalDTO.SongKey songKey)
        {
            var res = songKey == null ? null : new externalDTO.SongKey
            {
                Id = songKey.Id,
                Description = songKey.Description,
                NoteId = songKey.NoteId,
                Note = NoteMapper.MapFromBLL(songKey.Note)                
            };


            return res;
        }

        public static internalDTO.SongKey MapFromExternal(externalDTO.SongKey songKey)
        {
            var res = songKey == null ? null : new internalDTO.SongKey
            {
                Id = songKey.Id,
                Description = songKey.Description,
                NoteId = songKey.NoteId,
                Note = NoteMapper.MapFromExternal(songKey.Note) 
            };

            return res;
        }

    }
}