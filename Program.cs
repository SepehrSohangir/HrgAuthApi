
using FluentValidation;
using HrgAuthApi.Builders;
using HrgAuthApi.Context;
using HrgAuthApi.Factory;
using HrgAuthApi.Interfaces;
using HrgAuthApi.Middleware;
using HrgAuthApi.Repository;
using HrgAuthApi.Service;
using HrgAuthApi.Validation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<UsersDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserManagement"))
);
builder.Services.AddDbContext<PublicDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PublicData"))
);
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenDescriptorFactory, TokenDescriptorFactory>();
builder.Services.AddScoped<ITokenDescriptorBuilder, TokenDescriptorBuilder>();
builder.Services.AddScoped<IValidationHandler, ValidationHandler>();
builder.Services.AddLogging(options => options.AddConsole());
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies().Where(e => !e.IsDynamic));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(e => !e.IsDynamic));
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
