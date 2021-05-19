using MISA.Core.Entities;
using System.Collections.Generic;

namespace MISA.Core.Interfaces.Services
{
    public interface IAssetService : IBaseService<Asset>
    {
        #region Method

        /// <summary>
        /// Lọc tài sản
        /// </summary>
        /// <param name="assetName">tên tài sản</param>
        /// <param name="assetCode">mã tài sản</param>
        /// <returns></returns>
        /// CreatedBy: DMTIEN (14/5/2021)
        IEnumerable<Asset> FilterAssets(string assetName, string assetCode, decimal? IncreaseDate, string AssetTypeId, string DepartmentId);

        #endregion Method
    }
}