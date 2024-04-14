using Microsoft.AspNetCore.Mvc;
using Moq;
using Utvikler_portal.JobbModul.Models.DTOs;
using Utvikler_portal.JobbModul.Services.Interfaces;
using Utvikler_portal.Shared.Controllers;

namespace UtviklerPortalAPI.UnitTests.Controllers;

public class CompanyControllerTests
{
    private readonly Mock<ICompanyService> _companyServiceMock = new();
    private readonly CompanyController _companyController;
    public CompanyControllerTests()
    {
        _companyController = new CompanyController(_companyServiceMock.Object);
    }

    [Fact]
    public async Task GetAllCompaniesAsync_WithPagination_ReturnsListOfCompanyAccountDTO()
    {
        // Arrange
        int idOne = 1;
        int idTwo = 2;
        int idThree = 3;
        List<CompanyAccountDTO> dtos = new();

        var companyOne = new CompanyAccountDTO(idOne, "Company One", "12345678", "CP_One@example.com", "User One", DateTime.Now, DateTime.Now);
        var companyTwo = new CompanyAccountDTO(idTwo, "Company Two", "43218765", "CP_Two@example.com", "User Two", DateTime.Now, DateTime.Now);
        var companyThree = new CompanyAccountDTO(idThree, "Company Three", "87654321", "CP_Three@example.com", "User Three", DateTime.Now, DateTime.Now);

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
}
