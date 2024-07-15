using CSharp.AutoPoint.Training.Data;
using CSharp.AutoPoint.Training.Interfaces;
using CSharp.AutoPoint.Training.Models;
using CSharp.AutoPoint.Training.Services;
using Moq;
using NUnit.Framework;

namespace CSharp.AutoPoint.Training.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        private Mock<IUserRepository> _mockUserRepository;
        private IUserService _userService;

        [SetUp]
        public void Setup()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _userService = new UserService(_mockUserRepository.Object);
        }

        [Test]
        public void GetUserById_ValidId_ReturnsUser()
        {
            // Arrange
            var userId = 1;
            var expectedUser = new User
            {
                Id = userId,
                Name = "Mohit",
                Email = "Mohit@gmail.com",
                Role = "Student"
            };
            _mockUserRepository.Setup(repo => repo.GetUserById(userId)).Returns(expectedUser);

            // Act
            var result = _userService.GetUserById(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedUser.Id, result.Id);
            Assert.AreEqual(expectedUser.Name, result.Name);
            Assert.AreEqual(expectedUser.Email, result.Email);
            Assert.AreEqual(expectedUser.Role, result.Role);
        }

        [Test]
        public void GetUserById_InvalidId_ReturnsNull()
        {
            // Arrange
            var userId = 10000;
            _mockUserRepository.Setup(repo => repo.GetUserById(userId)).Returns((User)null);

            // Act
            var result = _userService.GetUserById(userId);

            // Assert
            Assert.IsNull(result);
        }
    }
}
