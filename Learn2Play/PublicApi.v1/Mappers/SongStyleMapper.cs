using System;
using externalDTO = PublicApi.v1.DTO.DomainEntityDTOs;
using internalDTO = BLL.App.DTO.DomainEntityDTOs;


namespace PublicApi.v1.Mappers
{
    public class SongStyleMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.SongStyle))
            {
                return MapFromBLL((internalDTO.SongStyle) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.SongStyle))
            {
                return MapFromExternal((externalDTO.SongStyle) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.SongStyle MapFromBLL(internalDTO.SongStyle songStyle)
        {
            var res = songStyle == null ? null : new externalDTO.SongStyle
            {
                Id = songStyle.Id,
                SongId = songStyle.SongId,
                Song = SongMapper.MapFromBLL(songStyle.Song),
                StyleId = songStyle.StyleId,
                Style = StyleMapper.MapFromBLL(songStyle.Style)               
            };


            return res;
        }

        public static internalDTO.SongStyle MapFromExternal(externalDTO.SongStyle songStyle)
        {
            var res = songStyle == null ? null : new internalDTO.SongStyle
            {
                Id = songStyle.Id,
                SongId = songStyle.SongId,
                Song = SongMapper.MapFromExternal(songStyle.Song),
                StyleId = songStyle.StyleId,
                Style = StyleMapper.MapFromExternal(songStyle.Style)  
            };

            return res;
        }

    }
}