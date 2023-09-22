using System.Collections.Generic;
using BookingGatewayRepository.Model;

namespace BookingGatewayRepository
{
    public interface IDBRepository
    {
        void SaveBooking(TransactionData transactionData);
        List<TransactionStatus> GetStatuses(string parameter);
    }
}
