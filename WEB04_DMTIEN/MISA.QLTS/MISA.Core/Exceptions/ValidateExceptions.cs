using System;

namespace MISA.Core.Exceptions
{
    public class ValidateExceptions : Exception
    {
        #region Declare

        /// <summary>
        /// thông báo cho người dùng
        /// </summary>
        public string UserMessenger = string.Empty;

        #endregion Declare

        #region Method

        /// <summary>
        /// Chỉnh sửa thông báo lỗi
        /// </summary>
        /// <param name="msg">thông báo</param>
        /// <param name="data">dữ liệu</param>
        /// CreatedBy: DMTIEN (14/5/2021)
        public ValidateExceptions(string msg, object data = null) : base(msg, new Exception())
        {
            try
            {
                this.UserMessenger = msg;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Method
    }
}