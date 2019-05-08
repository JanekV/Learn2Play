using System;
using externalDTO = PublicApi.v1.DTO.DomainEntityDTOs;
using internalDTO = BLL.App.DTO.DomainEntityDTOs;


namespace PublicApi.v1.Mappers
{
    public class UserFolderMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.UserFolder))
            {
                return MapFromBLL((internalDTO.UserFolder) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.UserFolder))
            {
                return MapFromExternal((externalDTO.UserFolder) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.UserFolder MapFromBLL(internalDTO.UserFolder userFolder)
        {
            var res = userFolder == null ? null : new externalDTO.UserFolder
            {
                Id = userFolder.Id,
                AppUserId = userFolder.AppUserId,
                FolderId = userFolder.FolderId,
                Folder = FolderMapper.MapFromBLL(userFolder.Folder),
                Comment = userFolder.Comment           
            };


            return res;
        }

        public static internalDTO.UserFolder MapFromExternal(externalDTO.UserFolder userFolder)
        {
            var res = userFolder == null ? null : new internalDTO.UserFolder
            {
                Id = userFolder.Id,
                AppUserId = userFolder.AppUserId,
                FolderId = userFolder.FolderId,
                Folder = FolderMapper.MapFromExternal(userFolder.Folder),
                Comment = userFolder.Comment  
            };

            return res;
        }

    }
}