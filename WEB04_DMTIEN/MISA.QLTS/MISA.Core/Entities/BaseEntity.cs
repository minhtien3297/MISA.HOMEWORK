using System;

namespace MISA.Core.Entities
{
    public class BaseEntity
    {
        #region Declare

        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày thay đổi
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người thay đổi
        /// </summary>
        public string ModifiedBy { get; set; }

        #endregion Declare
    }
}