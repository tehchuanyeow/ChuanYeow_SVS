using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChuanYeow_SVS_FullWebApp.Controllers
{
    public class ValidationFailureException : Exception
    {
        public ValidationFailureException(string input) : base("Validation Failure Exception: " + input) { }
    }
}