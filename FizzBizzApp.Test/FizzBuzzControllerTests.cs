using Xunit;
using Moq;
using FizzBuzz.Services.Interfaces;
using FizzBuzzApp.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FizzBizzApp.Test
{
    public class FizzBuzzControllerTests
    {
        [Fact]
        public async Task GetResult_ReturnsOk_WithValidArray()
        {
            // Arrange
            var mockFizzBuzz = new Mock<IFizzBuzz>();
            string[] testInput = { "3", "5", "15", "1" };
            List<string> expectedResults = new List<string> { "Fizz", "Buzz", "FizzBuzz", "Number 1 is not divisible by 3 or 5" };
            mockFizzBuzz.Setup(service => service.GetFizzBuzz(testInput)).ReturnsAsync(expectedResults);
            var controller = new FizzBuzzController(mockFizzBuzz.Object);

            // Act
            var result = await controller.GetResult(testInput);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.True(okResult.StatusCode == 200);
            Assert.Equal(expectedResults, okResult.Value);
        }
        [Fact]  
        public async Task GetResult_ReturnsOk_WithInValidArray()
        {
            // Arrange
            var mockFizzBuzz = new Mock<IFizzBuzz>();
            string[] testInput = { "A", "AA", "A13", "15B" };
            List<string> expectedResults = new List<string> { "Invalid Item", "Invalid Item", "Invalid Item", "Invalid Item" };
            mockFizzBuzz.Setup(service => service.GetFizzBuzz(testInput)).ReturnsAsync(expectedResults);
            var controller = new FizzBuzzController(mockFizzBuzz.Object);

            // Act
            var result = await controller.GetResult(testInput);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.True(okResult.StatusCode == 200);
            Assert.Equal(expectedResults, okResult.Value);
        }

        [Fact]
        public async Task GetResult_ReturnsEmptyList_WithEmptyArray()
        {
            // Arrange
            var mockFizzBuzz = new Mock<IFizzBuzz>();
            string[] testInput = { };
            List<string> expectedResults = new List<string>();
            mockFizzBuzz.Setup(service => service.GetFizzBuzz(testInput)).ReturnsAsync(expectedResults);
            var controller = new FizzBuzzController(mockFizzBuzz.Object);

            // Act
            var result = await controller.GetResult(testInput);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var results = Assert.IsType<List<string>>(okResult.Value);
            Assert.True(results.Count == 0);
            Assert.True(okResult.StatusCode == 200);
            Assert.Equal(expectedResults, okResult.Value);            
            Assert.Empty((IEnumerable<string>)okResult.Value);
        }

        [Fact]
        public async Task GetResult_ReturnsEmptyList_WithNullArray()
        {
            // Arrange
            var mockFizzBuzz = new Mock<IFizzBuzz>();
            string[] testInput = null;
            List<string> expectedResults = new List<string>();
            mockFizzBuzz.Setup(service => service.GetFizzBuzz(testInput)).ReturnsAsync(expectedResults);
            var controller = new FizzBuzzController(mockFizzBuzz.Object);

            // Act
            var result = await controller.GetResult(testInput);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var results = Assert.IsType<List<string>>(okResult.Value);
            Assert.True(results.Count == 0);
            Assert.True(okResult.StatusCode == 200);
            Assert.Equal(expectedResults, okResult.Value);
            Assert.Empty((IEnumerable<string>)okResult.Value);
        }
        [Fact]
        public async Task GetResult_ReturnsBadRequest_WhenExceptionIsThrown()
        {
            // Arrange
            var mockFizzBuzz = new Mock<IFizzBuzz>();
            string[] testInput = { "test", "invalid" }; 
            mockFizzBuzz.Setup(service => service.GetFizzBuzz(testInput))
                        .ThrowsAsync(new Exception("An error occurred")); 

            var controller = new FizzBuzzController(mockFizzBuzz.Object);

            // Act
            var result = await controller.GetResult(testInput);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
            Assert.Equal("An error occurred", badRequestResult.Value); 
        }
    }
}
