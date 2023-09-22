using System;
using System.Collections.Generic;
using BookingGatewayRepository.Model;

namespace BookingGatewayRepository.Model
{
    public class TransactionData
    {
        public decimal Amount { get; set; }
        public string TransactionTitle { get; set; }
        public string SourceAccountNo { get; set; }
        public string DestAccountNo { get; set; }
        public string UniqueRef { get; set; }
    }
}


    public class TransactionStatus
    {
        public int TransactionId { get; set; }
        public string Status { get; set; }
    }
}

public class BookingGatewayRepository
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

            // Implemente a lógica de reserva aqui
            // Use data para obter os detalhes da transação
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

            // Implemente a lógica para obter status da transação aqui
            return new List<TransactionStatus>();
        }
    }
}

{
    public class BookingInProgressException : Exception
    {
        public BookingInProgressException(string message) : base(message) { }
    }

    public class ReadOperationInProgressException : Exception
    {
        public ReadOperationInProgressException(string message) : base(message) { }
    }

    public class NoStartBookingException : Exception
    {
        public NoStartBookingException(string message) : base(message) { }
    }
}






