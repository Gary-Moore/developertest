using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKParliament.CodeTest.Services.Exceptions
{
    public class AlreadyCompleteException : Exception
    {
        public AlreadyCompleteException(IEnumerable<string> errors)
        {
            Errors = errors;
        }

        public AlreadyCompleteException(string error)
        {
            Errors = Errors.Append(error);
        }

        public IEnumerable<string> Errors { get; } = new List<string>();

    }
}
