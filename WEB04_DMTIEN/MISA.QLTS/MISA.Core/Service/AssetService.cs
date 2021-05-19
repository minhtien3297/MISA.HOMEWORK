using MISA.Core.Entities;
using MISA.Core.Interfaces.Repositories;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace MISA.Core.Service
{
    public class AssetService : BaseService<Asset>, IAssetService
    {
        #region Declare

        private IAssetRepository _assetRepository;

        #endregion Declare

        #region Constructor

        public AssetService(IAssetRepository assetRepository) : base(assetRepository)
        {
            _assetRepository = assetRepository;
        }

        #endregion Constructor

        #region Method

        /// <summary>
        /// lọc dữ liệu tài sản
        /// </summary>
        /// <param name="assetName">tên tài sản</param>
        /// <param name="assetCode">mã tài sản</param>
        /// <param name="IncreaseDate">ngày ghi tăng</param>
        /// <param name="AssetTypeId">id của loại tài sản</param>
        /// <param name="DepartmentId">id của phòng ban</param>
        /// <returns></returns>
        /// CreatedBy: DMTIEN (14/5/2021)
        public IEnumerable<Asset> FilterAssets(string assetName, string assetCode, decimal? IncreaseDate, string AssetTypeId, string DepartmentId)
        {
            try
            {
                return _assetRepository.FilterAssets(assetName, assetCode, IncreaseDate, AssetTypeId, DepartmentId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Method
    }
}