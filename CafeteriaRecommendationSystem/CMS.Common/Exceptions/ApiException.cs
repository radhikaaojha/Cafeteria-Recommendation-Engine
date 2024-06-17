using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Exceptions
{
    public class ApiException : Exception
    {
        public ErrorResponse.ErrorEnum ErrCode { get; set; }

        public ApiException(string details, Exception ex = null) : base(details, ex)
        {
            ErrCode = ErrorResponse.ErrorEnum.BadRequest;
        }

        public ApiException(ErrorResponse.ErrorEnum errorCode, string details = null, Exception ex = null, bool rawMsg = false) : base(rawMsg ? details : (ErrorResponse.GetErrorMessage(errorCode) + ": " + details), ex)
        {
            ErrCode = errorCode;
        }
    }
}
