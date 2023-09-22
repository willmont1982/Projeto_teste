using BookingGatewayRepository;
using BookingGatewayRepository.Model;
using Moq;
using System;
using Xunit;

namespace BookingGatewayService.Tests
{
    public class BookingGatewayServiceStructureTest
    {
        [Fact]
        public void StartBooking_ShouldCallStartBookingOnGateway()
        {
            // Arrange
            var mockGateway = new Mock<IBookingGateway>();
            var service = new BookingGatewayService(mockGateway.Object);

            // Act
            service.StartBooking();

            // Assert
            mockGateway.Verify(g => g.StartBooking(), Times.Once);
        }

        [Fact]
        public void Booking_WithoutStartBooking_ShouldThrowNoStartBookingException()
        {
            // Arrange
            var mockGateway = new Mock<IBookingGateway>();
            var service = new BookingGatewayService(mockGateway.Object);
            var transactionData = new TransactionData();

            // Act & Assert
            Assert.Throws<NoStartBookingException>(() => service.Booking(transactionData));
        }

        [Fact]
        public void Booking_WithValidTransactionData_ShouldCallBookingOnGateway()
        {
            // Arrange
            var mockGateway = new Mock<IBookingGateway>();
            var service = new BookingGatewayService(mockGateway.Object);
            var transactionData = new TransactionData();

            // Act
            service.StartBooking();
            service.Booking(transactionData);

            // Assert
            mockGateway.Verify(g => g.Booking(transactionData), Times.Once);
        }

        [Fact]
        public void EndBooking_ShouldCallEndBookingOnGateway()
        {
            // Arrange
            var mockGateway = new Mock<IBookingGateway>();
            var service = new BookingGatewayService(mockGateway.Object);

            // Act
            service.EndBooking();

            // Assert
            mockGateway.Verify(g => g.EndBooking(), Times.Once);
        }

        [Fact]
        public void GetBookingStatus_ShouldCallGetBookingStatusOnGateway()
        {
            // Arrange
            var mockGateway = new Mock<IBookingGateway>();
            var service = new BookingGatewayService(mockGateway.Object);
            var parameter = "test";

            // Act
            service.GetBookingStatus(parameter);

            // Assert
            mockGateway.Verify(g => g.GetBookingStatus(parameter), Times.Once);
        }
    }
}
