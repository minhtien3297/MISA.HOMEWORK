using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;

namespace MISA.Infrastructure.Repositories
{
    public class AssetRepository : BaseRepository<Asset>, IAssetRepository
    {
        #region Method

        /// <summary>
        /// lọc tài sản
        /// </summary>
        /// <param name="assetName">tên tài sản</param>
        /// <param name="assetCode">mã tài sản</param>
        /// <returns>Danh sách tài sản</returns>
        /// CreatedBy: DMTIEN (14/5/2021)
        public IEnumerable<Asset> FilterAssets(string assetName, string assetCode, decimal? IncreaseDate, string AssetTypeId, string DepartmentId)
        {
            try
            {
                var storeName = $"Proc_FilterAsset";
                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add($"@AssetCode", assetCode);
                dynamicParameters.Add($"@AssetName", assetName);
                dynamicParameters.Add($"@IncreaseDate", IncreaseDate);
                dynamicParameters.Add($"@AssetTypeId", AssetTypeId);
                dynamicParameters.Add($"@DepartmentId", DepartmentId);

                var entity = _dbConnection.Query<Asset>(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure);

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Method
    }
}