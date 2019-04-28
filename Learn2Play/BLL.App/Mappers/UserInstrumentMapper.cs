using System;
using Contracts.BLL.Base.Mappers;


namespace BLL.App.Mappers
{
    public class UserInstrumentMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.DomainEntityDTOs.UserInstrument))
            {
                return MapFromDAL((DAL.App.DTO.DomainEntityDTOs.UserInstrument) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.DomainEntityDTOs.UserInstrument))
            {
                return MapFromBLL((BLL.App.DTO.DomainEntityDTOs.UserInstrument) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.DomainEntityDTOs.UserInstrument MapFromDAL(DAL.App.DTO.DomainEntityDTOs.UserInstrument userInstrument)
        {
            var res = userInstrument == null ? null : new BLL.App.DTO.DomainEntityDTOs.UserInstrument
            {
                Id = userInstrument.Id,
                AppUserId = userInstrument.AppUserId,
                InstrumentId = userInstrument.InstrumentId,
                Instrument = InstrumentMapper.MapFromDAL(userInstrument.Instrument),
                Comment = userInstrument.Comment  
                
            };


            return res;
        }

        public static DAL.App.DTO.DomainEntityDTOs.UserInstrument MapFromBLL(BLL.App.DTO.DomainEntityDTOs.UserInstrument userInstrument)
        {
            var res = userInstrument == null ? null : new DAL.App.DTO.DomainEntityDTOs.UserInstrument
            {
                Id = userInstrument.Id,
                AppUserId = userInstrument.AppUserId,
                InstrumentId = userInstrument.InstrumentId,
                Instrument = InstrumentMapper.MapFromBLL(userInstrument.Instrument),
                Comment = userInstrument.Comment  
            };

            return res;
        }

    }
}