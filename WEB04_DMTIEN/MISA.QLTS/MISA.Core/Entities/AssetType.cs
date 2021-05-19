using System;

namespace MISA.Core.Entities
{
    public class AssetType : BaseEntity
    {
        #region Declare

        /// <summary>
        /// Loại tài sản
        /// </summary>
        public Guid AssetTypeId { get; set; }

        /// <summary>
        /// Mã loại tài sản
        /// </summary>
        public string AssetTypeCode { get; set; }

        /// <summary>
        /// Tên loại tài sản
        /// </summary>
        public string AssetTypeName { get; set; }

        #endregion Declare
    }
}