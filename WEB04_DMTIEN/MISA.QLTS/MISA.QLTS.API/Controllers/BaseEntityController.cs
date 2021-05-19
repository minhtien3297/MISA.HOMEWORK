using Microsoft.AspNetCore.Mvc;
using MISA.Core.Interfaces.Services;
using System;
using System.Linq;

namespace MISA.QLTS.API.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class BaseEntityController<MISAEntity> : ControllerBase
    {
        #region Declare

        private IBaseService<MISAEntity> _baseService;

        #endregion Declare

        #region Constructor

        public BaseEntityController(IBaseService<MISAEntity> baseService)
        {
            _baseService = baseService;
        }

        #endregion Constructor

        #region Method

        /// <summary>
        ///  Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>
        /// HttpCode200: Mảng dữ liệu
        /// HttpCode204: Không có dữ liệu
        /// </returns>
        /// CreatedBy: DMTIEN (15/5/2021)
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var entities = _baseService.GetEntities();

                if (entities != null && entities.Count() > 0)
                {
                    return Ok(entities);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Nhập dữ liệu
        /// </summary>
        /// <param name="entity">dữ liệu được truyền vào</param>
        /// <returns>
        ///  HttpCode: 200 nếu thêm được dữ liệu
        ///  Lỗi dữ liệu không hợp lệ : 400 (BadRequest)
        ///  HttpCode: 500 nếu có lỗi hoặc Exception xảy ra trên Server
        /// </returns>
        /// CreatedBy: DMTIEN (15/5/2021)
        [HttpPost]
        public IActionResult Insert(MISAEntity entity)
        {
            try
            {
                var res = _baseService.Insert(entity);

                if (res > 0)
                {
                    return Ok();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Cập nhật dữ liệu
        /// </summary>
        /// <param name="entity">dữ liệu cập nhật</param>
        /// <param name="id">id của dữ liệu được cập nhật</param>
        /// <returns>
        ///  HttpCode: 201 nếu cập nhật được dữ liệu
        ///  Lỗi dữ liệu không hợp lệ : 400 (BadRequest)
        ///  HttpCode: 500 nếu có lỗi hoặc Exception xảy ra trên Server
        /// </returns>
        /// CreatedBy: DMTIEN (15/5/2021)
        [HttpPut("{id}")]
        public IActionResult Update(MISAEntity entity, Guid id)
        {
            try
            {
                var res = _baseService.Update(entity, id);

                if (res > 0)
                {
                    return Ok();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="id">id của dữ liệu cần xóa</param>
        /// <returns>số bản ghi đã xoá</returns>
        /// CreatedBy: DMTIEN (15/5/2021)
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var res = _baseService.Delete(id);

                if (res > 0)
                {
                    return Ok();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Method
    }
}