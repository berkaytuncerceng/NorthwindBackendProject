using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class SucceededResult : Result
    {
        public SucceededResult(string message) : base(true, message)
        {

        }
        public SucceededResult() : base(true)
        {

        }
    }
}
