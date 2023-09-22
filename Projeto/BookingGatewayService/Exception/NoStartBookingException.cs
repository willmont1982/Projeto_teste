using System;

namespace BookingGatewayRepository
{
    public class NoStartBookingException : Exception
    {
        public NoStartBookingException(string message) : base(message) { }
    }
}
