using System;

namespace MISA.Core.Entities
{
    public class Asset : BaseEntity
    {
        #region Declare

        /// <summary>
        /// Khoá chính
        /// </summary>
        public Guid AssetId { get; set; }

        /// <summary>
        /// Mã tài sản
        /// </summary>
        public string AssetCode { get; set; }

        /// <summary>
        /// Tên tài sản
        /// </summary>
        public string AssetName { get; set; }

        /// <summary>
        /// Loại tài sản
        /// </summary>
        public Guid? AssetTypeId { get; set; }

        /// <summary>
        /// Phòng ban
        /// </summary>
        public Guid? DepartmentId { get; set; }

        /// <summary>
        /// Ngày ghi tăng
        /// </summary>
        public DateTime? IncreaseDate { get; set; }

        /// <summary>
        /// Thời gian sử dụng
        /// </summary>
        public decimal? TimeUse { get; set; }

        /// <summary>
        /// Tỷ lệ hao mòn
        /// </summary>
        public decimal? WearRate { get; set; }

        /// <summary>
        /// Nguyên giá
        /// </summary>
        public decimal? OriginalPrice { get; set; }

        /// <summary>
        /// Giá trị hao mòn năm
        /// </summary>
        public decimal? WearValue { get; set; }

        /// <summary>
        /// Sử dụng (1 - sử dụng, 0 - không sử dụng)
        /// </summary>
        public Boolean? IsUsed { get; set; }

        /// <summary>
        /// tên loại tài sản
        /// </summary>
        public string AssetTypeName { get; set; }

        /// <summary>
        /// tên phòng ban
        /// </summary>
        public string DepartmentName { get; set; }

        #endregion Declare
    }
}