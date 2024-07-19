using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(bool succeeded, string message) : this(succeeded)
        {
            Message = message;
        }
        public Result(bool succeeded)
        {
            Succeeded = succeeded;
        }
        public bool Succeeded { get; }
        public string Message { get; }
    }
}