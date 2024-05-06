using System.Net;
using System.Net.Http.Json;
using Utvikler_portal.JobbModul.Models.DTOs;

namespace UtviklerPortalAPI.IntegrationTests.Controllers;

public class CompanyControllerTests : IClassFixture<UtviklerPortalApiFactory>
{
    private readonly HttpClient _client;
    public CompanyControllerTests(UtviklerPortalApiFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task CreateCompanyAccountAsync_WithoutToken_ReturnsUnauthorized()
    {
        // Arrange
        CompanyRegistrationDTO dto = new()
        {
            CompanyName = "Company One",
            CompanyPhone = "12345678",
            CompanyEmail = "CP_One@example.com",
        };

        // Act
        var response = await _client.PostAsJsonAsync($"/api/Company/CreateCompany?userId={Guid.NewGuid()}", dto);

        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
}
