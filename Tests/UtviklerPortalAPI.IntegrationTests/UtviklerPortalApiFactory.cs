using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Testcontainers.MySql;
using Utvikler_portal.Shared.Data;

namespace UtviklerPortalAPI.IntegrationTests;

public class UtviklerPortalApiFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly MySqlContainer _dbContainer = new MySqlBuilder()
        .WithImage("mysql:8.0.30").WithDatabase("utvikler_portal").WithUsername("ga-app").WithPassword("ga_5ecret-%")
        .Build();

    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<UtviklerPortalDbContext>));
            services.AddDbContext<UtviklerPortalDbContext>(options =>
            {
                options.UseMySql(_dbContainer.GetConnectionString(), new MySqlServerVersion(new Version("8.0.30")));
            });
        });
    }

    public new async Task DisposeAsync()
    {
        await _dbContainer.StopAsync();
    }
}
