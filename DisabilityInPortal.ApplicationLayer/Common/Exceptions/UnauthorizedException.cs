using System;

namespace DisabilityInPortal.ApplicationLayer.Common.Exceptions
{
    public class UnauthorizedException : ApplicationException
    {
        public UnauthorizedException(string message) : base(message)
        {
        }
    }
}