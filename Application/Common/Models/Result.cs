using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class Result
    {
        private bool succeeded;
        private string[] errors;
        
        internal Result(bool succeeded, IEnumerable<string> errors)
        {
            Succeded = succeeded;
            Errors = Errors.ToArray();
        }

        public bool Succeded
        {
            get { return succeeded; }
            set { succeeded = value; }
        }
        public string[] Errors
        {
            get { return errors; }
            set { errors = value; }
        }

        public static Result Success()
        {
            return new Result(true, new string[] { });
        }

        public static Result Failure(IEnumerable<string> errors)
        {
            return new Result(false, errors);
        }
    }
}
