using System;
using Contracts.DAL.Base.Mappers;
using DALAppDTO = DAL.App.DTO;


namespace DAL.App.EF.Mappers
{
    public class SongChordMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(DALAppDTO.DomainEntityDTOs.SongChord))
            {
                return MapFromDomain((Domain.SongChord) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(Domain.SongChord))
            {
                return MapFromDAL((DALAppDTO.DomainEntityDTOs.SongChord) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static DALAppDTO.DomainEntityDTOs.SongChord MapFromDomain(Domain.SongChord songChord)
        {
            var res = songChord == null ? null : new DALAppDTO.DomainEntityDTOs.SongChord
            {
                Id = songChord.Id,
                SongId = songChord.SongId,
                Song = SongMapper.MapFromDomain(songChord.Song),
                ChordId = songChord.ChordId,
                Chord = ChordMapper.MapFromDomain(songChord.Chord)           
            };


            return res;
        }

        public static Domain.SongChord MapFromDAL(DALAppDTO.DomainEntityDTOs.SongChord songChord)
        {
            var res = songChord == null ? null : new Domain.SongChord
            {
                Id = songChord.Id,
                SongId = songChord.SongId,
                Song = SongMapper.MapFromDAL(songChord.Song),
                ChordId = songChord.ChordId,
                Chord = ChordMapper.MapFromDAL(songChord.Chord) 
            };

            return res;
        }

    }
}