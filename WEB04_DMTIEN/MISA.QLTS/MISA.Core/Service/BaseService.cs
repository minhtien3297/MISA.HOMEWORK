using MISA.Core.Interfaces.Repositories;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace MISA.Core.Service
{
    /// <summary>
    ///  base service
    /// </summary>
    /// <typeparam name="MISAEntity">kiểu dữ liệu</typeparam>
    /// CreatedBy: DMTIEN (14/5/2021)
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        #region Declare

        private IBaseRepository<MISAEntity> _baseRepository;

        #endregion Declare

        #region Constructor

        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        #endregion Constructor

        #region Method

        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Danh sách tất cả bản ghi</returns>
        /// CreatedBy: DMTIEN (14/5/2021)
        public IEnumerable<MISAEntity> GetEntities()
        {
            try
            {
                return _baseRepository.GetEntities();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// thêm mới dữ liệu
        /// </summary>
        /// <param name="entity">kiểu dữ liệu</param>
        /// <returns>số bản ghi thêm thành công</returns>
        /// CreatedBy: DMTIEN (14/5/2021)
        public int Insert(MISAEntity entity)
        {
            try
            {
                return _baseRepository.Insert(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// cập nhật dữ liệu
        /// </summary>
        /// <param name="entity">kiểu dữ liệu</param>
        /// <param name="entityId">id của kiểu dữ liệu</param>
        /// <returns>số bản ghi cập nhật thành công</returns>
        /// CreatedBy: DMTIEN (14/5/2021)
        public int Update(MISAEntity entity, Guid entityId)
        {
            try
            {
                return _baseRepository.Update(entity, entityId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// xoá dữ liệu
        /// </summary>
        /// <param name="entityId">id của kiểu dữ liệu</param>
        /// <returns>số bản ghi xoá thành công</returns>
        /// CreatedBy: DMTIEN (14/5/2021)
        public int Delete(Guid entityId)
        {
            try
            {
                return _baseRepository.Delete(entityId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Method
    }
}