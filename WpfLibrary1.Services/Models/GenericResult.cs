using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WpfLibrary1.Services.Models
{
    public class GenericResult<T>
    {
        public bool IsSuccess { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }

        public GenericResult()
        {
        }

        public GenericResult(T result)
            : this(result, (int)HttpStatusCode.OK)
        {
        }

        public GenericResult(T result, int code)
            : this(result, code, string.Empty)
        {
        }

        public GenericResult(T result, int code, string message)
        {
            Result = result;
            Message = message;
            Code = code;
        }

        public GenericResult(int code, string message)
        {
            Message = message;
            Code = code;
        }

        public static GenericResult<T> Fail(string message)
        {
            return new GenericResult<T>((int)HttpStatusCode.BadRequest, message);
        }

        public static GenericResult<T> Fail(string message, int code)
        {
            return new GenericResult<T>(code, message);
        }

        public static GenericResult<T> Success(T answer)
        {
            return new GenericResult<T>(answer);
        }
    }
}
