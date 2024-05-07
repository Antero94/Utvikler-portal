using Microsoft.AspNetCore.Mvc;
using Moq;
using Utvikler_portal.JobSeekerModul.Models.DTOs;
using Utvikler_portal.JobSeekerModul.Services.Interfaces;
using Utvikler_portal.Shared.Controllers;

namespace UtviklerPortalAPI.UnitTests.Controllers;

public class UserControllerTests
{
    private readonly Mock<IUserService> _userServiceMock = new();
    private readonly UserController _userController;

    public UserControllerTests()
    {
        _userController = new UserController(_userServiceMock.Object);
    }

    [Fact]
    public async Task GetAllUsers_ReturnsAllUsers()
    {
        // Arrange
        var users = new List<UserDTO>
        {
            new UserDTO(Guid.NewGuid(), "John", "Doe", "john@mail.com", DateTime.Now, DateTime.Now),
            new UserDTO(Guid.NewGuid(), "Jane", "Doe", "jane@mail.com", DateTime.Now, DateTime.Now)
        };
        _userServiceMock.Setup(service => service.GetAllUsersAsync(1, 10, "defaultSortProperty")).ReturnsAsync(users);

        // Act
        var result = await _userController.GetAllUsers(1, 10, "defaultSortProperty");

        // Assert
        var actionResult = Assert.IsType<ActionResult<IEnumerable<UserDTO>>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var returnValue = Assert.IsType<List<UserDTO>>(okResult.Value);
        Assert.Equal(2, returnValue.Count);
    }

    [Fact]
    public async Task GetUserById_UserExists_ReturnsUser()
    {
        // Arrange
        Guid userId = Guid.NewGuid();
        var userDTO = new UserDTO(userId, "John", "Doe", "john@mail.com", DateTime.Now, DateTime.Now);
        _userServiceMock.Setup(service => service.GetUserByIdAsync(userId)).ReturnsAsync(userDTO);

        // Act
        var result = await _userController.GetUserByIdAsync(userId);

        // Assert
        var actionResult = Assert.IsType<ActionResult<UserDTO>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var returnedUser = Assert.IsType<UserDTO>(okResult.Value);
        Assert.Equal(userId, returnedUser.Id);
    }

    [Fact]
    public async Task GetUserById_UserDoesNotExist_ReturnsNotFound()
    {
        // Arrange
        Guid userId = Guid.NewGuid();
        _userServiceMock.Setup(service => service.GetUserByIdAsync(userId)).ReturnsAsync((UserDTO)null!);

        // Act
        var result = await _userController.GetUserByIdAsync(userId);

        // Assert
        Assert.IsType<NotFoundObjectResult>(result.Result);
    }

    [Fact]
    public async Task CreateUser_WithValidData_ReturnsCreatedUser()
    {
        // Arrange
        var newUserDTO = new UserDTO(Guid.NewGuid(), "New", "User", "newuser@mail.com", DateTime.Now, DateTime.Now);
        _userServiceMock.Setup(service => service.CreateUserAsync(newUserDTO)).ReturnsAsync(newUserDTO);

        // Act
        var result = await _userController.CreateUserAsync(newUserDTO);

        // Assert
        var actionResult = Assert.IsType<ActionResult<UserDTO>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var returnedUser = Assert.IsType<UserDTO>(okResult.Value);
        Assert.NotNull(returnedUser);
        Assert.Equal(newUserDTO.Email, returnedUser.Email);
    }

    [Fact]
    public async Task UpdateUser_UserExists_ReturnsUpdatedUser()
    {
        // Arrange
        Guid userId = Guid.NewGuid();
        var updatedUserDTO = new UserDTO(userId, "Updated", "User", "updateduser@mail.com", DateTime.Now, DateTime.Now);
        _userServiceMock.Setup(service => service.UpdateUserAsync(userId, updatedUserDTO)).ReturnsAsync(updatedUserDTO);

        // Act
        var result = await _userController.UpdateUserAsync(userId, updatedUserDTO);

        // Assert
        var actionResult = Assert.IsType<ActionResult<UserDTO>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var returnedUser = Assert.IsType<UserDTO>(okResult.Value);
        Assert.Equal("Updated", returnedUser.FirstName);
    }

    [Fact]
    public async Task DeleteUser_UserExists_ReturnsOk()
    {
        // Arrange
        Guid userId = Guid.NewGuid();
        var userDTO = new UserDTO(userId, "John", "Doe", "john@example.com", DateTime.Now, DateTime.Now);
        _userServiceMock.Setup(service => service.DeleteUserAsync(userId)).ReturnsAsync(userDTO);

        // Act
        var result = await _userController.DeleteUserAsync(userId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedUser = Assert.IsType<UserDTO>(okResult.Value);
        Assert.Equal(userId, returnedUser.Id);
    }

    [Fact]
    public async Task DeleteUser_UserDoesNotExist_ReturnsNotFound()
    {
        // Arrange
        Guid userId = Guid.NewGuid();
        _userServiceMock.Setup(service => service.DeleteUserAsync(userId)).ReturnsAsync((UserDTO)null!);

        // Act
        var result = await _userController.DeleteUserAsync(userId);

        // Assert
        Assert.IsType<NotFoundObjectResult>(result.Result);
    }
}
