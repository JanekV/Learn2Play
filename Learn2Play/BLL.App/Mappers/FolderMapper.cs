using System;
using ee.itcollege.javalg.Contracts.BLL.Base.Mappers;


namespace BLL.App.Mappers
{
    public class FolderMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(BLL.App.DTO.DomainEntityDTOs.Folder))
            {
                return MapFromDAL((DAL.App.DTO.DomainEntityDTOs.Folder) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(DAL.App.DTO.DomainEntityDTOs.Folder))
            {
                return MapFromBLL((BLL.App.DTO.DomainEntityDTOs.Folder) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static BLL.App.DTO.DomainEntityDTOs.Folder MapFromDAL(DAL.App.DTO.DomainEntityDTOs.Folder folder)
        {
            var res = folder == null ? null : new BLL.App.DTO.DomainEntityDTOs.Folder
            {
                Id = folder.Id,
                Name = folder.Name,
                FolderType = folder.FolderType,
                Comment = folder.Comment
                
            };


            return res;
        }

        public static DAL.App.DTO.DomainEntityDTOs.Folder MapFromBLL(BLL.App.DTO.DomainEntityDTOs.Folder folder)
        {
            var res = folder == null ? null : new DAL.App.DTO.DomainEntityDTOs.Folder
            {
                Id = folder.Id,
                Name = folder.Name,
                FolderType = folder.FolderType,
                Comment = folder.Comment
            };

            return res;
        }

    }
}