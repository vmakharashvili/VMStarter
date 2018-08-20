using System;
using System.Collections.Generic;
using System.Text;

namespace VMStarter.Shared.Exceptions
{
    public class DomainValidationException : Exception
    {
        public DomainValidationException(string message):base(String.Format("Domain validation Exception: {0}", message))
        {
           
        }
    }
}
