using Enterprise.Hosting.Extensions;
using Microsoft.Extensions.Hosting;
using Moq;
using Xunit;

namespace Enterprise.Hosting.Tests.Extensions
{
    public class IHostEnvironmentExtensionsTests
    {
        [Fact]
        public void IsLocal_ShouldReturnTrue_WhenEnvironmentIsLocal()
        {
            // Arrange
            Mock<IHostEnvironment> mockHostEnvironment = new Mock<IHostEnvironment>();
            mockHostEnvironment.Setup(e => e.EnvironmentName).Returns("Local");

            // Act
            bool result = mockHostEnvironment.Object.IsLocal();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsLocal_ShouldReturnFalse_WhenEnvironmentIsNotLocal()
        {
            // Arrange
            Mock<IHostEnvironment> mockHostEnvironment = new Mock<IHostEnvironment>();
            mockHostEnvironment.Setup(e => e.EnvironmentName).Returns("Production");

            // Act
            bool result = mockHostEnvironment.Object.IsLocal();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsLocal_ShouldReturnFalse_WhenEnvironmentIsNull()
        {
            // Arrange
            Mock<IHostEnvironment> mockHostEnvironment = new Mock<IHostEnvironment>();
            mockHostEnvironment.Setup(e => e.EnvironmentName).Returns((string)null!);

            // Act
            bool result = mockHostEnvironment.Object.IsLocal();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsLocal_ShouldReturnFalse_WhenEnvironmentIsEmpty()
        {
            // Arrange
            Mock<IHostEnvironment> mockHostEnvironment = new Mock<IHostEnvironment>();
            mockHostEnvironment.Setup(e => e.EnvironmentName).Returns(string.Empty);

            // Act
            bool result = mockHostEnvironment.Object.IsLocal();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsLocal_ShouldReturnTrue_WhenEnvironmentIsLocal_CaseInsensitive()
        {
            // Arrange
            Mock<IHostEnvironment> mockHostEnvironment = new Mock<IHostEnvironment>();
            mockHostEnvironment.Setup(e => e.EnvironmentName).Returns("local");

            // Act
            bool result = mockHostEnvironment.Object.IsLocal();

            // Assert
            Assert.True(result);
        }
    }
}
