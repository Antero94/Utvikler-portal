using Utvikler_portal.JobbModul.Mappers;
using Utvikler_portal.JobbModul.Mappers.Interface;
using Utvikler_portal.JobbModul.Models.DTOs;
using Utvikler_portal.JobbModul.Models.Entities;

namespace UtviklerPortalAPI.UnitTests.Mappers;

public class CompanyMapperTests
{
    private readonly IMapper<CompanyAccount, CompanyAccountDTO> _companyMapper = new CompanyAccountMapper();
    private readonly IMapper<CompanyAccount, CompanyRegistrationDTO> _companyRegistrationMapper = new CompanyRegistrationMapper();

    [Fact]
    public void ShouldMapCompanyAccount_ToCompanyAccountDTO()
    {
        // Arrange
        CompanyAccount companyAccount = new()
        {
            Id = Guid.NewGuid(),
            CompanyName = "Company Name",
            CompanyPhone = "12345678",
            CompanyEmail = "2iQpF@example.com",
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow
        };

        // Act
        var result = _companyMapper.MapToDTO(companyAccount);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<CompanyAccountDTO>(result);
        Assert.Equal(companyAccount.Id, result.Id);
        Assert.Equal(companyAccount.CompanyName, result.CompanyName);
        Assert.Equal(companyAccount.CompanyPhone, result.CompanyPhone);
        Assert.Equal(companyAccount.CompanyEmail, result.CompanyEmail);
        Assert.True(companyAccount.Created < result.Created);
        Assert.True(companyAccount.Updated < result.Created);
    }

    [Fact]
    public void ShouldMapCompanyRegistrationDTO_ToCompanyAccount()
    {
        // Arrange
        CompanyRegistrationDTO companyRegistrationDTO = new()
        {
            CompanyName = "Company Name",
            CompanyPhone = "12345678",
            CompanyEmail = "2iQpF@example.com"
        };

        // Act
        var result = _companyRegistrationMapper.MapToModel(companyRegistrationDTO);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<CompanyAccount>(result);
        Assert.Equal(companyRegistrationDTO.CompanyName, result.CompanyName);
        Assert.Equal(companyRegistrationDTO.CompanyPhone, result.CompanyPhone);
        Assert.Equal(companyRegistrationDTO.CompanyEmail, result.CompanyEmail);
        Assert.True(result.Created < DateTime.UtcNow);
        Assert.True(result.Updated < DateTime.UtcNow);
        Assert.Equal(result.Id, Guid.Empty);
    }
}
