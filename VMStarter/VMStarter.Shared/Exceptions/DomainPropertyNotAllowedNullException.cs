using System;
using System.Collections.Generic;
using System.Text;

namespace VMStarter.Shared.Exceptions
{
    public class DomainPropertyNotAllowedNullException<T> : Exception
    {
        public DomainPropertyNotAllowedNullException(string field):base(String.Format("Domain validation exception: property '{0}' is required in domain {1}", field, typeof(T).Name))
        {

        }
    }
}
