using System;
using Contracts.DAL.Base.Mappers;
using DALAppDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class SongMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DALAppDTO.DomainEntityDTOs.Song))
            {
                return MapFromDomain((Domain.Song) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.Song))
            {
                return MapFromDAL((DALAppDTO.DomainEntityDTOs.Song) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DALAppDTO.DomainEntityDTOs.Song MapFromDomain(Domain.Song song)
        {
            var res = song == null ? null : new DALAppDTO.DomainEntityDTOs.Song
            {
                Id = song.Id,
                Name = song.Name,
                Author = song.Author,
                SpotifyLink = song.SpotifyLink,
                Description = song.Description,
                SongKeyId = song.SongKeyId,
                SongKey = SongKeyMapper.MapFromDomain(song.SongKey)
            };


            return res;
        }

        public static Domain.Song MapFromDAL(DALAppDTO.DomainEntityDTOs.Song song)
        {
            var res = song == null ? null : new Domain.Song
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

    }
}