using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST_SOFTWARE.CORE.Response
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        {
            IsValid = false;
            Message = string.Empty;
        }
        public T? Data { get; set; }
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public Exception? Exception { get; set; }
        public void SetException(Exception exepction)
        {
            IsValid = false;
            Message = exepction.Message;
            Exception = exepction;
        }
        public void SetFail(string message)
        {
            IsValid = false;
            Message = message;
        }
        public void SetSuccess()
        {
            IsValid = true;
        }
    }
}
