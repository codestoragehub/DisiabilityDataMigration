using System;

namespace DisabilityInPortal.ApplicationLayer.Common.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}