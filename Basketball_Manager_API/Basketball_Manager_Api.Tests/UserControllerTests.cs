using Basketball_Manager_Api.Controllers;
using Basketball_Manager_Api.Helpers;
using Basketball_Manager_Db.DataAccess;
using Basketball_Manager_Db.Interfaces;
using Xunit;
using Faker;
using Microsoft.EntityFrameworkCore;
using Basketball_Manager_Db.Repositories;
using FakeItEasy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Basketball_Manager_Db.ViewModel;

namespace Basketball_Manager_Api.Tests
{
    public class UserControllerTests
    {
        [Fact]
        public async Task GetUsers_Return_Correct() // do zmiany, nulla wypierdala
        {
            // Arrange
            string userId = "test";
            var dataStore = A.Fake<IUserRepository>();
            var userRepository = A.Fake<ApplicationDbContext>();
            DbContextOptions<ApplicationDbContext> options = new DbContextOptions<ApplicationDbContext>();
            ApplicationDbContext context = new ApplicationDbContext(options);
            JwtService_Api jwtService = new JwtService_Api();
            var controller = new UserController(dataStore, context, jwtService);

            // Act
            var getUsers = await controller.GetUser(userId);

            // Assert
            var result = getUsers.Result as OkObjectResult;
            var returnUser = result.Value as UserViewModel;

            Assert.Equal(userId, returnUser.Id);
        }
    }
}