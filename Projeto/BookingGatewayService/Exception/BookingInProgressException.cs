using System;

namespace BookingGatewayRepository
{
    public class BookingInProgressException : Exception
    {
        public BookingInProgressException(string message) : base(message) { }
    }
}
