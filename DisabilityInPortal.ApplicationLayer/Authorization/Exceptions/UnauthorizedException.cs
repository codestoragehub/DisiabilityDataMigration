using System;

namespace DisabilityInPortal.ApplicationLayer.Authorization.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message)
            : base(message)
        {
        }
    }
}