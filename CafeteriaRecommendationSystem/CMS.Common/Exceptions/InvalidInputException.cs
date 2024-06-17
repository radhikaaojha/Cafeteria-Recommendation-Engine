﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Exceptions
{
    public class InvalidInputException : Exception
    {
        public ErrorResponse.ErrorEnum ErrCode { get; set; }

        public InvalidInputException(string details, Exception ex = null, ILogger logger = null) : base(details, ex)
        {
            if (logger != null)
            {
                logger.LogError(Message);
            }
            ErrCode = ErrorResponse.ErrorEnum.BadRequest;
        }
    }
}
