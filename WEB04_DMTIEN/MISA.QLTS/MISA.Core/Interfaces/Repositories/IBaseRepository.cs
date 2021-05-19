using System;
using System.Collections.Generic;

namespace MISA.Core.Interfaces.Repositories
{
    /// <summary>
    /// Interface base repository
    /// </summary>
    /// <typeparam name="MISAEntity">Kiểu dữ liệu</typeparam>
    /// CreatedBy: DMTIEN (14/5/2021)
    public interface IBaseRepository<MISAEntity>
    {
        #region Method

        /// <summary>
        ///  Lấy toàn bộ dữ liệu trong bảng
        /// </summary>
        /// <returns> </returns>
        /// <returns> Danh sách bản ghi </returns>
        /// CreatedBy: DMTIEN (14/5/2021)
        IEnumerable<MISAEntity> GetEntities();

        /// <summary>
        ///  Thêm mới dữ liệu
        /// </summary>
        /// <param name="entity">Dữ liệu nhập vào</param>
        /// <returns>Số bản ghi thêm mới vào database</returns>
        /// CreatedBy: DMTIEN (14/5/2021)
        int Insert(MISAEntity entity);

        /// <summary>
        /// Cập nhật dữ liệu theo dữ liệu và id truyền vào
        /// </summary>
        /// <param name="entity">Dữ liệu cập nhật</param>
        /// <param name="entityId">id của dữ liệu được cập nhật</param>
        /// <returns>Số bản ghi được cập nhật trong database</returns>
        /// CreatedBy: DMTIEN (14/5/2021)
        int Update(MISAEntity entity, Guid entityId);

        /// <summary>
        /// Xoá dữ liệu
        /// </summary>
        /// <param name="entityId">id của dữ liệu cần xoá</param>
        /// <returns>Số bản ghi đã xoá trong </returns>
        /// CreatedBy: DMTIEN (14/5/2021)
        int Delete(Guid entityId);

        #endregion Method
    }
}