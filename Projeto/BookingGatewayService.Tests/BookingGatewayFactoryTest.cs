using BookingGatewayRepository;
using Moq;
using Xunit;

namespace BookingGatewayRepository.Tests
{
    public class BookingGatewayFactoryTest
    {
        [Fact]
        public void CreateObject_ShouldReturnValidGateway()
        {
            // Arrange
            var factory = new BookingGatewayFactory();

            // Act
            var gateway = factory.CreateObject();

            // Assert
            Assert.NotNull(gateway);
            Assert.IsType<BookingGatewayRepository>(gateway);
        }

        [Fact]
        public void NewObject_ShouldThrowNotSupportedException()
        {
            // Arrange
            var factory = new BookingGatewayFactory();

            // Act & Assert
            Assert.Throws<NotSupportedException>(() => factory.NewObject());
        }

        [Fact]
        public void GetGateway_WithValidIndex_ShouldReturnGateway()
        {
            // Arrange
            var factory = new BookingGatewayFactory();
            var gateway = factory.CreateObject();

            // Act
            var retrievedGateway = factory.GetGateway(0);

            // Assert
            Assert.NotNull(retrievedGateway);
            Assert.Same(gateway, retrievedGateway);
        }

        [Fact]
        public void GetGateway_WithInvalidIndex_ShouldThrowException()
        {
            // Arrange
            var factory = new BookingGatewayFactory();

            // Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => factory.GetGateway(0));
        }
    }
}
