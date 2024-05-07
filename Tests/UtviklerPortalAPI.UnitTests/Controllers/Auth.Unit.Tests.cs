using Microsoft.Extensions.Configuration;
using Moq;
using Utvikler_portal.Auth.DTO;
using Utvikler_portal.Auth.Models;
using Utvikler_portal.Auth.Repository;
using Utvikler_portal.Auth.Services;
using Utvikler_portal.Auth.ValueObjects;
using Utvikler_portal.Models.Entities;

namespace UtviklerPortalAPI.UnitTests.Controllers;

public class AuthUnitTests
{
    private readonly ITokenService _tokenService;
    private readonly Mock<IConfiguration> _configuration;
    private readonly IMemberService _memberService;
    private readonly Mock<IEncryptionService> _encryptionService;
    private readonly Mock<IAuthRepository> _authRepository;
    private readonly Mock<ITokenService> _tokenServiceMock;

    public AuthUnitTests()
    {
        
        _configuration = new Mock<IConfiguration>();
        _tokenService = new TokenService(_configuration.Object);
        _tokenServiceMock = new Mock<ITokenService>();
        _memberService = new MemberService(_authRepository.Object,_encryptionService.Object,_tokenServiceMock.Object);
    }

    [Fact]
    public async void ShouldGenerateAccessToken()
    {
        //Arrange
        
        _configuration.Setup(x => x.GetSection("AccessTokenOptions")["AccessTokenSecretKey"])
            .Returns("76f98sfugagkjsa87t773ugasugd326tagfew7t7gu");
        _configuration.Setup(x => x.GetSection("AccessTokenOptions")["Issuer"])
            .Returns("https://localhost:5001");
        _configuration.Setup(x => x.GetSection("AccessTokenOptions")["Audience"])
            .Returns("https://localhost:5001");
        _configuration.Setup(x => x.GetSection("AccessTokenOptions")["AccessTokenExpirationMinutes"])
            .Returns("15");
        
        //Act
        var result=_tokenService.GenerateAccessToken(Guid.NewGuid(), "test", "test@mail.com", UserType.Create(1));
        
        //Assert
        
        Assert.True(!string.IsNullOrWhiteSpace(result));
        Assert.True(result.Length>500);
    }
    
}