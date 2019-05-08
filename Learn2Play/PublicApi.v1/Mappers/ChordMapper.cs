using System;
using externalDTO = PublicApi.v1.DTO.DomainEntityDTOs;
using internalDTO = BLL.App.DTO.DomainEntityDTOs;



namespace PublicApi.v1.Mappers
{
    public class ChordMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Chord))
            {
                return MapFromBLL((internalDTO.Chord) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Chord))
            {
                return MapFromExternal((externalDTO.Chord) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Chord MapFromBLL(internalDTO.Chord chord)
        {
            var res = chord == null ? null : new externalDTO.Chord
            {
                Id = chord.Id,
                Name = chord.Name,
                ShapePicturePath = chord.ShapePicturePath
            };


            return res;
        }

        public static internalDTO.Chord MapFromExternal(externalDTO.Chord chord)
        {
            var res = chord == null ? null : new internalDTO.Chord
            {
                Id = chord.Id,
                Name = chord.Name,
                ShapePicturePath = chord.ShapePicturePath
            };

            return res;
        }

    }
}