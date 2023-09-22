using BookingGatewayRepository;
using BookingGatewayRepository.Model;
using System;
using System.Collections.Generic;
using Xunit;

namespace BookingGatewayRepository.Tests
{
    public class BookingGatewayTest
    {
        [Fact]
        public void StartBooking_ShouldSetBookingInProgressToTrue()
        {
            // Arrange
            var gateway = new BookingGatewayRepository();

            // Act
            gateway.StartBooking();

            // Assert
            Assert.True(gateway.IsBookingInProgress);
        }

        [Fact]
        public void StartBooking_WhenBookingInProgress_ShouldThrowBookingInProgressException()
        {
            // Arrange
            var gateway = new BookingGatewayRepository();
            gateway.StartBooking();

            // Act & Assert
            Assert.Throws<BookingInProgressException>(() => gateway.StartBooking());
        }

        [Fact]
        public void EndBooking_WhenBookingNotInProgress_ShouldThrowNoStartBookingException()
        {
            // Arrange
            var gateway = new BookingGatewayRepository();

            // Act & Assert
            Assert.Throws<NoStartBookingException>(() => gateway.EndBooking());
        }

        [Fact]
        public void EndBooking_ShouldSetBookingInProgressToFalse()
        {
            // Arrange
            var gateway = new BookingGatewayRepository();
            gateway.StartBooking();

            // Act
            gateway.EndBooking();

            // Assert
            Assert.False(gateway.IsBookingInProgress);
        }

        [Fact]
        public void Booking_WithoutStartBooking_ShouldThrowNoStartBookingException()
        {
            // Arrange
            var gateway = new BookingGatewayRepository();
            var transactionData = new TransactionData();

            // Act & Assert
            Assert.Throws<NoStartBookingException>(() => gateway.Booking(transactionData));
        }

        [Fact]
        public void Booking_WithNullTransactionData_ShouldThrowArgumentNullException()
        {
            // Arrange
            var gateway = new BookingGatewayRepository();
            gateway.StartBooking();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => gateway.Booking(null));
        }

        [Fact]
        public void Booking_WithValidTransactionData_ShouldAddToTransactions()
        {
            // Arrange
            var gateway = new BookingGatewayRepository();
            gateway.StartBooking();
            var transactionData = new TransactionData();

            // Act
            gateway.Booking(transactionData);

            // Assert
            Assert.Contains(transactionData, gateway.Transactions);
        }

        [Fact]
        public void GetBookingStatus_WhenBookingInProgress_ShouldThrowBookingInProgressException()
        {
            // Arrange
            var gateway = new BookingGatewayRepository();
            gateway.StartBooking();

            // Act & Assert
            Assert.Throws<BookingInProgressException>(() => gateway.GetBookingStatus("parameter"));
        }

        [Fact]
        public void GetBookingStatus_WithNullParameter_ShouldReturnEmptyList()
        {
            // Arrange
            var gateway = new BookingGatewayRepository();

            // Act
            var result = gateway.GetBookingStatus(null);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetBookingStatus_WithEmptyParameter_ShouldReturnEmptyList()
        {
            // Arrange
            var gateway = new BookingGatewayRepository();

            // Act
            var result = gateway.GetBookingStatus("");

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetBookingStatus_WithValidParameter_ShouldCallGetStatusesOnRepository()
        {
            // Arrange
            var mockRepository = new Mock<IDBRepository>();
            var gateway = new BookingGatewayRepository(mockRepository.Object);
            var parameter = "test";

            // Act
            gateway.GetBookingStatus(parameter);

            // Assert
            mockRepository.Verify(r => r.GetStatuses(parameter), Times.Once);
        }
    }
}
