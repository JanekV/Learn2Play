using System;
using ee.itcollege.javalg.Contracts.BLL.Base.Mappers;


namespace BLL.App.Mappers
{
    public class SongChordMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.DomainEntityDTOs.SongChord))
            {
                return MapFromDAL((DAL.App.DTO.DomainEntityDTOs.SongChord) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.DomainEntityDTOs.SongChord))
            {
                return MapFromBLL((BLL.App.DTO.DomainEntityDTOs.SongChord) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.DomainEntityDTOs.SongChord MapFromDAL(DAL.App.DTO.DomainEntityDTOs.SongChord songChord)
        {
            var res = songChord == null ? null : new BLL.App.DTO.DomainEntityDTOs.SongChord
            {
                Id = songChord.Id,
                SongId = songChord.SongId,
                Song = SongMapper.MapFromDAL(songChord.Song),
                ChordId = songChord.ChordId,
                Chord = ChordMapper.MapFromDAL(songChord.Chord)     
            };


            return res;
        }

        public static DAL.App.DTO.DomainEntityDTOs.SongChord MapFromBLL(BLL.App.DTO.DomainEntityDTOs.SongChord songChord)
        {
            var res = songChord == null ? null : new DAL.App.DTO.DomainEntityDTOs.SongChord
            {
                Id = songChord.Id,
                SongId = songChord.SongId,
                Song = SongMapper.MapFromBLL(songChord.Song),
                ChordId = songChord.ChordId,
                Chord = ChordMapper.MapFromBLL(songChord.Chord)  
            };

            return res;
        }

    }
}