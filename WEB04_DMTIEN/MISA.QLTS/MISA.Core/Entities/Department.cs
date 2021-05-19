using System;

namespace MISA.Core.Entities
{
    public class Department : BaseEntity
    {
        #region Declare

        /// <summary>
        /// Phòng ban
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string DepartmentName { get; set; }

        #endregion Declare
    }
}