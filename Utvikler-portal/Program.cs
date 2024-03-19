using Microsoft.EntityFrameworkCore;
using Utvikler_portal.Data;
using Utvikler_portal.Mappers;
using Utvikler_portal.Mappers.Interface;
using Utvikler_portal.Models.DTOs;
using Utvikler_portal.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMapper<CompanyAccount, CompanyRegistrationDTO>, CompanyRegistrationMapper>();
builder.Services.AddScoped<IMapper<CompanyAccount, CompanyAccountDTO>, CompanyAccountMapper>();
builder.Services.AddScoped<IMapper<UserAccount, UserRegistrationDTO>, UserRegistrationMapper>();
builder.Services.AddScoped<IMapper<UserAccount, UserAccountDTO>, UserAccountMapper>();
builder.Services.AddScoped<IMapper<JobPost, JobPostDTO>, JobPostMapper>();
builder.Services.AddDbContext<UtviklerPortalDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 30))));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
