using Microsoft.AspNetCore.Mvc;
using Moq;
using Utvikler_portal.JobSeekerModul.Models.DTOs;
using Utvikler_portal.JobSeekerModul.Services.Interfaces;
using Utvikler_portal.Shared.Controllers;

namespace UtviklerPortalAPI.UnitTests.Controllers;

public class SkillControllerTests
{
    private readonly Mock<ISkillService> _skillServiceMock = new();
    private readonly SkillController _skillController;

    public SkillControllerTests()
    {
        _skillController = new SkillController(_skillServiceMock.Object);
    }

    [Fact]
    public async Task GetAllSkills_ReturnsAllSkills()
    {
        // Arrange
        var skills = new List<SkillDTO>
        {
            new SkillDTO(Guid.NewGuid(), Guid.NewGuid(), "JavaScript", "Advanced"),
            new SkillDTO(Guid.NewGuid(), Guid.NewGuid(), "Python", "Intermediate")
        };
        _skillServiceMock.Setup(service => service.GetAllSkillsAsync(1, 10, "defaultSortProperty")).ReturnsAsync(skills);

        // Act
        var result = await _skillController.GetAllSkills(1, 10, "defaultSortProperty");

        // Assert
        var actionResult = Assert.IsType<ActionResult<IEnumerable<SkillDTO>>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var returnValue = Assert.IsType<List<SkillDTO>>(okResult.Value);
        Assert.Equal(2, returnValue.Count);
    }

    [Fact]
    public async Task GetSkillById_SkillExists_ReturnsSkill()
    {
        // Arrange
        Guid skillId = Guid.NewGuid();
        var skillDTO = new SkillDTO(skillId, Guid.NewGuid(), "JavaScript", "Advanced");
        _skillServiceMock.Setup(service => service.GetSkillByIdAsync(skillId)).ReturnsAsync(skillDTO);

        // Act
        var result = await _skillController.GetSkillByIdAsync(skillId);

        // Assert
        var actionResult = Assert.IsType<ActionResult<SkillDTO>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var returnedSkill = Assert.IsType<SkillDTO>(okResult.Value);
        Assert.Equal(skillId, returnedSkill.Id);
    }

    [Fact]
    public async Task GetSkillById_SkillDoesNotExist_ReturnsNotFound()
    {
        // Arrange
        Guid skillId = Guid.NewGuid();
        _skillServiceMock.Setup(service => service.GetSkillByIdAsync(skillId)).ReturnsAsync((SkillDTO)null!);

        // Act
        var result = await _skillController.GetSkillByIdAsync(skillId);

        // Assert
        Assert.IsType<NotFoundObjectResult>(result.Result);
    }

    [Fact]
    public async Task CreateSkill_ValidData_ReturnsCreatedSkill()
    {
        // Arrange
        var skillDTO = new SkillDTO(Guid.NewGuid(), Guid.NewGuid(), "JavaScript", "Advanced");
        _skillServiceMock.Setup(service => service.CreateSkillAsync(skillDTO)).ReturnsAsync(skillDTO);

        // Act
        var result = await _skillController.CreateSkillAsync(skillDTO);

        // Assert
        var actionResult = Assert.IsType<ActionResult<SkillDTO>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var returnedSkill = Assert.IsType<SkillDTO>(okResult.Value);
        Assert.NotNull(returnedSkill);
    }

    [Fact]
    public async Task UpdateSkill_SkillExists_ReturnsUpdatedSkill()
    {
        // Arrange
        Guid skillId = Guid.NewGuid();
        var skillDTO = new SkillDTO(skillId, Guid.NewGuid(), "JavaScript", "Expert");
        _skillServiceMock.Setup(service => service.UpdateSkillAsync(skillId, skillDTO)).ReturnsAsync(skillDTO);

        // Act
        var result = await _skillController.UpdateSkillAsync(skillId, skillDTO);

        // Assert
        var actionResult = Assert.IsType<ActionResult<SkillDTO>>(result);
        var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var returnedSkill = Assert.IsType<SkillDTO>(okResult.Value);
        Assert.Equal("Expert", returnedSkill.Level);
    }

    [Fact]
    public async Task DeleteSkill_SkillExists_ReturnsNoContent()
    {
        // Arrange
        Guid skillId = Guid.NewGuid();
        _skillServiceMock.Setup(service => service.DeleteSkillAsync(skillId)).Returns(Task.CompletedTask);


        // Act
        var result = await _skillController.DeleteSkillAsync(skillId);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }
}
