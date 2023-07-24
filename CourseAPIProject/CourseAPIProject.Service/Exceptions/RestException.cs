using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CourseAPIProject.Service.Exceptions
{
    public class RestException:Exception
    {
        public RestException(HttpStatusCode code, List<RestExceptionItem> errors, string message=null)
        {
            Code = code;
            Message = message;
            Errors = errors;
        }
        public RestException(HttpStatusCode code,string key, string errorMessage,string message=null)
        {
            Code = code;
            Errors = new List<RestExceptionItem>() {new RestExceptionItem(key,errorMessage) };
        }

        public RestException(HttpStatusCode code,string message)
        {
            Code=code;
            Message = message;
        }

        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }
        public List<RestExceptionItem> Errors { get; set; }
    }
    public class RestExceptionItem
    {
        public string Key { get; set; }
        public string ErrorMessage { get; set; }
        public RestExceptionItem(string key, string errorMessage)
        {
            Key = key;
            ErrorMessage = errorMessage;
        }
    }
}
