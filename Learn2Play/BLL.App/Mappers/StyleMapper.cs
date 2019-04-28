using System;
using Contracts.BLL.Base.Mappers;


namespace BLL.App.Mappers
{
    public class StyleMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.DomainEntityDTOs.Style))
            {
                return MapFromDAL((DAL.App.DTO.DomainEntityDTOs.Style) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.DomainEntityDTOs.Style))
            {
                return MapFromBLL((BLL.App.DTO.DomainEntityDTOs.Style) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.DomainEntityDTOs.Style MapFromDAL(DAL.App.DTO.DomainEntityDTOs.Style style)
        {
            var res = style == null ? null : new BLL.App.DTO.DomainEntityDTOs.Style
            {
                Id = style.Id,
                Name = style.Name,
                Description = style.Description           
            };


            return res;
        }

        public static DAL.App.DTO.DomainEntityDTOs.Style MapFromBLL(BLL.App.DTO.DomainEntityDTOs.Style style)
        {
            var res = style == null ? null : new DAL.App.DTO.DomainEntityDTOs.Style
            {
                Id = style.Id,
                Name = style.Name,
                Description = style.Description
            };

            return res;
        }

    }
}