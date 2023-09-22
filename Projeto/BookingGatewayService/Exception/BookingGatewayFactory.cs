using System;
using System.Collections.Generic;

namespace BookingGatewayRepository
{
    public class BookingGatewayFactory
    {
        private List<IBookingGateway> gateways = new List<IBookingGateway>();

        [Obsolete("Use CreateObject instead.")]
        public IBookingGateway NewObject()
        {
            throw new NotSupportedException("NewObject is deprecated. Use CreateObject instead.");
        }

        public IBookingGateway CreateObject()
        {
            IBookingGateway gateway = new BookingGatewayRepository();
            gateways.Add(gateway);
            return gateway;
        }

        public List<IBookingGateway> GetGateways()
        {
            return gateways;
        }

        // Método para obter um gateway específico pelo índice
        public IBookingGateway GetGateway(int index)
        {
            if (index >= 0 && index < gateways.Count)
            {
                return gateways[index];
            }
            else
            {
                throw new IndexOutOfRangeException("Invalid index. No gateway found at the specified index.");
            }
        }
    }
}
