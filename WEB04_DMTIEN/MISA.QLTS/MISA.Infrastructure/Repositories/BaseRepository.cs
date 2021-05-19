using Dapper;
using MISA.Core.Interfaces.Repositories;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace MISA.Infrastructure.Repositories
{
    /// <summary>
    /// base repository
    /// </summary>
    /// <typeparam name="MISAEntity">kiểu dữ liệu</typeparam>
    /// CreatedBy: DMTIEN (14/5/2021)
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity>, IDisposable
    {
        #region Declare

        protected string _tableName = string.Empty;

        protected string _connectionString = "Host=47.241.69.179;" +
            "Port=3306;" +
            "User=dev;" +
            "Password=12345678;" +
            "Database=MISACukCuk_MF798_DMTIEN;";

        protected IDbConnection _dbConnection;

        #endregion Declare

        #region Constructor

        public BaseRepository()
        {
            _tableName = typeof(MISAEntity).Name;
            _dbConnection = new MySqlConnection(_connectionString);
        }

        #endregion Constructor

        #region Method

        /// <summary>
        /// Lấy tất cả dữ liệu
        /// </summary>
        /// <returns>danh sách toàn bộ dữ liệu</returns>
        /// CreatedBy: DMTIEN (14/5/2021)
        public IEnumerable<MISAEntity> GetEntities()
        {
            try
            {
                var entities = _dbConnection.Query<MISAEntity>($"Proc_Get{_tableName}", commandType: CommandType.StoredProcedure);

                return entities;
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
        /// <returns>số bản ghi thêm mới thành công</returns>
        /// CreatedBy: DMTIEN (14/5/2021)
        public int Insert(MISAEntity entity)
        {
            try
            {
                var storeName = $"Proc_Insert{_tableName}";
                var storeParam = MappingDb(entity);
                var rowAffects = _dbConnection.Execute(storeName, param: storeParam, commandType: CommandType.StoredProcedure);

                return rowAffects;
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
                var storeName = $"Proc_Update{_tableName}";
                var storeParam = MappingDb(entity);
                var rowAffects = _dbConnection.Execute(storeName, storeParam, commandType: CommandType.StoredProcedure);

                return rowAffects;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Xoá dữ liệu
        /// </summary>
        /// <param name="entityId">id của dữ liệu</param>
        /// <returns>số bản ghi xoá thành công</returns>
        /// CreatedBy: DMTIEN (14/5/2021)
        public int Delete(Guid entityId)
        {
            try
            {
                var result = _dbConnection.Execute($"DELETE FROM {_tableName} WHERE {_tableName}.{_tableName}Id = '{entityId.ToString()}'", commandType: CommandType.Text);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// tạo parameter động
        /// </summary>
        /// <param name="entity">kiểu dữ liệu</param>
        /// <returns>parameter động</returns>
        /// CreatedBy: DMTIEN (14/5/2021)
        private DynamicParameters MappingDb(MISAEntity entity)
        {
            try
            {
                var properties = entity.GetType().GetProperties();
                var parameters = new DynamicParameters();

                foreach (var property in properties)
                {
                    var propertyName = property.Name;
                    var propertyValue = property.GetValue(entity);
                    var propertyType = property.PropertyType;

                    if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                    {
                        parameters.Add($"@{propertyName}", propertyValue, DbType.String); // nếu kiểu dữ liệu là Guid thì cast thành String
                    }
                    else
                    {
                        parameters.Add($"@{propertyName}", propertyValue);
                    }
                }

                return parameters;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Hàm ngắt kết nối db
        /// </summary>
        /// CreatedBy: DMTIEN (14/5/2021)
        public void Dispose()
        {
            _dbConnection.Dispose();
        }

        #endregion Method
    }
}