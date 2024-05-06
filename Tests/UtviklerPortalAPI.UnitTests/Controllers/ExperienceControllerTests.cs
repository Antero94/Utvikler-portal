using Microsoft.AspNetCore.Mvc;
using Moq;
using Utvikler_portal.JobSeekerModul.Models.DTOs;
using Utvikler_portal.JobSeekerModul.Services.Interfaces;
using Utvikler_portal.Shared.Controllers;

namespace UtviklerPortalAPI.UnitTests.Controllers;

public class ExperienceControllerTests
{
    private readonly Mock<IExperienceService> _experienceServiceMock = new();
    private readonly ExperienceController _experienceController;

    public ExperienceControllerTests()
    {
        _experienceController = new ExperienceController(_experienceServiceMock.Object);
    }

    [Fact]
    public async Task GetAllExperiences_ReturnsAllExperiences()
    {
        // Arrange
        var experiences = new List<ExperienceDTO>
        {
            new ExperienceDTO(Guid.NewGuid(), Guid.NewGuid(), "Company One", "Developer", DateTime.Now.AddDays(-100), DateTime.Now),
            new ExperienceDTO(Guid.NewGuid(), Guid.NewGuid(), "Company Two", "Manager", DateTime.Now.AddDays(-200), DateTime.Now)
        };
        _experienceServiceMock.Setup(service => service.GetAllExperiencesAsync(1, 10, "defaultSortProperty")).ReturnsAsync(experiences);

        // Act
        var result = await _experienceController.GetAllExperiences(1, 10, "defaultSortProperty");

        // Assert
        var actionResult = Assert.IsType<ActionResult<IEnumerable<ExperienceDTO>>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var returnValue = Assert.IsType<List<ExperienceDTO>>(okResult.Value);
        Assert.Equal(2, returnValue.Count);
    }

    [Fact]
    public async Task GetExperienceById_ExperienceExists_ReturnsExperience()
    {
        // Arrange
        Guid experienceId = Guid.NewGuid();
        var experienceDTO = new ExperienceDTO(experienceId, Guid.NewGuid(), "Company One", "Developer", DateTime.Now.AddDays(-100), DateTime.Now);
        _experienceServiceMock.Setup(service => service.GetExperienceByIdAsync(experienceId)).ReturnsAsync(experienceDTO);

        // Act
        var result = await _experienceController.GetExperienceByIdAsync(experienceId);

        // Assert
        var actionResult = Assert.IsType<ActionResult<ExperienceDTO>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var returnedExperience = Assert.IsType<ExperienceDTO>(okResult.Value);
        Assert.Equal(experienceId, returnedExperience.Id);
    }

    [Fact]
    public async Task GetExperienceById_ExperienceDoesNotExist_ReturnsNotFound()
    {
        // Arrange
        Guid experienceId = Guid.NewGuid();
        _experienceServiceMock.Setup(service => service.GetExperienceByIdAsync(experienceId)).ReturnsAsync((ExperienceDTO)null);

        // Act
        var result = await _experienceController.GetExperienceByIdAsync(experienceId);

        // Assert
        Assert.IsType<NotFoundObjectResult>(result.Result);
    }

    [Fact]
    public async Task CreateExperience_ValidData_ReturnsCreatedExperience()
    {
        // Arrange
        var experienceDTO = new ExperienceDTO(Guid.NewGuid(), Guid.NewGuid(), "Company Three", "Tester", DateTime.Now.AddDays(-50), DateTime.Now);
        _experienceServiceMock.Setup(service => service.CreateExperienceAsync(It.IsAny<ExperienceDTO>())).ReturnsAsync(experienceDTO);

        // Act
        var result = await _experienceController.CreateExperienceAsync(experienceDTO);

        // Assert
        var actionResult = Assert.IsType<ActionResult<ExperienceDTO>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var returnedExperience = Assert.IsType<ExperienceDTO>(okResult.Value);
        Assert.NotNull(returnedExperience);
    }

    [Fact]
    public async Task UpdateExperience_ExperienceExists_ReturnsUpdatedExperience()
    {
        // Arrange
        Guid experienceId = Guid.NewGuid();
        var experienceDTO = new ExperienceDTO(experienceId, Guid.NewGuid(), "Company Four", "Lead", DateTime.Now.AddDays(-300), DateTime.Now);
        _experienceServiceMock.Setup(service => service.UpdateExperienceAsync(experienceId, It.IsAny<ExperienceDTO>())).ReturnsAsync(experienceDTO);

        // Act
        var result = await _experienceController.UpdateExperienceAsync(experienceId, experienceDTO);

        // Assert
        var actionResult = Assert.IsType<ActionResult<ExperienceDTO>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var returnedExperience = Assert.IsType<ExperienceDTO>(okResult.Value);
        Assert.Equal("Lead", returnedExperience.Position);
    }

    [Fact]
    public async Task DeleteExperience_ExperienceExists_ReturnsNoContent()
    {
        // Arrange
        Guid experienceId = Guid.NewGuid();
        _experienceServiceMock.Setup(service => service.DeleteExperienceAsync(experienceId)).Returns(Task.CompletedTask);

        // Act
        var result = await _experienceController.DeleteExperienceAsync(experienceId);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }
}
