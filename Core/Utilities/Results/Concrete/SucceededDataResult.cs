using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class SucceededDataResult<T> : DataResult<T>
    {
        public SucceededDataResult(T data, string message) : base(data, true, message)
        {

        }
        public SucceededDataResult(T data) : base(data, true)
        {

        }

    }
}
