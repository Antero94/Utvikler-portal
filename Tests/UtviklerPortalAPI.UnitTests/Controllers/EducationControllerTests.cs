using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utvikler_portal.JobSeekerModul.Models.DTOs;
using Utvikler_portal.JobSeekerModul.Services.Interfaces;
using Utvikler_portal.Shared.Controllers;

namespace UtviklerPortalAPI.UnitTests.Controllers;

public class EducationControllerTests
{
    private readonly Mock<IEducationService> _educationServiceMock = new();
    private readonly EducationController _educationController;

    public EducationControllerTests()
    {
        _educationController = new EducationController(_educationServiceMock.Object);
    }

    [Fact]
    public async Task GetAllEducations_ReturnsAllEducations()
    {
        // Arrange
        var educations = new List<EducationDTO>
        {
            new EducationDTO(Guid.NewGuid(), Guid.NewGuid(), "University One", "Bachelor", "Computer Science", DateTime.Now.AddDays(-1000)),
            new EducationDTO(Guid.NewGuid(), Guid.NewGuid(), "University Two", "Master", "Business Administration", DateTime.Now.AddDays(-800))
        };
        _educationServiceMock.Setup(service => service.GetAllEducationsAsync(1, 10, "defaultSortProperty")).ReturnsAsync(educations);

        // Act
        var result = await _educationController.GetAllEducations(1, 10, "defaultSortProperty");

        // Assert
        var actionResult = Assert.IsType<ActionResult<IEnumerable<EducationDTO>>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var returnValue = Assert.IsType<List<EducationDTO>>(okResult.Value);
        Assert.Equal(2, returnValue.Count);
    }

    [Fact]
    public async Task GetEducationById_EducationExists_ReturnsEducation()
    {
        // Arrange
        Guid educationId = Guid.NewGuid();
        var educationDTO = new EducationDTO(educationId, Guid.NewGuid(), "University One", "PhD", "Physics", DateTime.Now.AddDays(-200));
        _educationServiceMock.Setup(service => service.GetEducationByIdAsync(educationId)).ReturnsAsync(educationDTO);

        // Act
        var result = await _educationController.GetEducationByIdAsync(educationId);

        // Assert
        var actionResult = Assert.IsType<ActionResult<EducationDTO>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var returnedEducation = Assert.IsType<EducationDTO>(okResult.Value);
        Assert.Equal(educationId, returnedEducation.Id);
    }

    [Fact]
    public async Task GetEducationById_EducationDoesNotExist_ReturnsNotFound()
    {
        // Arrange
        Guid educationId = Guid.NewGuid();
        _educationServiceMock.Setup(service => service.GetEducationByIdAsync(educationId)).ReturnsAsync((EducationDTO)null);

        // Act
        var result = await _educationController.GetEducationByIdAsync(educationId);

        // Assert
        Assert.IsType<NotFoundObjectResult>(result.Result);
    }

    [Fact]
    public async Task CreateEducation_ValidData_ReturnsCreatedEducation()
    {
        // Arrange
        var educationDTO = new EducationDTO(Guid.NewGuid(), Guid.NewGuid(), "New University", "Associate", "Arts", DateTime.Now);
        _educationServiceMock.Setup(service => service.CreateEducationAsync(It.IsAny<EducationDTO>())).ReturnsAsync(educationDTO);

        // Act
        var result = await _educationController.CreateEducationAsync(educationDTO);

        // Assert
        var actionResult = Assert.IsType<ActionResult<EducationDTO>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var returnedEducation = Assert.IsType<EducationDTO>(okResult.Value);
        Assert.NotNull(returnedEducation);
    }

    [Fact]
    public async Task UpdateEducation_EducationExists_ReturnsUpdatedEducation()
    {
        // Arrange
        Guid educationId = Guid.NewGuid();
        var educationDTO = new EducationDTO(educationId, Guid.NewGuid(), "Updated University", "Doctorate", "Economics", DateTime.Now);
        _educationServiceMock.Setup(service => service.UpdateEducationAsync(educationId, It.IsAny<EducationDTO>())).ReturnsAsync(educationDTO);

        // Act
        var result = await _educationController.UpdateEducationAsync(educationId, educationDTO);

        // Assert
        var actionResult = Assert.IsType<ActionResult<EducationDTO>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var returnedEducation = Assert.IsType<EducationDTO>(okResult.Value);
        Assert.Equal("Economics", returnedEducation.FieldOfStudy);
    }

    [Fact]
    public async Task DeleteEducation_EducationExists_ReturnsNoContent()
    {
        // Arrange
        Guid educationId = Guid.NewGuid();
        _educationServiceMock.Setup(service => service.DeleteEducationAsync(educationId)).Returns(Task.CompletedTask);

        // Act
        var result = await _educationController.DeleteEducationAsync(educationId);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }
}
