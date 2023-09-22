using BookingGatewayRepository.Model;
using System;
using System.Collections.Generic;

namespace BookingGatewayRepository
{
    public interface IBookingGateway
    {
        void StartBooking();
        void Booking(TransactionData data);
        void EndBooking();
        List<TransactionStatus> GetBookingStatus(string parameter);
    }
}
