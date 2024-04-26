using Microsoft.EntityFrameworkCore;
using Utvikler_portal.Auth.DependencyInjection;
using Utvikler_portal.JobbModul.Mappers;
using Utvikler_portal.JobbModul.Mappers.Interface;
using Utvikler_portal.JobbModul.Models.DTOs;
using Utvikler_portal.JobbModul.Models.Entities;
using Utvikler_portal.JobbModul.Repository;
using Utvikler_portal.JobbModul.Repository.Interfaces;
using Utvikler_portal.JobbModul.Services;
using Utvikler_portal.JobbModul.Services.Interfaces;
using Utvikler_portal.Shared.Data;
using Utvikler_portal.Auth.Repository;
using Utvikler_portal.Auth.Services;
using Utvikler_portal.JobSeekerModul.Maps;
using Utvikler_portal.JobSeekerModul.Maps.Interfaces;
using Utvikler_portal.JobSeekerModul.Models.DTOs;
using Utvikler_portal.JobSeekerModul.Models.Entities;
using Utvikler_portal.JobSeekerModul.Repositories;
using Utvikler_portal.JobSeekerModul.Repositories.Interfaces;
using Utvikler_portal.JobSeekerModul.Services;
using Utvikler_portal.JobSeekerModul.Services.Interfaces;

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


builder.Services.AddScoped<IMaps<User, UserDTO>, UserMap>();
builder.Services.AddScoped<IMaps<User, UserRegDTO>, UserRegMap>();
builder.Services.AddScoped<IMaps<Education, EducationDTO>, EducationMap>();
builder.Services.AddScoped<IMaps<Experience, ExperienceDTO>, ExperienceMap>();
builder.Services.AddScoped<IMaps<Skill, SkillDTO>, SkillMap>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEducationService, EducationService>();
builder.Services.AddScoped<IEducationRepository, EducationRepository>();
builder.Services.AddScoped<IExperienceService, ExperienceService>();
builder.Services.AddScoped<IExperienceRepository, ExperienceRepository>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
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
