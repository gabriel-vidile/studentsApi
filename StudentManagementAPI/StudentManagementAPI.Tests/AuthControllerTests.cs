using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudentManagementAPI.StudentManagementAPI.Backend.Controllers;
using StudentManagementAPI.StudentManagementAPI.Backend.Data;
using StudentManagementAPI.StudentManagementAPI.Backend.Models;
using Xunit.Abstractions;

namespace StudentManagementAPI.Tests
{
    public class AuthControllerTests
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly AuthController _controller;

        public AuthControllerTests()
        {

            var secretKey = "bGz8!7k2pD9oQ5t#3FjZ7*V1x@2lMhD8";
            var validIssuer = "https://localhost:7111";
            var validAudience = "https://localhost:7111";

            // Configuração do IConfiguration com as chaves corretas
            var inMemorySettings = new Dictionary<string, string> {
                {"Jwt:SecretKey", secretKey},
                {"Jwt:ValidIssuer", validIssuer},
                {"Jwt:ValidAudience", validAudience}
            };
            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new ApplicationDbContext(options);

            DbInitializer.Initialize(_context);

            _controller = new AuthController(_context, _configuration);
        }

        [Fact]
        public void Login_UserExists_ReturnsOkResultWithToken()
        {
            var login = new User { Username = "admin", Password = "admin123" };

            var existingUser = _context.Users.FirstOrDefault(u => u.Username == login.Username);
            Assert.NotNull(existingUser);

            var result = _controller.Login(login);

            Assert.IsType<OkObjectResult>(result);

            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);

            var resultValue = okResult.Value;

            Assert.NotNull(resultValue);

            var tokenValue = ((dynamic)resultValue);

            Assert.NotNull(tokenValue);
        }

        [Fact]
        public void Login_UserDoesNotExist_ReturnsUnauthorizedResult()
        {
            var login = new User { Username = "invaliduser", Password = "wrongpassword" };

            var result = _controller.Login(login);

            Assert.IsType<UnauthorizedResult>(result);
        }
    }
}
