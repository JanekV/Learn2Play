using System;
using externalDTO = PublicApi.v1.DTO.DomainEntityDTOs;
using internalDTO = BLL.App.DTO.DomainEntityDTOs;


namespace PublicApi.v1.Mappers
{
    public class SongChordMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.SongChord))
            {
                return MapFromBLL((internalDTO.SongChord) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.SongChord))
            {
                return MapFromExternal((externalDTO.SongChord) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.SongChord MapFromBLL(internalDTO.SongChord songChord)
        {
            var res = songChord == null ? null : new externalDTO.SongChord
            {
                Id = songChord.Id,
                SongId = songChord.SongId,
                Song = SongMapper.MapFromBLL(songChord.Song),
                ChordId = songChord.ChordId,
                Chord = ChordMapper.MapFromBLL(songChord.Chord)     
            };


            return res;
        }

        public static internalDTO.SongChord MapFromExternal(externalDTO.SongChord songChord)
        {
            var res = songChord == null ? null : new internalDTO.SongChord
            {
                Id = songChord.Id,
                SongId = songChord.SongId,
                Song = SongMapper.MapFromExternal(songChord.Song),
                ChordId = songChord.ChordId,
                Chord = ChordMapper.MapFromExternal(songChord.Chord)  
            };

            return res;
        }

    }
}