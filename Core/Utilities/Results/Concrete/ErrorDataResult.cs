using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, bool succeeded, string message) : base(data, false, message)
        {

        }
        public ErrorDataResult(T data, bool succeeded) : base(data, false)
        {

        }
    }
}
