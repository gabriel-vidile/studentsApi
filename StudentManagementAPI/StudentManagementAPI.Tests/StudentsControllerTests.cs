using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.StudentManagementAPI.Backend.Controllers;
using StudentManagementAPI.StudentManagementAPI.Backend.Data;
using StudentManagementAPI.StudentManagementAPI.Backend.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace StudentManagementAPI.Tests
{
    public class StudentsControllerTests
    {
        private readonly ApplicationDbContext _context;
        private readonly StudentsController _controller;

        public StudentsControllerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new ApplicationDbContext(options);

            DbInitializer.Initialize(_context);

            _controller = new StudentsController(_context);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "admin"),
                new Claim(ClaimTypes.NameIdentifier, "1")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bGz8!7k2pD9oQ5t#3FjZ7*V1x@2lMhD8"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "https://localhost:7111",
                audience: "https://localhost:7111",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(claims)),
                    Request =
                    {
                        Headers =
                        {
                            {"Authorization", $"Bearer {tokenString}"}
                        }
                    }
                }
            };
        }

        [Fact]
        public async Task GetStudents_ReturnsListOfStudents()
        {
            var result = await _controller.GetStudents();

            var okResult = Assert.IsType<ActionResult<IEnumerable<Student>>>(result);
            var students = Assert.IsAssignableFrom<IEnumerable<Student>>(okResult.Value);
            Assert.NotEmpty(students);
        }

        [Fact]
        public async Task GetStudent_ExistingId_ReturnsStudent()
        {
            var studentId = 1;

            var result = await _controller.GetStudent(studentId);

            var okResult = Assert.IsType<ActionResult<Student>>(result);
            var student = Assert.IsType<Student>(okResult.Value);
            Assert.Equal(studentId, student.Id);
        }

        [Fact]
        public async Task GetStudent_NonExistingId_ReturnsNotFound()
        {
            var studentId = 999;

            var result = await _controller.GetStudent(studentId);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task PostStudent_ValidStudent_ReturnsCreatedStudent()
        {
            var newStudent = new Student
            {
                Nome = "New Student",
                Idade = 15,
                Serie = 10,
                NotaMedia = 9.0,
                Endereco = "123 New St",
                NomePai = "Parent Name",
                NomeMae = "Parent Name",
                DataNascimento = DateTime.Parse("2009-01-01")
            };

            var result = await _controller.PostStudent(newStudent);

            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var student = Assert.IsType<Student>(createdResult.Value);
            Assert.Equal(newStudent.Nome, student.Nome);
        }

        [Fact]
        public async Task PutStudent_ValidId_UpdatesStudent()
        {
            var studentId = 1;
            var updatedStudent = new Student
            {
                Id = studentId,
                Nome = "Updated Name",
                Idade = 16,
                Serie = 11,
                NotaMedia = 8.5,
                Endereco = "456 Updated St",
                NomePai = "Updated Parent",
                NomeMae = "Updated Parent",
                DataNascimento = DateTime.Parse("2008-01-01")
            };

            var result = await _controller.PutStudent(studentId, updatedStudent);

            Assert.IsType<NoContentResult>(result);
            var studentInDb = await _context.Students.FindAsync(studentId);
            Assert.Equal("Updated Name", studentInDb.Nome);
        }

        [Fact]
        public async Task PutStudent_NonMatchingId_ReturnsBadRequest()
        {
            var studentId = 12;
            var updatedStudent = new Student { Id = 123123 };
            var result = await _controller.PutStudent(studentId, updatedStudent);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task DeleteStudent_ExistingId_RemovesStudent()
        {
            var studentId = 2;

            var result = await _controller.DeleteStudent(studentId);

            Assert.IsType<NoContentResult>(result);
            var studentInDb = await _context.Students.FindAsync(studentId);
            Assert.Null(studentInDb);
        }

        [Fact]
        public async Task DeleteStudent_NonExistingId_ReturnsNotFound()
        {
            var studentId = 999;

            var result = await _controller.DeleteStudent(studentId);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
