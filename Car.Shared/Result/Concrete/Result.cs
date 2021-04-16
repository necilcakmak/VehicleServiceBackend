using Car.Shared.Result.Abstract;
using Car.Shared.Result.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Shared.Result.Concrete
{
    public class Result : IResult
    {
        public Result(ResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
        }
        public Result(ResultStatus resulStatus, string message)
        {
            ResultStatus = resulStatus;
            Message = message;
        }
        public Result(ResultStatus resulStatus, string message, Exception exception)
        {
            ResultStatus = resulStatus;
            Message = message;
            Exception = exception;
        }
        public ResultStatus ResultStatus { get; }

        public string Message { get; }

        public Exception Exception { get; }

        public Dictionary<string, string> validationErrors { get; set; }
    }
}
