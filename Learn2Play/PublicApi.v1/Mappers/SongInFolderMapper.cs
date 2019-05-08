using System;
using externalDTO = PublicApi.v1.DTO.DomainEntityDTOs;
using internalDTO = BLL.App.DTO.DomainEntityDTOs;


namespace PublicApi.v1.Mappers
{
    public class SongInFolderMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.SongInFolder))
            {
                return MapFromBLL((internalDTO.SongInFolder) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.SongInFolder))
            {
                return MapFromExternal((externalDTO.SongInFolder) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.SongInFolder MapFromBLL(internalDTO.SongInFolder songInFolder)
        {
            var res = songInFolder == null ? null : new externalDTO.SongInFolder
            {
                Id = songInFolder.Id,
                FolderId = songInFolder.FolderId,
                Folder = FolderMapper.MapFromBLL(songInFolder.Folder),
                SongId = songInFolder.SongId,
                Song = SongMapper.MapFromBLL(songInFolder.Song)                
            };


            return res;
        }

        public static internalDTO.SongInFolder MapFromExternal(externalDTO.SongInFolder songInFolder)
        {
            var res = songInFolder == null ? null : new internalDTO.SongInFolder
            {
                Id = songInFolder.Id,
                FolderId = songInFolder.FolderId,
                Folder = FolderMapper.MapFromExternal(songInFolder.Folder),
                SongId = songInFolder.SongId,
                Song = SongMapper.MapFromExternal(songInFolder.Song)  
            };

            return res;
        }

    }
}