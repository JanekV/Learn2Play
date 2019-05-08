using System;
using externalDTO = PublicApi.v1.DTO.DomainEntityDTOs;
using internalDTO = BLL.App.DTO.DomainEntityDTOs;

namespace PublicApi.v1.Mappers
{
    public class SongMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Song))
            {
                return MapFromBLL((internalDTO.Song) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Song))
            {
                return MapFromExternal((externalDTO.Song) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Song MapFromBLL(internalDTO.Song song)
        {
            var res = song == null ? null : new externalDTO.Song
            {
                Id = song.Id,
                Name = song.Name,
                Author = song.Author,
                SpotifyLink = song.SpotifyLink,
                Description = song.Description,
                SongKeyId = song.SongKeyId,
                SongKey = SongKeyMapper.MapFromBLL(song.SongKey)
                
            };


            return res;
        }

        public static internalDTO.Song MapFromExternal(externalDTO.Song song)
        {
            var res = song == null ? null : new internalDTO.Song
            {
                Id = song.Id,
                Name = song.Name,
                Author = song.Author,
                SpotifyLink = song.SpotifyLink,
                Description = song.Description,
                SongKeyId = song.SongKeyId,
                SongKey = SongKeyMapper.MapFromExternal(song.SongKey)
            };

            return res;
        }

    }
}