using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Services;
using System;

namespace MISA.QLTS.API.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class AssetController : BaseEntityController<Asset>
    {
        #region Declare

        private IAssetService _assetService;

        #endregion Declare

        #region Constructor

        public AssetController(IAssetService assetService) : base(assetService)
        {
            _assetService = assetService;
        }

        #endregion Constructor

        #region Method

        /// <summary>
        /// lọc dữ liệu tài sản
        /// </summary>
        /// <param name="assetName">tên tài sản</param>
        /// <param name="assetCode">mã tài sản</param>
        /// <param name="IncreaseDate">ngày ghi tăng</param>
        /// <param name="AssetTypeId">id của loại dữ liệu</param>
        /// <param name="DepartmentId">id của phòng ban</param>
        /// <returns>số bản ghi tài sản tìm được</returns>
        /// CreatedBy: DMTIEN (14/5/2021)
        [HttpGet("AssetFilter")]
        public IActionResult FilterAssets(string assetName, string assetCode, decimal? IncreaseDate, string AssetTypeId, string DepartmentId)
        {
            try
            {
                var entities = _assetService.FilterAssets(assetName, assetCode, IncreaseDate, AssetTypeId, DepartmentId);

                return Ok(entities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Method
    }
}