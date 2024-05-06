using Microsoft.AspNetCore.Mvc;
using Moq;
using Utvikler_portal.JobbModul.Models.DTOs;
using Utvikler_portal.JobbModul.Services.Interfaces;
using Utvikler_portal.Shared.Controllers;

namespace UtviklerPortalAPI.UnitTests.Controllers;

public class CompanyControllerTests
{
    private readonly Mock<ICompanyService> _companyServiceMock = new();
    private readonly Mock<IJobService> _jobServiceMock = new();
    private readonly CompanyController _companyController;
    public CompanyControllerTests()
    {
        _companyController = new CompanyController(_companyServiceMock.Object, _jobServiceMock.Object);
    }
    

    [Fact]
    public async Task GetAllCompaniesAsync_WithPagination_ReturnsListOfCompanyAccountDTO()
    {
        // Arrange
        Guid idOne = Guid.NewGuid();
        Guid idTwo = Guid.NewGuid();
        Guid idThree = Guid.NewGuid();
        List<CompanyAccountDTO> dtos = new();

        var companyOne = new CompanyAccountDTO(idOne, "Company One", "12345678", "CP_One@example.com", DateTime.Now, DateTime.Now);
        var companyTwo = new CompanyAccountDTO(idTwo, "Company Two", "43218765", "CP_Two@example.com", DateTime.Now, DateTime.Now);
        var companyThree = new CompanyAccountDTO(idThree, "Company Three", "87654321", "CP_Three@example.com", DateTime.Now, DateTime.Now);

        dtos.Add(companyOne); dtos.Add(companyTwo); dtos.Add(companyThree);

        _companyServiceMock.Setup(x => x.GetAllCompaniesAsync(1, 10)).ReturnsAsync(dtos);

        // Act
        var result = await _companyController.GetAllCompaniesAsync();

        // Assert
        var actionResult = Assert.IsType<ActionResult<IEnumerable<CompanyAccountDTO>>>(result);
        var returnValue = Assert.IsType<OkObjectResult>(actionResult.Result);
        var dtoList = Assert.IsType<List<CompanyAccountDTO>>(returnValue.Value);
        Assert.Equal(3, dtoList.Count);
    }

    [Fact]
    public async Task GetCompanyByIdAsync_ReturnsCompanyAccountDTO()
    {
        // Arrange
        Guid idOne = Guid.NewGuid();

        var companyOne = new CompanyAccountDTO(idOne, "Company One", "12345678", "CP_One@example.com", DateTime.Now, DateTime.Now);
        _companyServiceMock.Setup(x => x.GetCompanyByIdAsync(idOne)).ReturnsAsync(companyOne);

        // Act
        var result = await _companyController.GetCompanyAsync(idOne);

        // Assert
        var actionResult = Assert.IsType<ActionResult<CompanyAccountDTO>>(result);
        var returnValue = Assert.IsType<OkObjectResult>(actionResult.Result);
        var dto = Assert.IsType<CompanyAccountDTO>(returnValue.Value);
        Assert.Equal(idOne, dto.Id);
        Assert.Equal("Company One", dto.CompanyName);
        Assert.Equal("12345678", dto.CompanyPhone);
        Assert.Equal("CP_One@example.com", dto.CompanyEmail);
    }

    [Fact]
    public async Task GetCompanySpecificJobsAsync_ReturnsListOfJobDTO()
    {
        // Arrange
        Guid idOne = Guid.NewGuid();
        Guid idTwo = Guid.NewGuid();

        var jobOne = new JobPostDTO(Guid.NewGuid(), idOne, "Company One", "Junior Developer", "Junior", "Fulltime", "Oslo", new DateTime(2024, 5, 16),
                         "Title", "Description here", "Oslo, .Net Developer, Junior", "Ola", "", "123456789", "", DateTime.Now, DateTime.Now);
        var jobTwo = new JobPostDTO(Guid.NewGuid(), idOne, "Company One", "Senior Developer", "Senior", "Fulltime", "Oslo", new DateTime(2024, 6, 1),
                         "Title", "Description here", "Oslo, .Net Developer, Senior", "Ola", "", "123456789", "", DateTime.Now, DateTime.Now);
        var jobThree = new JobPostDTO(Guid.NewGuid(), idOne, "Company One", "Senior Developer", "Senior", "Fulltime", "Oslo", new DateTime(2024, 5, 24),
                         "Title", "Description here", "Oslo, .Net Developer, Senior", "Ola", "", "123456789", "", DateTime.Now, DateTime.Now);


        _jobServiceMock.Setup(x => x.GetCompanySpecificJobsAsync(idOne, 1, 10)).ReturnsAsync(() => new List<JobPostDTO> { jobOne, jobTwo, jobThree });

        // Act
        var result = await _companyController.GetCompanySpecificJobsAsync(idOne, 1, 10);

        // Assert
        var actionResult = Assert.IsType<ActionResult<IEnumerable<JobPostDTO>>>(result);
        var returnValue = Assert.IsType<OkObjectResult>(actionResult.Result);
        var dtoList = Assert.IsType<List<JobPostDTO>>(returnValue.Value);
        Assert.Equal(3, dtoList.Count);
    }
}
