using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.DomainLayer
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {

        }
    }
}
