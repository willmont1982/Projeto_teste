using System;
using System.Collections.Generic;
using BookingGatewayRepository.Model;

namespace BookingGatewayRepository
{
    public class BookingGatewayRepository : IBookingGateway
    {
        private bool isBookingInProgress = false;

        public void StartBooking()
        {
            if (isBookingInProgress)
            {
                throw new BookingInProgressException("Booking is already in progress.");
            }

            // Iniciar processo de reserva
            isBookingInProgress = true;
        }

        public void Booking(TransactionData data)
        {
            if (!isBookingInProgress)
            {
                throw new NoStartBookingException("No booking process started.");
            }

           public void Booking(TransactionData data)
{
    if (!isBookingInProgress)
    {
        throw new NoStartBookingException("No booking process started.");
    }

    if (data == null)
    {
        throw new ArgumentNullException(nameof(data), "TransactionData cannot be null.");
    }
}
        }

        public void EndBooking()
        {
            if (!isBookingInProgress)
            {
                throw new NoStartBookingException("No booking process started.");
            }

            // Finalizar processo de reserva
            isBookingInProgress = false;
        }

        public List<TransactionStatus> GetBookingStatus(string parameter)
        {
            if (isBookingInProgress)
            {
                throw new BookingInProgressException("Booking is in progress.");
            }

           
            return new List<TransactionStatus>();
        }
    }
}
