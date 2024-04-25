using Microsoft.EntityFrameworkCore;
using Utvikler_portal.Auth.DependencyInjection;
using Utvikler_portal.Auth.Repository;
using Utvikler_portal.Auth.Services;
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

builder.Services.AddAuth(builder.Configuration);

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
