using System;
using Contracts.BLL.Base.Mappers;


namespace BLL.App.Mappers
{
    public class SongMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.DomainEntityDTOs.Song))
            {
                return MapFromDAL((DAL.App.DTO.DomainEntityDTOs.Song) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.DomainEntityDTOs.Song))
            {
                return MapFromBLL((BLL.App.DTO.DomainEntityDTOs.Song) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.DomainEntityDTOs.Song MapFromDAL(DAL.App.DTO.DomainEntityDTOs.Song song)
        {
            var res = song == null ? null : new BLL.App.DTO.DomainEntityDTOs.Song
            {
                Id = song.Id,
                Name = song.Name,
                Author = song.Author,
                SpotifyLink = song.SpotifyLink,
                Description = song.Description,
                SongKeyId = song.SongKeyId,
                SongKey = SongKeyMapper.MapFromDAL(song.SongKey)
                
            };


            return res;
        }

        public static DAL.App.DTO.DomainEntityDTOs.Song MapFromBLL(BLL.App.DTO.DomainEntityDTOs.Song song)
        {
            var res = song == null ? null : new DAL.App.DTO.DomainEntityDTOs.Song
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

    }
}