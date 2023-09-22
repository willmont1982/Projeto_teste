using System;

namespace BookingGatewayRepository
{
    public class ReadOperationInProgressException : Exception
    {
        public ReadOperationInProgressException(string message) : base(message) { }
    }
}
