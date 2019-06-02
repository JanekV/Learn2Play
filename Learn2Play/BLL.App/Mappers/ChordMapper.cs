using System;
using ee.itcollege.javalg.Contracts.BLL.Base.Mappers;


namespace BLL.App.Mappers
{
    public class ChordMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.DomainEntityDTOs.Chord))
            {
                return MapFromDAL((DAL.App.DTO.DomainEntityDTOs.Chord) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.DomainEntityDTOs.Chord))
            {
                return MapFromBLL((BLL.App.DTO.DomainEntityDTOs.Chord) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.DomainEntityDTOs.Chord MapFromDAL(DAL.App.DTO.DomainEntityDTOs.Chord chord)
        {
            var res = chord == null ? null : new BLL.App.DTO.DomainEntityDTOs.Chord
            {
                Id = chord.Id,
                Name = chord.Name,
                ShapePicturePath = chord.ShapePicturePath
            };


            return res;
        }

        public static DAL.App.DTO.DomainEntityDTOs.Chord MapFromBLL(BLL.App.DTO.DomainEntityDTOs.Chord chord)
        {
            var res = chord == null ? null : new DAL.App.DTO.DomainEntityDTOs.Chord
            {
                Id = chord.Id,
                Name = chord.Name,
                ShapePicturePath = chord.ShapePicturePath
            };

            return res;
        }

        public static BLL.App.DTO.ChordWithNotes MapFromDAL(DAL.App.DTO.ChordWithNotes chordWithNotes)
        {
            var res = chordWithNotes == null ? null : new BLL.App.DTO.ChordWithNotes()
            {
                Id = chordWithNotes.Id,
                ChordName = chordWithNotes.ChordName,
                ShapePicturePath = chordWithNotes.ShapePicturePath,
                Notes = chordWithNotes.Notes.ConvertAll(NoteMapper.MapFromDAL)
            };
            
            return res;
        }

    }
}