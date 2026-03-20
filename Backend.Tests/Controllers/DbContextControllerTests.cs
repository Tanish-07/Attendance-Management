using Backend.Controllers;
using Backend.Model;
using Backend.Tests.TestHelpers;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using static Backend.Model.AppDbContext;

namespace Backend.Tests.Controllers
{
    public class DbContextControllerTests
    {

        [Fact]
        public void SaveContact_ReturnsOkResult()
        {
            // Arrange
            var context = DbContextFactory.Create();
            var controller = new DbContextController(context);

            var contact = new ContactMessage
            {
                fullName = "Tanish",
                emailId = "tanish@test.com",
                message = "Test message"
            };

            // Act
            var result = controller.SaveContact(contact);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }



        [Fact]
        public void SaveSignUp_NewUser_ReturnsOk()
        {
            // Arrange
            var context = DbContextFactory.Create();
            var controller = new DbContextController(context);

            var user = new SignUp
            {
                fullName = "Test User",
                emailId = "user@test.com",
                password = "123456"
            };

            // Act
            var result = controller.SaveSignUp(user);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }



        [Fact]
        public void SaveSignUp_DuplicateEmail_ReturnsConflict()
        {
            // Arrange
            var context = DbContextFactory.Create();

            context.SaveSignUp.Add(new SignUp
            {
                fullName = "Existing User",
                emailId = "user@test.com",
                password = "123456"
            });

            context.SaveChanges();

            var controller = new DbContextController(context);

            var user = new SignUp
            {
                fullName = "Test User",
                emailId = "user@test.com",
                password = "123456"
            };

            // Act
            var result = controller.SaveSignUp(user);

            // Assert
            Assert.IsType<ConflictObjectResult>(result);
        }



        [Fact]
        public void Login_ValidUser_ReturnsOk()
        {
            // Arrange
            var context = DbContextFactory.Create();

            context.SaveSignUp.Add(new SignUp
            {
                fullName = "Test User",
                emailId = "user@test.com",
                password = "123456"
            });

            context.SaveChanges();

            var controller = new DbContextController(context);

            var login = new LoginDTO
            {
                emailId = "user@test.com",
                password = "123456"
            };

            // Act
            var result = controller.Login(login);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }



        [Fact]
        public void Login_InvalidUser_ReturnsUnauthorized()
        {
            // Arrange
            var context = DbContextFactory.Create();
            var controller = new DbContextController(context);

            var login = new LoginDTO
            {
                emailId = "wrong@test.com",
                password = "wrong"
            };

            // Act
            var result = controller.Login(login);

            // Assert
            Assert.IsType<UnauthorizedObjectResult>(result);
        }



        [Fact]
        public void AdminLogin_ValidAdmin_ReturnsOk()
        {
            // Arrange
            var context = DbContextFactory.Create();

            context.AdminLogins.Add(new adminLogin
            {
                emailId = "admin@test.com",
                password = "admin123"
            });

            context.SaveChanges();

            var controller = new DbContextController(context);

            var admin = new adminLogin
            {
                emailId = "admin@test.com",
                password = "admin123"
            };

            // Act
            var result = controller.adminLog(admin);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }



        [Fact]
        public void AdminLogin_InvalidAdmin_ReturnsUnauthorized()
        {
            // Arrange
            var context = DbContextFactory.Create();
            var controller = new DbContextController(context);

            var admin = new adminLogin
            {
                emailId = "wrong@test.com",
                password = "wrong"
            };

            // Act
            var result = controller.adminLog(admin);

            // Assert
            Assert.IsType<UnauthorizedObjectResult>(result);
        }

    }
}