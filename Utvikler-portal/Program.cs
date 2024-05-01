using Microsoft.EntityFrameworkCore;
using Utvikler_portal.JobbModul.Mappers;
using Utvikler_portal.JobbModul.Mappers.Interface;
using Utvikler_portal.JobbModul.Models.DTOs;
using Utvikler_portal.JobbModul.Models.Entities;
using Utvikler_portal.JobbModul.Repository;
using Utvikler_portal.JobbModul.Repository.Interfaces;
using Utvikler_portal.JobbModul.Services;
using Utvikler_portal.JobbModul.Services.Interfaces;
using Utvikler_portal.Shared.Data;
using Utvikler_portal.Shared.Policies;
using Utvikler_portal.Auth.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMapper<CompanyAccount, CompanyRegistrationDTO>, CompanyRegistrationMapper>();
builder.Services.AddScoped<IMapper<CompanyAccount, CompanyAccountDTO>, CompanyAccountMapper>();
builder.Services.AddScoped<IMapper<JobPost, JobPostDTO>, JobPostMapper>();
builder.Services.AddScoped<IMapper<JobPost, JobRegistrationDTO>, JobRegistrationMapper>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<UtviklerPortalDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 30))));
builder.Services.AddAuth(builder.Configuration);
builder.Services.AddHandlers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
